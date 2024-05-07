using Entities.Models.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Instructor
{
    public class TrInstructorRepository
    {
        private AppDbContext _context;
        public TrInstructorRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrInstructorGeneralVM Inst)
        {
            
                var _Inst = new TrInstructor()
                {
                    Type = Inst.Type,
                    EmployeeId = Inst.EmployeeId,
                    InstructorDataId = Inst.InstructorDataId,
                    TrainingCenterId = Inst.TrainingCenterId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrInstructor.Add(_Inst);
                _context.SaveChanges();





                return _Inst.Id.ToString();
           
        }
        //-------------------------------
        // Update Data { By id => inst )} 
        //-------------------------------
        public string Update(TrInstructorVM Inst)
        {
           
                var _item = _context.TrInstructor.Single(n => n.Id == Inst.Id);
              


                    _item.EmployeeId = Inst.EmployeeId;
                    _item.InstructorDataId = Inst.InstructorDataId;
                    _item.TrainingCenterId = Inst.TrainingCenterId;

                    _item.Type = Inst.Type;
                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        //------------------------------
        // Delete Data { By id => InstId )} 
        //------------------------------
        public string Delete(int InstId)
        {
          
                var _receipt = _context.TrInstructor.Single(n => n.Id == InstId);
             

                    var DetailsToDelete = _context.TrInstructorCourse.Where(n => n.InstructorId == InstId).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrInstructorCourse.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.TrInstructor.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
                
            

        }
        //--------------------------

        public List<TrInstructorGetVM> GetAll()
        {
            var data = _context.TrInstructor.Select(
                n => new TrInstructorGetVM
                {
                    HeaderName = n.EmployeeId == null ? n.InstructorData.Name : n.Employee.Name,
                    employeeName = n.EmployeeId != null ? n.Employee.Name : null,
                    HeaderCode = n.EmployeeId == null ? n.InstructorData.Code.ToString() : n.Employee.Code,
                    HeaderPhone = n.EmployeeId == null ? n.InstructorData.phone : n.Employee.Phone,
                    HeaderEmail = n.EmployeeId == null ? n.InstructorData.Email : n.Employee.Email,
                    HeaderPosition = n.EmployeeId == null ? n.InstructorData.Position : n.Employee.Position.Name,
                    HeaderAddress = n.EmployeeId == null ? n.InstructorData.Address : n.Employee.Address,
                    HeaderGender = n.EmployeeId == null ? n.InstructorData.Gender : n.Employee.Gender,
                    HeaderCityName = n.EmployeeId == null ? n.InstructorData.City.Name : n.Employee.CityState.Name,
                    HeaderCityID = n.EmployeeId == null ? n.InstructorData.City.Id : n.Employee.CityState.Id,
                    //Details
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    InstructorDataId = n.InstructorDataId,
                    Type = n.Type,
                    TrainingCenterName = n.Trainingcenter.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
            return data;
        }

        public TrInstructorGetVM GetById(int itemId)
            => _context.TrInstructor.Select(
                n => new TrInstructorGetVM
                {
                    HeaderName = n.EmployeeId == null ? n.InstructorData.Name : n.Employee.Name,
                    employeeName = n.EmployeeId != null ? n.Employee.Name : null,
                    HeaderCode = n.EmployeeId == null ? n.InstructorData.Code.ToString() : n.Employee.Code,
                    HeaderPhone = n.EmployeeId == null ? n.InstructorData.phone : n.Employee.Phone,
                    HeaderEmail = n.EmployeeId == null ? n.InstructorData.Email : n.Employee.Email,
                    HeaderPosition = n.EmployeeId == null ? n.InstructorData.Position : n.Employee.Position.Name,
                    HeaderAddress = n.EmployeeId == null ? n.InstructorData.Address : n.Employee.Address,
                    HeaderGender = n.EmployeeId == null ? n.InstructorData.Gender : n.Employee.Gender,
                    HeaderCityName = n.EmployeeId == null ? n.InstructorData.City.Name : n.Employee.CityState.Name,
                    //Details
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    InstructorDataId = n.InstructorDataId,
                    Type = n.Type,
                    TrainingCenterName = n.Trainingcenter.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == itemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrInstructorGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrInstructor.Count();
            List<TrInstructorGetVM> Item = _context.TrInstructor
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrInstructorGetVM
                {
                    HeaderName = n.EmployeeId == null ? n.InstructorData.Name : n.Employee.Name,
                    employeeName = n.EmployeeId != null ? n.Employee.Name : null,
                    HeaderCode = n.EmployeeId == null ? n.InstructorData.Code.ToString() : n.Employee.Code,
                    HeaderPhone = n.EmployeeId == null ? n.InstructorData.phone : n.Employee.Phone,
                    HeaderEmail = n.EmployeeId == null ? n.InstructorData.Email : n.Employee.Email,
                    HeaderPosition = n.EmployeeId == null ? n.InstructorData.Position : n.Employee.Position.Name,
                    HeaderAddress = n.EmployeeId == null ? n.InstructorData.Address : n.Employee.Address,
                    HeaderGender = n.EmployeeId == null ? n.InstructorData.Gender : n.Employee.Gender,
                    HeaderCityName = n.EmployeeId == null ? n.InstructorData.City.Name : n.Employee.CityState.Name,
                    //Details
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    InstructorDataId = n.InstructorDataId,
                    Type = n.Type,
                    TrainingCenterName = n.Trainingcenter.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrInstructorGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }

        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
