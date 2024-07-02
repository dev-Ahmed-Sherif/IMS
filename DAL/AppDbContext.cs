using Entities;
using Entities.Models;
using Entities.Models.Cc;
using Entities.Models.Fa;
using Entities.Models.FI;
using Entities.Models.FI.Account;
using Entities.Models.FI.Currency;
using Entities.Models.FI.Entry;
using Entities.Models.FI.Journal;
using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.Pro;
using Entities.Models.PY;
using Entities.Models.SE;
using Entities.Models.STR;
using Entities.Models.STR.Add;
using Entities.Models.STR.Employee;
using Entities.Models.STR.General;
using Entities.Models.STR.Product;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using Entities.Models.TR;
using Entities.Models.TR.Course;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.General;
using Entities.Models.TR.Instructor;
using Entities.Models.TR.Plan;
using Entities.Models.VL;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrUserGroup>()
                .HasOne(b => b.PrUser)
                .WithMany(ba => ba.PR_User_Group)
                .HasForeignKey(bi => bi.UserId);

            modelBuilder.Entity<PrUserGroup>()
                .HasOne(b => b.PR_Group)
                .WithMany(ba => ba.PR_User_Group)
                .HasForeignKey(bi => bi.GroupId);

            modelBuilder.Entity<PrUserGroup>()
                .HasOne(b => b.CreatedBy)
                .WithMany(ba => ba.PrUserGroupCreated)
                .HasForeignKey(bi => bi.CreatedByID);


            modelBuilder.Entity<PrGroupRole>()
                .HasOne(b => b.PR_Group)
                .WithMany(ba => ba.PrGroupRole)
                .HasForeignKey(bi => bi.GroupId);
            modelBuilder.Entity<PrGroupRole>()
           .HasOne(b => b.PR_Role)
           .WithMany(ba => ba.PR_Group_Role)
           .HasForeignKey(bi => bi.RoleId);

            modelBuilder.Entity<PrGroupPrivileges>()
                .HasOne(b => b.PR_Group)
                .WithMany(ba => ba.PrGroupPrivileges)
                .HasForeignKey(bi => bi.GroupId);

            modelBuilder.Entity<PrGroupPrivileges>()
               .HasOne(b => b.Privileges)
               .WithMany(ba => ba.PrGroup_Privileges)
               .HasForeignKey(bi => bi.PrivilegesId);
            modelBuilder.Entity<StrGrade>()
                .HasOne(b => b.STR_Commodity)
                .WithMany(ba => ba.STR_Grade)
                .HasForeignKey(bi => bi.CommodityId);

            modelBuilder.Entity<StrPlatoon>()
                .HasOne(b => b.STR_Grade)
                .WithMany(ba => ba.STR_Platoon)
                .HasForeignKey(bi => bi.GradeId);

            modelBuilder.Entity<StrGroup>()
                .HasOne(b => b.STR_Platoon)
                .WithMany(ba => ba.STR_Groups)
                .HasForeignKey(bi => bi.PlatoonId);

            modelBuilder.Entity<StrOpeningStock>()
                .HasOne(b => b.STR_Store)
                .WithMany(ba => ba.STR_Opening_Stock)
                .HasForeignKey(bi => bi.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrOpeningStockDetails>()
                .HasOne(b => b.STR_Item)
                .WithMany(ba => ba.STR_Opening_Stock_Details)
                .HasForeignKey(bi => bi.ItemId);

            modelBuilder.Entity<StrOpeningStockDetails>()
                .HasOne(b => b.STR_Opening_Stock)
                .WithMany(ba => ba.STR_Opening_Stock_Details)
                .HasForeignKey(bi => bi.STR_Opening_StockId);

            modelBuilder.Entity<StrItem>()
                .HasOne(b => b.STR_Commodity)
                .WithMany(ba => ba.STR_Item)
                .HasForeignKey(bi => bi.CommodityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrItem>()
                .HasOne(b => b.STR_Grade)
                .WithMany(ba => ba.STR_Item)
                .HasForeignKey(bi => bi.GradeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrItem>()
                .HasOne(b => b.STR_Platoon)
                .WithMany(ba => ba.STR_Items)
                .HasForeignKey(bi => bi.PlatoonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrItem>()
                .HasOne(b => b.STR_Group)
                .WithMany(ba => ba.STR_Item)
                .HasForeignKey(bi => bi.GroupId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StrItem>()
                .HasOne(b => b.STR_Unit)
                .WithMany(ba => ba.STR_Item)
                .HasForeignKey(bi => bi.UnitId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAddDetails>()
                .HasOne(b => b.STR_Add)
                .WithMany(ba => ba.STR_Add_Details)
                .HasForeignKey(bi => bi.AddId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAddDetails>()
                .HasOne(b => b.STR_Item)
                .WithMany(ba => ba.STR_Add_Details)
                .HasForeignKey(bi => bi.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAdd>()
                .HasOne(b => b.Vendor)
                .WithMany(ba => ba.STR_Add)
                .HasForeignKey(bi => bi.VendorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAdd>()
                .HasOne(b => b.STR_Store)
                .WithMany(ba => ba.STR_Add)
                .HasForeignKey(bi => bi.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAdd>()
                .HasOne(b => b.SourceStore)
                .WithMany(ba => ba.STR_Add1)
                .HasForeignKey(bi => bi.SourceStoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAdd>()
                .HasOne(b => b.Employee)
                .WithMany(ba => ba.STR_Add)
                .HasForeignKey(bi => bi.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeOpeningCustody>()
                .HasOne(b => b.HR_Employee)
                .WithMany(ba => ba.STR_Employee_Opening_Custody)
                .HasForeignKey(bi => bi.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeOpeningCustodyDetails>()
                .HasOne(b => b.STR_Employee_Opening_Custody)
                .WithMany(ba => ba.STR_Employee_Opening_Custody_Details)
                .HasForeignKey(bi => bi.CustodyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeOpeningCustodyDetails>()
                .HasOne(b => b.STR_Item)
                .WithMany(ba => ba.STR_Employee_Opening_Custody_Details)
                .HasForeignKey(bi => bi.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeExchange>()
           .HasOne(b => b.Employee)
           .WithMany(ba => ba.STR_Employee_Exchange)
          .HasForeignKey(bi => bi.EmployeeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeExchange>()
           .HasOne(b => b.DestEmployee)
           .WithMany(ba => ba.Dest_Employee_Exchange)
           .HasForeignKey(bi => bi.DestEmployeeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeExchangeDetails>()
           .HasOne(b => b.STR_Item)
           .WithMany(ba => ba.STR_Employee_Exchange_Details)
           .HasForeignKey(bi => bi.ItemId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeExchangeDetails>()
           .HasOne(b => b.STR_Employee_Exchange)
           .WithMany(ba => ba.STR_Employee_Exchange_Details)
           .HasForeignKey(bi => bi.Employee_ExchangeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrWithDraw>()
               .HasOne(b => b.STR_Store)
               .WithMany(ba => ba.STR_Withdraw)
               .HasForeignKey(bi => bi.StoreId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrWithDraw>()
                .HasOne(b => b.DestStore)
                .WithMany(ba => ba.STR_Withdraw2)
                .HasForeignKey(bi => bi.DestStoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrWithDraw>()
               .HasOne(b => b.HR_Employee)
               .WithMany(ba => ba.STR_Withdraw)
               .HasForeignKey(bi => bi.EmployeeId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StrWithDrawDetails>()
            .HasOne(b => b.STR_Item)
            .WithMany(ba => ba.STR_Withdraw_Details)
            .HasForeignKey(bi => bi.ItemId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrOpeningStock>()
             .HasOne(b => b.fiscalyear)
             .WithMany(ba => ba.str_opening_stock_fiscalyear)
             .HasForeignKey(bi => bi.FiscalYearId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeExchange>()
             .HasOne(b => b.Fiscalyear)
             .WithMany(ba => ba.str_employee_exchange_fiscalyear)
             .HasForeignKey(bi => bi.FiscalYearId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrEmployeeOpeningCustody>()
            .HasOne(b => b.Fiscalyear)
            .WithMany(ba => ba.str_employee_opening_Custody_fiscalyear)
            .HasForeignKey(bi => bi.FiscalYearId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrWithDraw>()
            .HasOne(b => b.Fiscalyear)
          .WithMany(ba => ba.str_with_Draw_fiscalyear)
          .HasForeignKey(bi => bi.FiscalYearId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrAdd>()
           .HasOne(b => b.fiscalyear)
           .WithMany(ba => ba.str_add_fiscalyear)
           .HasForeignKey(bi => bi.FiscalYearId)
           .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<StrUserStore>()
            //.HasOne(b => b.User)
            //.WithMany(ba => ba.StrUser_Store)
            //.HasForeignKey(bi => bi.UserId)
            //.OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StrUserStore>()
          .HasOne(b => b.Store)
          .WithMany(ba => ba.Str_UserStore)
          .HasForeignKey(bi => bi.StoreId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FiAccountParent>()
           .HasOne(b => b.Account)
           .WithMany(ba => ba.FiAccountParent)
           .HasForeignKey(bi => bi.AccountId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FiAccountParent>()
           .HasOne(b => b.Parent)
           .WithMany(ba => ba.FiAccountParent1)
           .HasForeignKey(bi => bi.ParentId)
           .OnDelete(DeleteBehavior.NoAction);

            /////////

            modelBuilder.Entity<HrEmployeeVacation>()
           .HasOne(b => b.Employee)
           .WithMany(ba => ba.abs_employee)
           .HasForeignKey(bi => bi.EmployeeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HrEmployeeVacation>()
           .HasOne(b => b.SubstituteEmpolyee)
           .WithMany(ba => ba.SubstituteEmpolyee)
           .HasForeignKey(bi => bi.SubstituteEmpolyeeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrExcuted>()
           .HasOne(b => b.Purpose)
           .WithMany(ba => ba.Ex_Purpose)
           .HasForeignKey(bi => bi.PurposeId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrExcuted>()
           .HasOne(b => b.MaterialPurpose)
           .WithMany(ba => ba.Material_Purpose)
           .HasForeignKey(bi => bi.MaterialPurposeId)
           .OnDelete(DeleteBehavior.NoAction);

            /*=============================*/
            //=========Add Unique==========*/
            /*=============================*/
            modelBuilder.Entity<FiAccount>()
            .HasIndex(u => u.Code)
            .IsUnique();
            modelBuilder.Entity<PrUser>()
            .HasIndex(u => u.Name)
            .IsUnique();

            modelBuilder.Entity<PrUser>()
                .HasOne(e => e.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<PrUser>(e => e.EmployeeId);

            modelBuilder.Entity<StrItem>()
            .HasIndex(u => u.FullCode)
            .IsUnique();



            modelBuilder.Entity<HrEmployee>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<HrEmployee>()
                .HasIndex(e => e.Name);
            modelBuilder.Entity<HrEmployee>()
                .HasIndex(e => e.Code);

            modelBuilder.Entity<ProTenderDetails>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProPurchaseOrderDetails>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProPurchaseOrder>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProQuotation>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProQuotationDetails>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderCommittee>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderCommitteeRole>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderOpening>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderOpeningStatus>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderSelection>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderVendorReq>()
                .HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ProTenderVendorReqSendType>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<ProTender>()
                .HasQueryFilter(e => !e.IsDeleted);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                if (foreignKey.GetConstraintName().Contains("Pro"))
                    foreignKey.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            ApplySoftDeleteFilter(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private static void ApplySoftDeleteFilter(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(EntityBase.IsDeleted));
                    var falseConstant = Expression.Constant(false);
                    var lambda = Expression.Lambda(Expression.Equal(property, falseConstant), parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
        }
        //privileges
        public DbSet<PrRole> PrRole { get; set; }
        public DbSet<PrGroup> PrGroup { get; set; }
        public DbSet<PrUserGroup> PrUserGroup { get; set; }
        public DbSet<PrGroupRole> PrGroupRole { get; set; }
        public DbSet<PrUser> PrUser { get; set; }
        public DbSet<PrModule> PrModule { get; set; }
        public DbSet<PrPrivileges> PrPrivileges { get; set; }
        public DbSet<PrGroupPrivileges> PrGroupPrivileges { get; set; }
        public DbSet<PrUserModule> PrUserModule { get; set; }

        //Stores
        public DbSet<StrWithDrawDetails> StrWithDrawDetails { get; set; }
        public DbSet<StrWithDraw> StrWithDraw { get; set; }
        public DbSet<StrStore> StrStore { get; set; }
        public DbSet<StrCommodity> StrCommodity { get; set; }
        public DbSet<StrGrade> StrGrade { get; set; }
        public DbSet<StrPlatoon> StrPlatoon { get; set; }
        public DbSet<StrGroup> StrGroup { get; set; }
        public DbSet<StrUnit> StrUnit { get; set; }
        public DbSet<StrItem> StrItem { get; set; }
        public DbSet<StrEmployeeExchange> StrEmployeeExchange { get; set; }
        public DbSet<StrEmployeeExchangeDetails> StrEmployeeExchangeDetails { get; set; }
        public DbSet<StrOpeningStock> StrOpeningStock { get; set; }
        public DbSet<StrOpeningStockDetails> StrOpeningStockDetails { get; set; }
        public DbSet<StrEmployeeOpeningCustody> StrEmployeeOpeningCustody { get; set; }
        public DbSet<StrEmployeeOpeningCustodyDetails> StrEmployeeOpeningCustodyDetails { get; set; }
        public DbSet<StrVendor> StrVendor { get; set; }
        public DbSet<StrModel> StrModel { get; set; }
        public DbSet<StrProduct> StrProduct { get; set; }
        public DbSet<StrProductSerial> StrProductSerial { get; set; }
        public DbSet<StrWithDrawDetailsSerial> StrWithDrawDetailsSerial { get; set; }
        public DbSet<StrAddDetailsSerial> StrAddDetailsSerial { get; set; }
        public DbSet<StrEmployeeExchangeSerial> StrEmployeeExchangeSerial { get; set; }
        public DbSet<StrEmployeeOpeningCustodySerial> StrEmployeeOpeningCustodySerial { get; set; }
        public DbSet<StrOpeningStockDetailsSerial> StrOpeningStockDetailsSerial { get; set; }
        public DbSet<StrAddDetails> StrAddDetails { get; set; }
        public DbSet<StrAdd> StrAdd { get; set; }
        public DbSet<StrWithDrawType> StrWithDrawType { get; set; }
        public DbSet<StrAddType> StrAddType { get; set; }
        public DbSet<StrUserStore> StrUserStore { get; set; }
        public DbSet<StrApprovalStatus> StrApprovalStatus { get; set; }
        public DbSet<StrStockTaking> StrStockTaking { get; set; }
        public DbSet<StrStockTakingDetails> StrStockTakingDetails { get; set; }

        //Finance
        public DbSet<FiAccount> FiAccount { get; set; }
        public DbSet<FiAccountHierarchy> FiAccountHierarchy { get; set; }
        public DbSet<FiAccountItem> FiAccountItem { get; set; }
        public DbSet<FiAccountItemCategory> FiAccountItemCategory { get; set; }
        public DbSet<FiAccountParent> FiAccountParent { get; set; }
        public DbSet<FiEntry> FiEntry { get; set; }
        public DbSet<FiEntryDetails> FiEntryDetails { get; set; }
        public DbSet<FiJournal> FiJournal { get; set; }
        public DbSet<FiJournalType> FiJournalTypes { get; set; }
        public DbSet<FiEntrySource> FiEntrySource { get; set; }
        public DbSet<FiEntrySourceType> FiEntrySourceType { get; set; }
        public DbSet<FiCurrency> FiCurrencies { get; set; }
        public DbSet<FiCurrencyPrice> FiCurrencyPrices { get; set; }
        public DbSet<FiAccountBalance> FiAccountBalances { get; set; }

        //Procurement
        //Human resources
        public DbSet<HrEmployee> HrEmployee { get; set; }
        public DbSet<HrMillitryState> HrMillitryState { get; set; }
        public DbSet<HrQualitativeGroup> HrQualitativeGroup { get; set; }
        public DbSet<HrQualificationLevel> HrQualificationLevel { get; set; }
        public DbSet<HrQualification> HrQualification { get; set; }
        public DbSet<HrSpecialization> HrSpecialization { get; set; }
        public DbSet<HrJobTitle> HrJobTitle { get; set; }
        public DbSet<HrCity> HrCity { get; set; }
        public DbSet<HrCityState> HrCityState { get; set; }
        public DbSet<HrWorkPlace> HrWorkPlace { get; set; }
        public DbSet<HrSeveranceReason> HrSeveranceReason { get; set; }
        public DbSet<HrHiringType> HrHiringType { get; set; }
        public DbSet<HrFinancialDegree> HrFinancialDegree { get; set; }
        public DbSet<HrEmployeeFinancialDegree> HrEmployeeFinancialDegree { get; set; }
        public DbSet<HrVacation> HrVacation { get; set; }
        public DbSet<HrEmployeeVacationBalance> HrEmployeeVacationBalance { get; set; }
        public DbSet<HrEmployeeVacation> HrEmployeeVacation { get; set; }
        public DbSet<HrPosition> HrPosition { get; set; }
        public DbSet<HrDisciplinary> HrDisciplinary { get; set; }
        public DbSet<HrEmployeeAppraisal> HrEmployeeAppraisal { get; set; }
        public DbSet<HrEmployeeDisciplinary> HrEmployeeDisciplinary { get; set; }
        public DbSet<HrEmployeePosition> HrEmployeePosition { get; set; }
        public DbSet<HrEmployeeQualification> HrEmployeeQualification { get; set; }
        public DbSet<HrIncentiveAllowance> HrIncentiveAllowance { get; set; }
        public DbSet<HrAttendancePermission> HrAttendancePermission { get; set; }
        public DbSet<HrAttendanceSchedule> HrAttendanceSchedule { get; set; }
        public DbSet<HrAttendanceMachine> HrAttendanceMachine { get; set; }
        public DbSet<HrAttendanceMachineWorkPlace> HrAttendanceMachineWorkPlace { get; set; }
        public DbSet<HrEmployeeAttendance> HrEmployeeAttendance { get; set; }
        public DbSet<HrEmployeeAttendancePermission> HrEmployeeAttendancePermission { get; set; }
        public DbSet<HrEmployeeAttendanceSchedule> HrEmployeeAttendanceSchedule { get; set; }
        public DbSet<HrHoliday> HrHoliday { get; set; }
        public DbSet<HrBank> HrBank { get; set; }
        public DbSet<HrSalaryStatus> HrSalaryStatus { get; set; }
        public DbSet<HrReligion> HrReligion { get; set; }
        public DbSet<HrPayMethod> HrPayMethod { get; set; }
        public DbSet<HrHolidaySchedule> HrHolidaySchedule { get; set; }
        public DbSet<HrFinancialDegreeSalary> HrFinancialDegreeSalary { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartment { get; set; }
        public DbSet<StrFiscalYear> FiscalYear { get; set; }

        // payroll
        public DbSet<PyExchange> PyExchange { get; set; }
        public DbSet<PyExchangeDetails> PyExchangeDetails { get; set; }
        public DbSet<PyInstallment> PyInstallment { get; set; }
        public DbSet<PyItem> PyItem { get; set; }
        public DbSet<PyItemCategory> PyItemCategory { get; set; }
        public DbSet<PyItemGroup> PyItemGroup { get; set; }
        public DbSet<PyItemGroupDetails> PyItemGroupDetails { get; set; }
        public DbSet<PyItemGroupEmployee> PyItemGroupEmployee { get; set; }
        public DbSet<PyTaxBracket> PyTaxBracket { get; set; }
        //Training
        public DbSet<TrInstructor> TrInstructor { get; set; }
        public DbSet<TrInstructorCourse> TrInstructorCourse { get; set; }
        public DbSet<TrInstructorData> TrInstructorData { get; set; }
        public DbSet<TrTrackDetails> TrTrackDetails { get; set; }
        public DbSet<TrCorporateCLient> TrCorporateCLient { get; set; }
        public DbSet<TrTrainee> TrTrainee { get; set; }
        public DbSet<TrTrainingCenter> TrTrainingCenter { get; set; }
        public DbSet<TrTrainingCenterCourse> TrTrainingCenterCourse { get; set; }
        public DbSet<TrClassRoom> TrClassRoom { get; set; }
        public DbSet<TrTrack> TrTrack { get; set; }
        public DbSet<TrCourse> TrCourse { get; set; }
        public DbSet<TrCourseType> TrCourseType { get; set; }
        public DbSet<TrCourseCategory> TrCourseCategory { get; set; }
        public DbSet<TrPurpose> TrPurpose { get; set; }
        public DbSet<TrBudget> TrBudget { get; set; }
        public DbSet<TrPlan> TrPlan { get; set; }
        public DbSet<TrExcuted> TrExcuted { get; set; }
        public DbSet<TrPlanInstructor> TrPlanInstructor { get; set; }
        public DbSet<TrPlanPosition> TrPlanPosition { get; set; }
        public DbSet<TrFinancier> TrFinancier { get; set; }
        public DbSet<TrExcutedFinancier> TrExcutedFinancier { get; set; }
        public DbSet<TrExcutedPosition> TrExcutedPosition { get; set; }//fatma
        public DbSet<TrExcutedTrainee> TrExcutedTrainee { get; set; }//fatma
        public DbSet<TrExcutedInstructor> TrExcutedInstructor { get; set; }
        public DbSet<TrPlanFinancier> TrPlanFinancier { get; set; }
        public DbSet<TrPlanCourseData> TrPlanCourseData { get; set; }

        public DbSet<CcActivity> CcActivity { get; set; }
        public DbSet<CcFunction> CcFunction { get; set; }
        public DbSet<CcSource> CcSource { get; set; }
        public DbSet<CcRegion> CcRegion { get; set; }
        public DbSet<CcSubRegion> CcSubRegion { get; set; }
        public DbSet<CcPlant> CcPlant { get; set; }
        public DbSet<CcPlantComponent> CcPlantComponent { get; set; }//23/10
        public DbSet<CcEntry> CcEntry { get; set; }//23/10
        public DbSet<CcCostCenter> CcCostCenter { get; set; }//23/10
        public DbSet<CcCostCenterCategory> CcCostCenterCategory { get; set; }//23/10
        public DbSet<CcEquipment> CcEquipment { get; set; }//23/10
        public DbSet<CcEntryDetails> CcEntryDetails { get; set; }//23/10
                                                                 //Fa
        public DbSet<FaCategoryFirst> FaCategoryFirst { get; set; }//29/10
        public DbSet<FaCategorySecond> FaCategorySecond { get; set; }//29/10
        public DbSet<FaCategoryThird> FaCategoryThird { get; set; }//30/10
        public DbSet<FaFixedAsset> FaFixedAsset { get; set; }//30/10
        public DbSet<FaMoveFixedAsset> FaMoveFixedAsset { get; set; }//30/10
                                                                     //pro
        public DbSet<ProOperationType> ProOperationType { get; set; }//06/11
        public DbSet<ProPlanType> ProPlantType { get; set; }//06/11
        public DbSet<ProTenderBiddingMethod> ProTenderBiddingMethods { get; set; }//06/11
        public DbSet<ProVendorType> ProVendorTypes { get; set; }//06/11
        public DbSet<ProTender> ProTender { get; set; }//07/11
                                                       //Procurement
                                                       // public DbSet<ProVendor> ProVendor { get; set; }
        public DbSet<ProVendorsTypes> ProVendorsTypes { get; set; }//08/11
        public DbSet<ProVendor> ProVendors { get; set; }//08/11
        public DbSet<ProPurchaseOrder> ProPurchaseOrders { get; set; }
        public DbSet<ProPurchaseOrderDetails> ProPurchaseOrderDetails { get; set; }
        public DbSet<ProQuotation> ProQuotations { get; set; }
        public DbSet<ProQuotationDetails> ProQuotationDetails { get; set; }
        public DbSet<ProTenderCommittee> ProTenderCommittees { get; set; }
        public DbSet<ProTenderCommitteeMember> ProTenderCommitteeMembers { get; set; }
        public DbSet<ProTenderCommitteeRole> ProTenderCommitteeRoles { get; set; }
        public DbSet<ProTenderDetails> ProTenderDetails { get; set; }
        public DbSet<ProTenderOpening> ProTenderOpenings { get; set; }
        public DbSet<ProTenderOpeningMember> ProTenderOpeningMembers { get; set; }
        public DbSet<ProTenderOpeningDetails> ProTenderOpeningDetails { get; set; }
        public DbSet<ProTenderOpeningStatus> ProTenderOpeningStatuses { get; set; }
        public DbSet<ProTenderSelection> ProTenderSelections { get; set; }
        public DbSet<ProTenderVendorReq> ProTenderVendorReqs { get; set; }
        public DbSet<ProType> ProTypes { get; set; }

        public DbSet<ImsSection> ImsSection { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<VlDrivierLicense> VlDrivierLicenses { get; set; }
        public DbSet<VlDrivierLicenseType> VlDrivierLicenseTypes { get; set; }
        public DbSet<VlGarage> VlGarages { get; set; }
        public DbSet<VlItinerary> VlItineraries { get; set; }
        public DbSet<VlManufacturer> VlManufacturers { get; set; }
        public DbSet<VlModel> VlModels { get; set; }
        public DbSet<VlStaff> VlStaff { get; set; }
        public DbSet<VlStaffPosition> VlStaffPositions { get; set; }
        public DbSet<VlStaffStatus> VlStaffStatuses { get; set; }
        public DbSet<VlType> VlTypes { get; set; }
        public DbSet<VlVehicleGarage> VlVehicleGarages { get; set; }
        public DbSet<VlVehicleItinerary> VlVehicleItineraries { get; set; }
        public DbSet<VlVehicleJobOrder> VlVehicleJobOrders { get; set; }
        public DbSet<VlVehicleLicense> VlVehicleLicenses { get; set; }
        public DbSet<VlVehicleStatus> VlVehicleStatuses { get; set; }
        public DbSet<VlViechle> VlVehicles { get; set; }

    }
}
