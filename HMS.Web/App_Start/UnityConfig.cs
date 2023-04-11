using System;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using HMS.Entities.Models;
using HMS.Service.Services.Admin;
using HMS.Service;
using HMS.Service.Services.Appointment;
using HMS.Service.Services.Admission;

namespace HMS.Web.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container
                 .RegisterType<IDataContextAsync, HMSContext>(new PerRequestLifetimeManager())
                 .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                  // Add Repositories
                  .RegisterType<IRepositoryAsync<adm_user_mf>, Repository<adm_user_mf>>()
                  .RegisterType<IRepositoryAsync<adm_user_token>, Repository<adm_user_token>>()
                  .RegisterType<IRepositoryAsync<adm_company>, Repository<adm_company>>()
                  .RegisterType<IRepositoryAsync<sys_drop_down_mf>, Repository<sys_drop_down_mf>>()
                  .RegisterType<IRepositoryAsync<sys_drop_down_value>, Repository<sys_drop_down_value>>()
                  .RegisterType<IRepositoryAsync<adm_role_mf>, Repository<adm_role_mf>>()
                  .RegisterType<IRepositoryAsync<adm_role_dt>, Repository<adm_role_dt>>()
                  .RegisterType<IRepositoryAsync<adm_user_company>, Repository<adm_user_company>>()
                  .RegisterType<IRepositoryAsync<adm_multilingual_mf>, Repository<adm_multilingual_mf>>()
                  .RegisterType<IRepositoryAsync<sys_notification_alert>, Repository<sys_notification_alert>>()
                  .RegisterType<IRepositoryAsync<emr_patient_mf>, Repository<emr_patient_mf>>()
                  .RegisterType<IRepositoryAsync<emr_appointment_mf>, Repository<emr_appointment_mf>>()
                  .RegisterType<IRepositoryAsync<emr_document>, Repository<emr_document>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_mf>, Repository<emr_prescription_mf>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_complaint>, Repository<emr_prescription_complaint>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_diagnos>, Repository<emr_prescription_diagnos>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_investigation>, Repository<emr_prescription_investigation>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_observation>, Repository<emr_prescription_observation>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_treatment>, Repository<emr_prescription_treatment>>()
                  .RegisterType<IRepositoryAsync<emr_prescription_treatment_template>, Repository<emr_prescription_treatment_template>>()
                  .RegisterType<IRepositoryAsync<emr_medicine>, Repository<emr_medicine>>()
                  .RegisterType<IRepositoryAsync<emr_expense>, Repository<emr_expense>>()
                  .RegisterType<IRepositoryAsync<emr_income>, Repository<emr_income>>()
                  .RegisterType<IRepositoryAsync<emr_complaint>, Repository<emr_complaint>>()
                  .RegisterType<IRepositoryAsync<emr_diagnos>, Repository<emr_diagnos>>()
                  .RegisterType<IRepositoryAsync<emr_instruction>, Repository<emr_instruction>>()
                  .RegisterType<IRepositoryAsync<emr_investigation>, Repository<emr_investigation>>()
                  .RegisterType<IRepositoryAsync<emr_observation>, Repository<emr_observation>>()
                  .RegisterType<IRepositoryAsync<emr_bill_type>, Repository<emr_bill_type>>()
                  .RegisterType<IRepositoryAsync<emr_patient_bill>, Repository<emr_patient_bill>>()
                  .RegisterType<IRepositoryAsync<emr_vital>, Repository<emr_vital>>()
                  .RegisterType<IRepositoryAsync<emr_notes_favorite>, Repository<emr_notes_favorite>>()
                  .RegisterType<IRepositoryAsync<ipd_admission>, Repository<ipd_admission>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_charges>, Repository<ipd_admission_charges>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_imaging>, Repository<ipd_admission_imaging>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_lab>, Repository<ipd_admission_lab>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_medication>, Repository<ipd_admission_medication>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_notes>, Repository<ipd_admission_notes>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_vital>, Repository<ipd_admission_vital>>()
                  .RegisterType<IRepositoryAsync<ipd_procedure_charged>, Repository<ipd_procedure_charged>>()
                  .RegisterType<IRepositoryAsync<ipd_procedure_medication>, Repository<ipd_procedure_medication>>()
                  .RegisterType<IRepositoryAsync<ipd_procedure_mf>, Repository<ipd_procedure_mf>>()
                  .RegisterType<IRepositoryAsync<ipd_diagnosis>, Repository<ipd_diagnosis>>()
                  .RegisterType<IRepositoryAsync<emr_patient_bill_payment>, Repository<emr_patient_bill_payment>>()
                  .RegisterType<IRepositoryAsync<user_payment>, Repository<user_payment>>()
                  .RegisterType<IRepositoryAsync<ipd_admission_discharge>, Repository<ipd_admission_discharge>>()
                  .RegisterType<IRepositoryAsync<contact>, Repository<contact>>()
                        // Add services  
                        .RegisterType<IcontactService, contactService>()
                        .RegisterType<Iipd_admission_dischargeService, ipd_admission_dischargeService>()
                       .RegisterType<Iuser_paymentService, user_paymentService>()
                       .RegisterType<Iipd_admissionService, ipd_admissionService>()
                       .RegisterType<Iemr_patient_bill_paymentService, emr_patient_bill_paymentService>()
                       .RegisterType<Iipd_diagnosisService, ipd_diagnosisService>()
                       .RegisterType<Iipd_admission_chargesService, ipd_admission_chargesService>()
                       .RegisterType<Iipd_admission_imagingService, ipd_admission_imagingService>()
                       .RegisterType<Iipd_admission_labService, ipd_admission_labService>()
                       .RegisterType<Iipd_admission_medicationService, ipd_admission_medicationService>()
                       .RegisterType<Iipd_admission_notesService, ipd_admission_notesService>()
                       .RegisterType<Iipd_admission_vitalService, ipd_admission_vitalService>()
                       .RegisterType<Iipd_procedure_chargedService, ipd_procedure_chargedService>()
                       .RegisterType<Iipd_procedure_medicationService, ipd_procedure_medicationService>()
                       .RegisterType<Iipd_procedure_mfService, ipd_procedure_mfService>()
                       .RegisterType<Iemr_vitalService, emr_vitalService>()
                       .RegisterType<Iemr_notes_favoriteService, emr_notes_favoriteService>()
                      .RegisterType<Iemr_bill_typeService, emr_bill_typeService>()
                      .RegisterType<Iemr_patient_billService, emr_patient_billService>()
                      .RegisterType<Iemr_complaintService, emr_complaintService>()
                       .RegisterType<Iemr_diagnosService, emr_diagnosService>()
                        .RegisterType<Iemr_instructionService, emr_instructionService>()
                         .RegisterType<Iemr_observationService, emr_observationService>()
                         .RegisterType<Iemr_investigationService, emr_investigationService>()
                     .RegisterType<Iemr_incomeService, emr_incomeService>()
                     .RegisterType<Iemr_expenseService, emr_expenseService>()
                     .RegisterType<Iemr_prescription_mfService, emr_prescription_mfService>()
                      .RegisterType<Iemr_prescription_complaintService, emr_prescription_complaintService>()
                      .RegisterType<Iemr_prescription_diagnosService, emr_prescription_diagnosService>()
                      .RegisterType<Iemr_prescription_investigationService, emr_prescription_investigationService>()
                      .RegisterType<Iemr_prescription_observationService, emr_prescription_observationService>()
                      .RegisterType<Iemr_prescription_treatmentService, emr_prescription_treatmentService>()
                      .RegisterType<Iemr_prescription_treatment_templateService, emr_prescription_treatment_templateService>()
                       .RegisterType<Iemr_medicineService, emr_medicineService>()
                    .RegisterType<Iemr_patientService, emr_patientService>()
                     .RegisterType<Iemr_documentService, emr_documentService>()
                    .RegisterType<Iemr_appointment_mfService, emr_appointment_mfService>()
                 .RegisterType<Isys_notification_alertService, sys_notification_alertService>()
                .RegisterType<Iadm_multilingual_mfService, adm_multilingual_mfService>()
                .RegisterType<Iadm_userService, adm_userService>()
                .RegisterType<Iadm_user_tokenService, adm_user_tokenService>()
                .RegisterType<Iadm_companyService, adm_companyService>()
                 .RegisterType<Isys_drop_down_mfService, sys_drop_down_mfService>()
                .RegisterType<Isys_drop_down_valueService, sys_drop_down_valueService>()
                 .RegisterType<Iadm_role_mfService, adm_role_mfService>()
                .RegisterType<Iadm_role_dtService, adm_role_dtService>()
                .RegisterType<Iadm_user_companyService, adm_user_companyService>()
                .RegisterType<IERPStoredProcedures, HMSContext>(new PerRequestLifetimeManager())
                .RegisterType<IStoredProcedureService, StoredProcedureService>();
        }
    }
}
