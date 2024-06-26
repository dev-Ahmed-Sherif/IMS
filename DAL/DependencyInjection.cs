using DAL.Cc;
using DAL.Fa;
using DAL.FI.Account;
using DAL.FI.Entry;
using DAL.FI.General;
using DAL.HR;
using DAL.PR;
using DAL.Pro;
using DAL.PY;
using DAL.SE;
using DAL.STR.Add;
using DAL.STR.Employee;
using DAL.STR.General;
using DAL.STR.Product;
using DAL.STR.StoreOpen;
using DAL.STR.WithDraw;
using DAL.TR.Course;
using DAL.TR.Excuted;
using DAL.TR.General;
using DAL.TR.Instructor;
using DAL.TR.Plan;
using DAL.TR.Training;
using DAL.VL;
using Entities.Models.Pro;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            #region Hussein: configure the repositories
            services.AddScoped<PrRoleRepository>();
            services.AddScoped<PrModuleRepository>();
            services.AddScoped<PrGroupRepository>();
            services.AddScoped<PrUserRepository>();
            services.AddScoped<PrUserGroupRepository>();
            services.AddScoped<PrUserModuleRepository>();
            services.AddScoped<PrGroupRoleRepository>();
            services.AddScoped<PrPrivilegesRepository>();
            services.AddScoped<PrGroupPrivilegesRepository>();
            //Stores

            services.AddScoped<AddTypeRepository>();
            services.AddScoped<StrWithDrawTypeRepository>();
            services.AddScoped<StrCommodityRepository>();
            services.AddScoped<StrGradeRepository>();
            services.AddScoped<StrPlatoonRepository>();
            services.AddScoped<StrGroupRepository>();
            services.AddScoped<StrUnitRepository>();
            services.AddScoped<StrItemRepository>();
            services.AddScoped<StrStoreRepository>();
            services.AddScoped<StrAddRepository>();
            services.AddScoped<StrAddDetailsRepository>();
            services.AddScoped<StrWithDrawRepository>();
            services.AddScoped<StrWithDrawDetailsRepository>();
            services.AddScoped<StrEmployeeExchangeRepository>();
            services.AddScoped<StrEmployeeExchangeDetailsRepository>();
            services.AddScoped<StrOpeningStockRepository>();
            services.AddScoped<StrOpeningStockDetailsRepository>();
            services.AddScoped<StrFiscalYearRepository>();
            services.AddScoped<StrEmployeeOpeningCustodyRepository>();
            services.AddScoped<StrEmployeeOpeningCustodyDetailsRepository>();
            services.AddScoped<StrProductRepository>();
            services.AddScoped<StrVendorRepository>();
            services.AddScoped<StrModelRepository>();
            services.AddScoped<StrProductSerialRepository>();
            services.AddScoped<StrWithDrawDetailsSerialRepository>();
            services.AddScoped<StrAddDetailsSerialRepository>();
            services.AddScoped<StrEmployeeExchangeSerialRepository>();
            services.AddScoped<StrEmployeeOpeningCustodySerialRepository>();
            services.AddScoped<StrOpeningStockDetailsSerialRepository>();
            services.AddScoped<StrApprovalStatusRepository>();
            services.AddScoped<StrStockTakingRepository>();
            services.AddScoped<StrStockTakingDetailsRepository>();
            services.AddScoped<StrUserStoreRepository>();
            //Finance
            services.AddScoped<FiAccountRepository>();
            services.AddScoped<FiAccountHierarchyRepository>();
            services.AddScoped<FiAccountItemRepository>();
            services.AddScoped<FiAccountItemCategoryRepository>();
            services.AddScoped<FiAccountParentRepository>();
            services.AddScoped<FiJournalRepository>();
            services.AddScoped<FiJournalTypeRepository>();
            services.AddScoped<FiEntryRepository>();
            services.AddScoped<FiEntrySourceRepository>();
            services.AddScoped<FiEntrySourceTypeRepository>();
            services.AddScoped<FiEntryDetailsRepository>();
            //HR
            services.AddScoped<HrWorkPlaceRepository>();
            services.AddScoped<HrVacationRepository>();
            services.AddScoped<HrSpecializationRepository>();
            services.AddScoped<HrEmployeeRepository>();
            services.AddScoped<HrSeveranceReasonRepository>();
            services.AddScoped<HrQualitativeGroupRepository>();
            services.AddScoped<HrQualificationRepository>();
            services.AddScoped<HrQualificationLevelRepository>();
            services.AddScoped<HrPositionRepository>();
            services.AddScoped<HrMillitryStateRepository>();
            services.AddScoped<HrJobTitleRepository>();
            services.AddScoped<HrIncentiveAllowanceRepository>();
            services.AddScoped<HrHiringTypeRepository>();
            services.AddScoped<HrFinancialDegreeRepository>();
            services.AddScoped<HrEmployeeVacationRepository>();
            services.AddScoped<HrEmployeeVacationBalanceRepository>();
            services.AddScoped<HrEmployeeQualificationRepository>();
            services.AddScoped<HrEmployeePositionRepository>();
            services.AddScoped<HrEmployeeFinancialDegreeRepository>();
            services.AddScoped<HrEmployeeDisciplinaryRepository>();
            services.AddScoped<HrEmployeeAppraisalRepository>();
            services.AddScoped<HrDisciplinaryRepository>();
            services.AddScoped<HrCityStateRepository>();
            services.AddScoped<HrCityRepository>();
            services.AddScoped<HrBankRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<GeneralDepartmentRepository>();
            services.AddScoped<HrAttendancePermissionRepository>();
            services.AddScoped<HrAttendanceScheduleRepository>();
            services.AddScoped<HrAttendanceMachineRepository>();
            services.AddScoped<HrAttendanceMachineWorkPlaceRepository>();
            services.AddScoped<HrEmployeeAttendanceRepository>();
            services.AddScoped<HrEmployeeAttendancePermissionRepository>();
            services.AddScoped<HrEmployeeAttendanceScheduleRepository>();
            services.AddScoped<HrHolidayRepository>();
            services.AddScoped<HrHolidayScheduleRepository>();
            services.AddScoped<HrFinancialDegreeSalaryRepository>();
            services.AddScoped<HrPayMethodRepository>();
            // PY
            services.AddScoped<PyExchangeDetailsRepository>();
            services.AddScoped<PyExchangeRepository>();
            services.AddScoped<PyInstallmentRepository>();
            services.AddScoped<PyItemCategoryRepository>();
            services.AddScoped<PyItemGroupDetailsRepository>();
            services.AddScoped<PyItemGroupEmployeeRepository>();
            services.AddScoped<PyItemGroupRepository>();
            services.AddScoped<PyItemRepository>();
            services.AddScoped<PyTaxBracketRepository>();
            //Tr
            services.AddScoped<TrInstructorRepository>();
            services.AddScoped<TrInstructorCourseRepository>();
            services.AddScoped<TrInstructorDataRepository>();
            services.AddScoped<TrTrackDetailsRepository>();
            services.AddScoped<TrCoporateClientRepository>();
            services.AddScoped<TrTraineeRepository>();

            services.AddScoped<TrTrainingCenterRepository>();
            services.AddScoped<TrTrainingCenterCourseRepository>();
            services.AddScoped<TrClassRoomRepository>();
            services.AddScoped<TrTrackRepository>();
            services.AddScoped<TrCourseRepository>();
            services.AddScoped<TrCourseTypeRepository>();
            services.AddScoped<TrCourseCategoryRepository>();
            services.AddScoped<TrPlanRepository>();
            services.AddScoped<TrPlanInstructorRepository>();
            services.AddScoped<TrExcutedRepository>();
            services.AddScoped<TrExcutedFinancierRepository>();
            services.AddScoped<TrPurposeRepository>();
            services.AddScoped<TrBudgetRepository>();
            services.AddScoped<TrExcutedInstructorRepository>();
            services.AddScoped<TrExcutedPositionRepository>();
            services.AddScoped<TrExcutedTraineeRepository>();
            services.AddScoped<TrPlanFinancierRepository>();
            services.AddScoped<TrPlanPositionRepository>();
            services.AddScoped<TrFinancierRepository>();
            services.AddScoped<TrPlanCourseDataRepository>();
            services.AddScoped<CcFunctionRepository>();
            services.AddScoped<CcSourceRepository>();
            services.AddScoped<CcActivityRepository>();
            services.AddScoped<CcRegionRepository>();
            services.AddScoped<CcSubRegionRepository>();
            services.AddScoped<CcPlantRepository>();
            services.AddScoped<CcPlantComponentRepository>();//23/10
            services.AddScoped<CcEquipmentRepository>();//23/10
            services.AddScoped<CcCostCenterRepository>();//23/10
            services.AddScoped<CcEntryRepository>();//24/10
            services.AddScoped<CcEntryDetailsRepository>();//24/10
                                                           //Fa
            services.AddScoped<FaCategoryFirstRepository>();//29/10
            services.AddScoped<FaCategorySecondRepository>();//29/10
            services.AddScoped<FaCategoryThirdRepository>();//30/10
            services.AddScoped<FaFixedAssetRepository>();//30/10
            services.AddScoped<FaMoveFixedAssetRepository>();//30/10
                                                             //Pro
            services.AddScoped<ProOperationTypeRepository>();//07/11
            services.AddScoped<ProPlanTypeRepository>();//07/11
            services.AddScoped<ProTenderTypeRepository>();//07/11
            services.AddScoped<ProTenderRepository>();//07/11
            services.AddScoped<ProVendorsTypesRepository>();//07/11
            services.AddScoped<ProVendorTypeRepository>();//07/11
            services.AddScoped<ProVendorRepository>();//07/11
            services.AddScoped<ProTenderDetailsRepository>();
            services.AddScoped<ProTenderCommitteeRepository>();
            services.AddScoped<ProTenderCommitteeRoleRepository>();
            services.AddScoped<ProTenderOpeningRepository>();
            services.AddScoped<ProTenderOpeningStatusRepository>();
            services.AddScoped<ProTenderVendorReqRepository>();
            services.AddScoped<ProTenderVendorReqSendTypeRepository>();
            services.AddScoped<ProPurchaseOrderRepository>();
            services.AddScoped<ProPurchaseOrderDetailsRepository>();
            services.AddScoped<ProTenderSelectionRepository>();
            services.AddScoped<ProQuotationRepository>();
            services.AddScoped<ProQuotationDetailsRepository>();
            services.AddScoped<ProQuotationReceiveTypeRepository>();

            //SE
            services.AddScoped<ImsSectionRepository>();
            //VL
            services.AddScoped<VlGarageRepository>();
            services.AddScoped<VlModelRepository>();
            services.AddScoped<VlTypeRepository>();
            services.AddScoped<VlManufacturerRepository>();
            #endregion
            return services;
        }
    }
}
