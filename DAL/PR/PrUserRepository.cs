using Entities.ExtensionMethods;
using Entities.ExtensionMethods.PR;
using Entities.ExtensionMethods.STR.General;
using Entities.Models.PR;
using Entities.ViewModels;
using Entities.ViewModels.PR;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.PR
{
    public class PrUserRepository
    {
        private AppDbContext _context;
        public PrUserRepository(AppDbContext context)
        {
            _context = context;
        }
        //------------------
        //encrypt Password by BCrypt
        //------------------
        //private string HashPassword(string password, byte[] salt)
        //{
        //    // Generate a 128-bit salt using a secure PRNG
        //    byte[] saltBytes = salt ?? new byte[128 / 8];
        //    if (saltBytes.Length == 0)
        //    {
        //        using (var rng = RandomNumberGenerator.Create())
        //        {
        //            rng.GetBytes(saltBytes);
        //        }
        //    }
        //    // Derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        //    string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: password,
        //        salt: saltBytes,
        //        prf: KeyDerivationPrf.HMACSHA1,
        //        iterationCount: 10_000,
        //        numBytesRequested: 256 / 8));

        //    // Append the salt to the hashed password (format: saltBytes + hashedPassword)
        //    return Convert.ToBase64String(saltBytes) + hashedPassword;
        //}
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
        //------------------
        // ADD new (PR)_User
        //------------------
        public string Add(PrUserVM ID)
        {
            var _Row = new PrUser()
            {
                Name = ID.Name,
                Password = HashPassword(ID.Password + "16051998"),
                IsActive = ID.IsActive,
                CreatedByID = ID.TransactionUserId,
                CreationDate = DateTime.Now,
                EmployeeId = ID.EmployeeId,
            };
            _context.PrUser.Add(_Row);
            _context.SaveChanges();
            return _Row.Id.ToString();
        }

        //-------------------------------------------
        // Update (PR)_User { where id == User.id }
        //-------------------------------------------
        public string Update(PrUserVM ID)
        {

            var _Row = _context.PrUser.Single(n => n.Id == ID.Id);
            if (_Row != null)
            {
                _Row.Name = ID.Name;
                _Row.Password = HashPassword(ID.Password + "16051998");
                _Row.EmployeeId = ID.EmployeeId;
                _Row.IsActive = ID.IsActive;
                _Row.UpdateByID = ID.TransactionUserId;
                _Row.LastUpdateDate = DateTime.Now;
                _context.SaveChanges();
                return "Succeeded";
            }
            else
            {
                return "nothing to be updated";
            }

        }

        //-------------------------------------------
        // Dellete (PR)_User { where id == UserID }
        //-------------------------------------------
        public string Delete(int id)
        {

            var _Row = _context.PrUser.Single(n => n.Id == id);
            var usergroup = _context.PrUserGroup.Where(p => p.UserId == id).ToList();
            _context.PrUserGroup.RemoveRange(usergroup);
            _context.SaveChanges();

            _context.PrUser.Remove(_Row);
            _context.SaveChanges();
            return "Succeeded";

        }

        //---------------------------------------------------------------
        //Select * (PR)_User { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrUserVM> GetAll(UserFilter filter)
        {
            return
                Filter(_context.PrUser, filter)
                .Select(n => n.ToPrUserVM()).ToList();
        }


        public PaginatedResult<PrUserVM> GetAllPaginated(int pageIndex, int pageSize, UserFilter filter)
        {
            return
                Filter(_context.PrUser, filter)
                .ToPaginatedResult(pageIndex, pageSize, e => e.ToPrUserVM());
        }



        //----------------------------------------
        // Select * (PR)_User where {id = UserID}  
        //----------------------------------------
        public PrUserVM GetById(int ID)
        {
            return _context.PrUser.Single(n => n.Id == ID).ToPrUserVM();
        }

        //---------------------------------------------------------------------------------------------------
        // Select * (PR)_UserGroup where {id = UserID} { with GroupId ,UserId, Group_Name, Group_Description } 
        //----------------------------------------------------------------------------------------------------
        public PR_User_With_GroupVM GetUserGroup(int ID)
        {
            var _Row = _context.PrUser.Where(n => n.Id == ID)
                .Select(n => new PR_User_With_GroupVM()
                {
                    Name = n.Name,
                    Password = n.Password,
                    User_Group = n.PR_User_Group.Select(n => new PrUserGroupWithGroupVM()
                    {
                        Id = n.Id,
                        GroupId = n.GroupId,
                        UserId = n.UserId,
                        Group_Name = n.PR_Group.Name,
                        Group_Description = n.PR_Group.Description,
                        UserName = n.PrUser.Name,
                        TransactionUserId = n.CreatedByID
                    }).ToList()
                }).FirstOrDefault();
            return _Row;
        }

        //----------------------------------------------------------------------------
        // Select { name , password } => (PR)_User where {id = UserID} { Auth Login } 
        //----------------------------------------------------------------------------
        public async Task<UserVM> authenticationAsync(UserLogin login)
        {

            var user = _context.PrUser
                .Where(u => u.Name == login.Username && u.IsActive)
                .FirstOrDefault();
            if (user == null || !VerifyPassword(login.Password + "16051998", user.Password))
            {
                return null; // Handle invalid user or password
            }
            var modules = GetUserModules(user.Id);

            List<UserModule> userModule = new List<UserModule>();
            foreach (var module in modules)
            {
                var roles = GetUserRoles(user.Id, module.id);
                var item = new UserModule
                {
                    id = module.id,
                    name = module.name,
                    roles = roles
                };
                userModule.Add(item);
            }
            var userVM = new UserVM
            {
                Id = user.Id,
                Name = user.Name,
                Modules = userModule,
                EmployeeId = user.EmployeeId,
                SectionId = user.Employee?.SectionId
            };

            userVM.AccessToken = new JwtSecurityTokenHandler().WriteToken(await GenerateAccessTokenAsync(userVM));
            return userVM;
        }

        public List<FiscalYearData> GetFiscalYear(string fiscalyear)
        {
            var FiscalYears = _context.FiscalYear
                .OrderByDescending(fy => fy.Id)
                .Where(fy => fy.fiscalyear == fiscalyear)
                .Select(fy => fy.ToFiscalYearData())
                .ToList();

            return FiscalYears;
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return passwordMatches;
        }
        private List<UserRole> GetUserRoles(int userId, int? moduleId)
        {
            List<int> roleIds = null;
            if (moduleId != null)
            {
                roleIds = _context.PrGroupRole
                    .Join(_context.PrGroup, prGroupRole => prGroupRole.GroupId, prGroup => prGroup.Id, (prGroupRole, prGroup) => new { prGroupRole, prGroup })
                    .Join(_context.PrUserGroup, join1 => join1.prGroup.Id, prUserGroup => prUserGroup.GroupId, (join1, prUserGroup) => new { join1.prGroupRole, join1.prGroup, prUserGroup })
                    .Join(_context.PrUser, join2 => join2.prUserGroup.UserId, prUser => prUser.Id, (join2, prUser) => new { join2.prGroupRole, join2.prGroup, join2.prUserGroup, prUser })
                    .Where(join3 => join3.prUser.Id == userId)
                    .Where(join3 => join3.prGroupRole.PR_Role.ModuleId == moduleId)
                    .Select(join3 => join3.prGroupRole.RoleId)
                    .ToList();
            }
            else
            {
                roleIds = _context.PrGroupRole
                    .Join(_context.PrGroup, prGroupRole => prGroupRole.GroupId, prGroup => prGroup.Id, (prGroupRole, prGroup) => new { prGroupRole, prGroup })
                    .Join(_context.PrUserGroup, join1 => join1.prGroup.Id, prUserGroup => prUserGroup.GroupId, (join1, prUserGroup) => new { join1.prGroupRole, join1.prGroup, prUserGroup })
                    .Join(_context.PrUser, join2 => join2.prUserGroup.UserId, prUser => prUser.Id, (join2, prUser) => new { join2.prGroupRole, join2.prGroup, join2.prUserGroup, prUser })
                    .Where(join3 => join3.prUser.Id == userId)
                    .Select(join3 => join3.prGroupRole.RoleId)
                    .ToList();
            }
            var roles = _context.PrRole
                .Where(role => roleIds.Contains(role.Id))
                .Select(role => new UserRole { id = role.Id, name = role.Name })
                .ToList();
            return roles;
        }
        private List<UserModule> GetUserModules(int userId)
        {
            var moduleIds = _context.PrGroupRole
                .Join(_context.PrGroup, prGroupRole => prGroupRole.GroupId, prGroup => prGroup.Id, (prGroupRole, prGroup) => new { prGroupRole, prGroup })
                .Join(_context.PrUserGroup, join1 => join1.prGroup.Id, prUserGroup => prUserGroup.GroupId, (join1, prUserGroup) => new { join1.prGroupRole, join1.prGroup, prUserGroup })
                .Join(_context.PrUser, join2 => join2.prUserGroup.UserId, prUser => prUser.Id, (join2, prUser) => new { join2.prGroupRole, join2.prGroup, join2.prUserGroup, prUser })
                .Where(join3 => join3.prUser.Id == userId)
                .Select(join3 => join3.prGroupRole.PR_Role.ModuleId)
                .Distinct()
                .ToList();
            //var modules = _context.PrModule
            //    .Where(module => moduleIds.Contains(module.Id))
            //    .Select(module => new UserModule { id = module.Id, name = module.Name })
            //    .ToList();
            //var isAdmin = _context.PrUserModule
            //    .Where(module => moduleIds.Contains(module.ModuleId))
            //    .Where(module => module.UserId == userId)
            //    .Select(module => new UserModule { IsAdmin = module.IsAdmin })
            //    .ToList();
            //var modules = _context.PrModule
            //    .Join(_context.PrUserModule.Where(module => module.UserId == userId),
            //        module => module.Id,
            //        userModule => userModule.ModuleId,
            //        (module, userModule) =>
            //            new UserModule
            //            {
            //                id = module.Id,
            //                name = module.Name,
            //                IsAdmin = userModule.IsAdmin
            //            })
            //    .Where(module => moduleIds.Contains(module.id))
            //    .ToList();
            var modules = _context.PrModule
                .Select(module => new UserModule
                {
                    id = module.Id,
                    name = module.Name,
                })
                .Where(module => moduleIds.Contains(module.id))
                .ToList();
            return modules;
        }
        private async Task<JwtSecurityToken> GenerateAccessTokenAsync(UserVM user)
        {
            var ValidIssuer = Environment.GetEnvironmentVariable("ValidIssuer");
            var ValidAudience = Environment.GetEnvironmentVariable("ValidAudience");
            var secretKey = Environment.GetEnvironmentVariable("SecretKey");
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256);
            var Modules = GetUserModules(user.Id);
            var roleClaims = new List<Claim>();
            var engroleClaims = new List<Claim>();
            var ModuleClaims = new List<Claim>();
            var actions = new List<Claim>();
            foreach (var Module in Modules)
            {
                ModuleClaims.Add(new Claim("modules", Module.name));
                //var roles = GetUserRoles(user.Id, Module.id);
                //foreach (var role in roles)
                //{
                //    roleClaims.Add(new Claim("roles", role.name));
                //}
            }
            var roles = GetUserRoles(user.Id, null);
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role.name));
                // engroleClaims.Add(new Claim("engroles", role.engname));
            }

            var groupRoles = GetGroupRole(user.Id);
            var groupRolesVM = await groupRoles.Select(pr => pr.Select(e => e.ToPrGroupRoleGetVM())).ToListAsync();
            var jsonGroupRoles = JsonSerializer.Serialize(groupRolesVM);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Actions", jsonGroupRoles),
                new Claim("EmployeeId", user.EmployeeId?.ToString()??""),
                new Claim("SectionId", user.SectionId?.ToString()??"")
            }
            .Union(ModuleClaims)
            .Union(roleClaims)
            .Union(engroleClaims);

            var token = new JwtSecurityToken(
                ValidIssuer,
                ValidAudience,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return token;
        }
        private IQueryable<ICollection<PrGroupRole>> GetGroupRole(int userId)
        {
            return _context.
                PrUserGroup
                .Where
                (p => p.UserId == userId)
                .Select(p => p.PR_Group.PrGroupRole);
        }

        private static IQueryable<PrUser> Filter(IQueryable<PrUser> prUsers, UserFilter filter)
        {
            if (filter.Id.HasValue)
            {
                prUsers = prUsers.Where(e => e.Id == filter.Id);
            }
            if (filter.EmployeeId.HasValue)
            {
                prUsers = prUsers.Where(e => e.EmployeeId == filter.EmployeeId);
            }
            if (filter.IsActive.HasValue)
            {
                if (filter.IsActive.Value)
                {
                    prUsers = prUsers.Where(e => e.IsActive);
                }
                else if (!filter.IsActive.Value)
                {
                    prUsers = prUsers.Where(e => !e.IsActive);
                }
            }
            if (filter.IsAdmin.HasValue)
            {
                if (filter.IsAdmin.Value)
                {
                    prUsers = prUsers.Where(e => e.IsAdmin);
                }
                else if (!filter.IsAdmin.Value)
                {
                    prUsers = prUsers.Where(e => !e.IsAdmin);
                }
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                prUsers = prUsers.Where(e => e.Name.Contains(filter.Name));
            }
            if (filter.UserGroup.HasValue)
            {
                prUsers =
                    prUsers
                    .Where(e => e.PR_User_Group.Any(e => e.GroupId == filter.UserGroup));
            }
            if (filter.UserGroupCreated.HasValue)
            {
                prUsers =
                    prUsers
                    .Where(e =>
                        e.PrUserGroupCreated.Any(e => e.Id == filter.UserGroupCreated));
            }
            return prUsers;
        }
    }
}
