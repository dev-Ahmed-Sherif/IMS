using Entities.Models.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.General
{
    public class TrBudgetRepository
    {

        private AppDbContext _context;
        public TrBudgetRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrBudgetGeneralVM TR_Course)
        {
          
                var _Tr_Course = new TrBudget()
                {
                    NoTrainee = TR_Course.NoTrainee,
                    NoHour = TR_Course.NoHour,
                    InstructorHourFee = TR_Course.InstructorHourFee,
                    InstructorTotalFee = TR_Course.InstructorTotalFee,
                    SuperVisingFee = TR_Course.SuperVisingFee,
                    OtherFee = TR_Course.OtherFee,
                    SalaryTotal = TR_Course.SalaryTotal,
                    TransportCost = TR_Course.TransportCost,
                    ServiceTotal = TR_Course.ServiceTotal,
                    CourseTotal = TR_Course.CourseTotal,
                    CourseId = TR_Course.CourseId,
                    CreatedByID = TR_Course.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrBudget.Add(_Tr_Course);
                _context.SaveChanges();
                return _Tr_Course.Id.ToString();
          
        }
        public string Update(TrBudgetVM TR_Course)
        {
           
                var _TR_Course = _context.TrBudget. Single(n => n.Id == TR_Course.Id);
               
                    _TR_Course.NoTrainee = TR_Course.NoTrainee;
                    _TR_Course.NoHour = TR_Course.NoHour;
                    _TR_Course.InstructorHourFee = TR_Course.InstructorHourFee;
                    _TR_Course.InstructorTotalFee = TR_Course.InstructorTotalFee;
                    _TR_Course.SuperVisingFee = TR_Course.SuperVisingFee;
                    _TR_Course.OtherFee = TR_Course.OtherFee;
                    _TR_Course.SalaryTotal = TR_Course.SalaryTotal;
                    _TR_Course.TransportCost = TR_Course.TransportCost;
                    _TR_Course.ServiceTotal = TR_Course.ServiceTotal;
                    _TR_Course.CourseTotal = TR_Course.CourseTotal;
                    _TR_Course.CourseId = TR_Course.CourseId;
                    _TR_Course.UpdateByID = TR_Course.TransactionUserId;
                    _TR_Course.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        public string Delete(int TR_Course_Id)
        {
            
                var _TR_Course = _context.TrBudget.Single(n => n.Id == TR_Course_Id);
                


                    _context.TrBudget.Remove(_TR_Course);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public List<TrBudgetGetVM> GetAll()
          => _context.TrBudget.Select(
              n => new TrBudgetGetVM
              {
                  NoTrainee = n.NoTrainee,
                  NoHour = n.NoHour,
                  InstructorHourFee = n.InstructorHourFee,
                  InstructorTotalFee = n.InstructorTotalFee,
                  SuperVisingFee = n.SuperVisingFee,
                  OtherFee = n.OtherFee,
                  SalaryTotal = n.SalaryTotal,
                  TransportCost = n.TransportCost,
                  ServiceTotal = n.ServiceTotal,
                  CourseTotal = n.CourseTotal,
                  CourseId = n.CourseId,
                  CourseName = n.Course.Name,
                  Id = n.Id,
                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,

              }).ToList();
        public TrBudgetGetVM GetById(int TRCourseId)
            => _context.TrBudget.Select(
                n => new TrBudgetGetVM
                {
                    NoTrainee = n.NoTrainee,
                    NoHour = n.NoHour,
                    InstructorHourFee = n.InstructorHourFee,
                    InstructorTotalFee = n.InstructorTotalFee,
                    SuperVisingFee = n.SuperVisingFee,
                    OtherFee = n.OtherFee,
                    SalaryTotal = n.SalaryTotal,
                    TransportCost = n.TransportCost,
                    ServiceTotal = n.ServiceTotal,
                    CourseTotal = n.CourseTotal,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    Id = n.Id,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                }).Single(n => n.Id == TRCourseId);
    }
}
