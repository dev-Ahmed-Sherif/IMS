using Entities.Models.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Excuted
{
    public class TrExcutedRepository
    {
        private AppDbContext _context;
        public TrExcutedRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrExcutedGeneralVM Inst)
        {
           
                var _Inst = new TrExcuted()
                {


                    Days = Inst.Days,
                    StartDate = Inst.StartDate,
                    EndDate = Inst.EndDate,
                    NoTrainee = Inst.NoTrainee,

                    TrainingCenterId = Inst.TrainingCenterId,
                    ClassRoomId = Inst.ClassRoomId,
                    FiscalYearId = Inst.FiscalYearId,
                    CourseId = Inst.CourseId,
                    PurposeId = Inst.PurposeId,

                    MaterialPurposeId = Inst.MaterialPurposeId,
                    DelegateId = Inst.DelegateId,
                    NoTraineeCorporate = Inst.NoTraineeCorporate,
                    NoTraineeTotal = Inst.NoTraineeTotal,
                    Status = Inst.Status,
                    Cost = Inst.Cost,
                    Costplaned = Inst.Costplaned,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrExcuted.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
           
        }
        public string Update(TrExcutedVM Inst)
        {
           
                var _item = _context.TrExcuted.Single(n => n.Id == Inst.Id);
                


                    _item.TrainingCenterId = Inst.TrainingCenterId;

                    _item.Days = Inst.Days;
                    _item.StartDate = Inst.StartDate;
                    _item.EndDate = Inst.EndDate;
                    _item.NoTrainee = Inst.NoTrainee;

                    _item.ClassRoomId = Inst.ClassRoomId;
                    _item.FiscalYearId = Inst.FiscalYearId;
                    _item.CourseId = Inst.CourseId;
                    _item.PurposeId = Inst.PurposeId;

                    _item.MaterialPurposeId = Inst.MaterialPurposeId;
                    _item.DelegateId = Inst.DelegateId;

                    _item.NoTraineeCorporate = Inst.NoTraineeCorporate;
                    _item.NoTraineeTotal = Inst.NoTraineeTotal;
                    _item.Status = Inst.Status;
                    _item.Cost = Inst.Cost;
                    _item.Costplaned = Inst.Costplaned;

                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public string Delete(int InstId)
        {
           
                

            var _TrExcuted = _context.TrExcuted.Single(n => n.Id == InstId);

            var DetailsToDelete = _context.TrExcutedFinancier.Where(p => p.ExcutedId == InstId).ToList();
            var DetailsToDelete2 = _context.TrExcutedInstructor.Where(p => p.ExcutedId == InstId).ToList();
            var DetailsToDelete3 = _context.TrExcutedPosition.Where(p => p.ExcutedId == InstId).ToList();
            var DetailsToDelete4 = _context.TrExcutedTrainee.Where(p => p.ExcutedId == InstId).ToList();
            _context.TrExcutedFinancier.RemoveRange(DetailsToDelete);
            _context.SaveChanges();
            _context.TrExcutedInstructor.RemoveRange(DetailsToDelete2);
            _context.SaveChanges();
            _context.TrExcutedPosition.RemoveRange(DetailsToDelete3);
            _context.SaveChanges();
            _context.TrExcutedTrainee.RemoveRange(DetailsToDelete4);
            _context.SaveChanges();

            _context.TrExcuted.Remove(_TrExcuted);
            _context.SaveChanges();
            return "Succeeded";



        }
        public List<TrExcutedGetVM> GetAll()
            => _context.TrExcuted.Select(n => new TrExcutedGetVM
            {
                Id = n.Id,
                Days = n.Days,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                NoTrainee = n.NoTrainee,
                DelegateId = n.DelegateId,
                DelegateName = n.Delegate.Name,
                ClassRoomId = n.ClassRoomId,
                ClassRoomName = n.ClassRoom.Name,
                FiscalYearId = n.FiscalYearId,
                FiscalYearName = n.FiscalYear.fiscalyear,
                CourseId = n.CourseId,
                CourseName = n.Course.Name,
                PurposeId = n.PurposeId,
                PurposeName = n.Purpose.Name,
                TrainingCenterId = n.TrainingCenterId,
                TrainingCenterName = n.TrainingCenter.Name,
                NoTraineeCorporate = n.NoTraineeCorporate,
                NoTraineeTotal = n.NoTraineeTotal,
                Status = n.Status,
                Cost = n.Cost,
                Costplaned = n.Costplaned,
                MaterialPurposeId = n.MaterialPurposeId,
                MaterialPurposeName = n.MaterialPurpose.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();










        public List<TrExcutedGetSearchVM> Search(TrExcutedSearch searchModel)
        {
            var query = _context.TrExcuted.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.Days))
            {
                query = query.Where(p => p.Days.ToString().Contains(searchModel.Days));
            }
            if (!string.IsNullOrEmpty(searchModel.NoTrainee))
            {
                query = query.Where(p => p.NoTrainee.ToString().Contains(searchModel.NoTrainee));
            }
            if (!string.IsNullOrEmpty(searchModel.NoTraineeCorporate))
            {
                query = query.Where(p => p.NoTraineeCorporate.ToString().Contains(searchModel.NoTraineeCorporate));
            }
            if (!string.IsNullOrEmpty(searchModel.NoTraineeTotal))
            {
                query = query.Where(p => p.NoTraineeTotal.ToString().Contains(searchModel.NoTraineeTotal));
            }
            if (!string.IsNullOrEmpty(searchModel.Status))
            {
                query = query.Where(p => p.Status.ToString().Contains(searchModel.Status));
            }
            if (!string.IsNullOrEmpty(searchModel.Costplaned))
            {
                query = query.Where(p => p.Costplaned.ToString().Contains(searchModel.Costplaned));
            }
            if (!string.IsNullOrEmpty(searchModel.Cost))
            {
                query = query.Where(p => p.Cost.ToString().Contains(searchModel.Cost));
            }
            if (!string.IsNullOrEmpty(searchModel.DelegateId))
            {
                query = query.Where(p => p.DelegateId.ToString().Contains(searchModel.DelegateId));
            }
            if (!string.IsNullOrEmpty(searchModel.TrainingCenterId))
            {
                query = query.Where(p => p.TrainingCenterId.ToString().Contains(searchModel.TrainingCenterId));
            }
            if (!string.IsNullOrEmpty(searchModel.ClassRoomId))
            {
                query = query.Where(p => p.ClassRoomId.ToString().Contains(searchModel.ClassRoomId));
            }
            if (!string.IsNullOrEmpty(searchModel.FiscalYearId))
            {
                query = query.Where(p => p.FiscalYearId.ToString().Contains(searchModel.FiscalYearId));
            }
            if (!string.IsNullOrEmpty(searchModel.CourseId))
            {
                query = query.Where(p => p.CourseId.ToString().Contains(searchModel.CourseId));
            }
            if (!string.IsNullOrEmpty(searchModel.PurposeId))
            {
                query = query.Where(p => p.PurposeId.ToString().Contains(searchModel.PurposeId));
            }
            if (!string.IsNullOrEmpty(searchModel.MaterialPurposeId))
            {
                query = query.Where(p => p.MaterialPurposeId.ToString().Contains(searchModel.MaterialPurposeId));
            }
            if (!string.IsNullOrEmpty(searchModel.MaterialPurposeName))
            {
                query = query.Where(p => p.MaterialPurpose.Name.ToString().Contains(searchModel.MaterialPurposeName));
            }
            if (!string.IsNullOrEmpty(searchModel.TransactionUserId))
            {
                query = query.Where(p => p.CreatedBy.Id.ToString().Contains(searchModel.TransactionUserId));
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.StartDate >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.EndDate >= searchModel.EndDate.Value.Date);
            }
            var result = query.Select(n => new TrExcutedGetSearchVM
            {
                Id = n.Id,
                Days = n.Days,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                NoTrainee = n.NoTrainee,
                DelegateId = n.DelegateId,
                DelegateName = n.Delegate.Name,
                ClassRoomId = n.ClassRoomId,
                ClassRoomName = n.ClassRoom.Name,
                FiscalYearId = n.FiscalYearId,
                FiscalYearName = n.FiscalYear.fiscalyear,
                CourseId = n.CourseId,
                CourseName = n.Course.Name,
                PurposeId = n.PurposeId,
                PurposeName = n.Purpose.Name,
                TrainingCenterId = n.TrainingCenterId,
                TrainingCenterName = n.TrainingCenter.Name,
                NoTraineeCorporate = n.NoTraineeCorporate,
                NoTraineeTotal = n.NoTraineeTotal,
                Status = n.Status,
                Cost = n.Cost,
                Costplaned = n.Costplaned,
                MaterialPurposeId = n.MaterialPurposeId,
                MaterialPurposeName = n.MaterialPurpose.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                //Section = n.Section.Name,    

            }).ToList();

            return result;

        }

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<TrExcutedGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrExcuted.Count();
            List<TrExcutedGetVM> Item = _context.TrExcuted
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrExcutedGetVM
                {
                    Id = n.Id,
                    Days = n.Days,
                    StartDate = n.StartDate,
                    EndDate = n.EndDate,
                    NoTrainee = n.NoTrainee,
                    DelegateId = n.DelegateId,
                    ClassRoomId = n.ClassRoomId,
                    ClassRoomName = n.ClassRoom.Name,
                    FiscalYearId = n.FiscalYearId,
                    FiscalYearName = n.FiscalYear.fiscalyear,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    PurposeId = n.PurposeId,
                    PurposeName = n.Purpose.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    TrainingCenterName = n.TrainingCenter.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrExcutedGetVM>
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
        public TrExcutedGetVM GetById(int itemId) => _context.TrExcuted.Select(n => new TrExcutedGetVM { Id = n.Id, Days = n.Days, StartDate = n.StartDate, EndDate = n.EndDate, NoTrainee = n.NoTrainee, ClassRoomId = n.ClassRoomId, ClassRoomName = n.ClassRoom.Name, FiscalYearId = n.FiscalYearId, FiscalYearName = n.FiscalYear.fiscalyear, CourseId = n.CourseId, CourseName = n.Course.Name, PurposeId = n.PurposeId, PurposeName = n.Purpose.Name, TrainingCenterId = n.TrainingCenterId, TrainingCenterName = n.TrainingCenter.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
    }



}

