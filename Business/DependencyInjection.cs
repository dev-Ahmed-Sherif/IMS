using Business.Cc;
using Business.Fa;
using Business.FI.Account;
using Business.FI.Entry;
using Business.FI.General;
using Business.HR;
using Business.PR;
using Business.Pro;
using Business.PY;
using Business.SE;
using Business.STR.Add;
using Business.STR.Employee;
using Business.STR.General;
using Business.STR.Product;
using Business.STR.StoreOpen;
using Business.STR.WithDraw;
using Business.TR.Course;
using Business.TR.Excuted;
using Business.TR.General;
using Business.TR.Instructor;
using Business.TR.Plan;
using Business.TR.Training;
using Business.Vl;
using DAL;
using DAL.Pro;
using DAL.VL;
using Entities.Models.Pro;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            /*
             * Changed Service Scope
             * From Transient To Scoped
             * Form One Instance For Each User Request
             * To
             * One Instance For Each User For All Requests
             */
            #region Hussein: configure the services
            services.AddScoped<PrRoleService>();
            services.AddScoped<PrModuleService>();
            services.AddScoped<PrGroupService>();
            services.AddScoped<PrUserService>();
            services.AddScoped<PrUserGroupService>();
            services.AddScoped<PrUserModuleService>();
            services.AddScoped<PrGroupRoleService>();
            services.AddScoped<PrPrivilegesService>();
            services.AddScoped<PrGroupPrivilegesService>();
            //Stores

            services.AddScoped<AddTypeService>();
            services.AddScoped<WithDrawTypeService>();
            services.AddScoped<StrCommodityService>();
            services.AddScoped<StrGradeService>();
            services.AddScoped<StrPlatoonService>();
            services.AddScoped<StrGroupService>();
            services.AddScoped<StrUnitService>();
            services.AddScoped<StrItemService>();
            services.AddScoped<StrStoreService>();
            services.AddScoped<StrAddService>();
            services.AddScoped<StrAddDetailsService>();
            services.AddScoped<StrWithDrawService>();
            services.AddScoped<StrWithDrawDetailsService>();
            services.AddScoped<StrEmployeeExchangeService>();
            services.AddScoped<StrEmployeeExchangeDetailsService>();
            services.AddScoped<StrOpeningStockService>();
            services.AddScoped<StrOpeningStockDetailsService>();
            services.AddScoped<StrFiscalYearServices>();
            services.AddScoped<StrEmployeeOpeningCustodyService>();
            services.AddScoped<StrEmployeeOpeningCustodyDetailsService>();
            services.AddScoped<StrProductService>();
            services.AddScoped<StrVendorService>();
            services.AddScoped<StrModelService>();
            services.AddScoped<StrProductSerialService>();
            services.AddScoped<StrWithDrawDetailsSerialService>();
            services.AddScoped<StrAddDetailsSerialService>();
            services.AddScoped<StrEmployeeExchangeSerialService>();
            services.AddScoped<StrEmployeeOpeningCustodySerialService>();
            services.AddScoped<StrOpeningStockDetailsSerialService>();
            services.AddScoped<StrApprovalStatusService>();
            services.AddScoped<StrStockTakingService>();
            services.AddScoped<StrStockTakingDetailsService>();
            services.AddScoped<StrUserStoreService>();
            //Finance
            services.AddScoped<FiAccountService>();
            services.AddScoped<FiAccountHierarchyService>();
            services.AddScoped<FiAccountItemService>();
            services.AddScoped<FiAccountItemCategoryService>();
            services.AddScoped<FiAccountParentService>();
            services.AddScoped<FiJournalService>();
            services.AddScoped<FiJournalTypeService>();
            services.AddScoped<FiEntryService>();
            services.AddScoped<FiEntrySourceService>();
            services.AddScoped<FiEntrySourceTypeService>();
            services.AddScoped<FiEntryDetailsService>();
            //HR
            services.AddScoped<HrWorkPlaceService>();
            services.AddScoped<HrVacationService>();
            services.AddScoped<HrSpecializationService>();
            services.AddScoped<HrEmployeeService>();
            services.AddScoped<HrSeveranceReasonService>();
            services.AddScoped<HrQualitativeGroupService>();
            services.AddScoped<HrQualificationService>();
            services.AddScoped<HrQualificationLevelService>();
            services.AddScoped<HrPositionService>();
            services.AddScoped<HrMillitryStateService>();
            services.AddScoped<HrJobTitleService>();
            services.AddScoped<HrIncentiveAllowanceService>();
            services.AddScoped<HrHiringTypeService>();
            services.AddScoped<HrFinancialDegreeService>();
            services.AddScoped<HrEmployeeVacationService>();
            services.AddScoped<HrEmployeeVacationBalanceService>();
            services.AddScoped<HrEmployeeQualificationService>();
            services.AddScoped<HrEmployeePositionService>();
            services.AddScoped<HrEmployeeFinancialDegreeService>();
            services.AddScoped<HrEmployeeDisciplinaryService>();
            services.AddScoped<HrEmployeeAppraisalService>();
            services.AddScoped<HrDisciplinaryService>();
            services.AddScoped<HrCityStateService>();
            services.AddScoped<HrCityService>();
            services.AddScoped<HrBankService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<GeneralDepartmentService>();
            services.AddScoped<HrAttendancePermissionService>();
            services.AddScoped<HrAttendanceScheduleService>();
            services.AddScoped<HrAttendanceMachineService>();
            services.AddScoped<HrAttendanceMachineWorkPlaceService>();
            services.AddScoped<HrEmployeeAttendanceService>();
            services.AddScoped<HrEmployeeAttendancePermissionService>();
            services.AddScoped<HrEmployeeAttendanceScheduleService>();
            services.AddScoped<HrHolidayService>();
            services.AddScoped<HrHolidayScheduleService>();
            services.AddScoped<HrFinancialDegreeSalaryService>();
            services.AddScoped<HrPayMethodService>();
            // PY
            services.AddScoped<PyExchangeDetailsService>();
            services.AddScoped<PyExchangeService>();
            services.AddScoped<PyInstallmentService>();
            services.AddScoped<PyItemCategoryService>();
            services.AddScoped<PyItemGroupDetailsService>();
            services.AddScoped<PyItemGroupEmployeeService>();
            services.AddScoped<PyItemGroupService>();
            services.AddScoped<PyItemService>();
            services.AddScoped<PyTaxBracketService>();
            //Tr
            services.AddScoped<TrInstructorService>();
            services.AddScoped<TrInstructorCourseService>();
            services.AddScoped<TrInstructorDataService>();
            services.AddScoped<TrTrackDetailService>();
            services.AddScoped<TrCoporateClientService>();
            services.AddScoped<TrTraineeService>();

            services.AddScoped<TrTrainingCenterService>();
            services.AddScoped<TrTrainingCenterCourseService>();
            services.AddScoped<TrClassRoomService>();
            services.AddScoped<TrTrackService>();
            services.AddScoped<TrCourseService>();
            services.AddScoped<TrCourseTypeService>();
            services.AddScoped<TrCourseCategoryService>();
            services.AddScoped<TrPlanService>();
            services.AddScoped<TrPlanInstructorService>();
            services.AddScoped<TrExcutedService>();
            services.AddScoped<TrExcutedFinancierService>();
            services.AddScoped<TrpurposeService>();
            services.AddScoped<TrBudgetService>();
            services.AddScoped<TrExcutedInstructorService>();
            services.AddScoped<TrExcutedPositionService>();
            services.AddScoped<TrExcutedTraineeService>();
            services.AddScoped<TrPlanFinancierService>();
            services.AddScoped<TrPlanPositionService>();
            services.AddScoped<TrFinancierService>();
            services.AddScoped<TrPlanCourseDataService>();
            services.AddScoped<CcFunctionService>();
            services.AddScoped<CcSourceService>();
            services.AddScoped<CcActivityService>();
            services.AddScoped<CcRegionService>();
            services.AddScoped<CcSubRegionService>();
            services.AddScoped<CcPlantService>();
            services.AddScoped<CcPlantComponentService>();//23/10
            services.AddScoped<CcEquipmentService>();//23/10
            services.AddScoped<CcCostCenterService>();//23/10
            services.AddScoped<CcEntryService>();//24/10
            services.AddScoped<CcEntryDetailsService>();//24/10
            //Fa
            services.AddScoped<FaCategoryFirstService>();//29/10
            services.AddScoped<FaCategorySecondService>();//29/10
            services.AddScoped<FaCategoryThirdService>();//30/10
            services.AddScoped<FaFixedAssetService>();//30/10
            services.AddScoped<FaMoveFixedAssetService>();//30/10
            //Pro
            services.AddScoped<ProOperationTypeService>();//07/11
            services.AddScoped<ProPlanTypeService>();//07/11
            services.AddScoped<ProTenderBiddingMethodService>();//07/11

            services.AddScoped<ProTenderService>();//07/11
            services.AddScoped<ProVendorService>();//07/11
            services.AddScoped<ProVendorTypeService>();//07/11
            services.AddScoped<ProVendorsTypesService>();//07/11
            services.AddScoped<ProVendorAttachmentService>();//07/11
            services.AddScoped<ProTenderDetailsService>();
            services.AddScoped<ProTenderCommitteeService>();
            services.AddScoped<ProTenderCommitteeMemberService>();//07/11
            services.AddScoped<ProTenderCommitteeRoleService>();
            services.AddScoped<ProTenderOpeningService>();
            services.AddScoped<ProTenderOpeningMemberService>();//07/11
            services.AddScoped<ProTenderOpeningDetails>();//07/11
            services.AddScoped<ProTenderOpeningStatusService>();
            services.AddScoped<ProTenderVendorReqService>();
            services.AddScoped<ProTenderVendorReqSendTypeService>();
            services.AddScoped<ProPurchaseOrderService>();
            services.AddScoped<ProPurchaseOrderDetailsService>();
            services.AddScoped<ProTenderSelectionService>();
            services.AddScoped<ProQuotationService>();
            services.AddScoped<ProQuotationDetailsService>();
            services.AddScoped<ProQuotationReceiveTypeService>();
            //SE
            services.AddScoped<ImsSectionService>();
            services.AddScoped<UnitOfWork>();
            //VL
            services.AddScoped<VlGarageService>();
            services.AddScoped<VlModelService>();
            services.AddScoped<VlTypeService>();
            services.AddScoped<VlManufacturerService>();

            #endregion
            return services;
        }
    }
}
