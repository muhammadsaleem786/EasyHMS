using System.Data.Entity;
using Repository.Pattern.Ef6;
using HMS.Entities.Models.Mapping;

namespace HMS.Entities.Models
{
    public partial class HMSContext : DataContext
    {
        static HMSContext()
        {
            Database.SetInitializer<HMSContext>(null);
        }
        public HMSContext() : base("Name=HMSContext")
        {
        }
        public DbSet<adm_company> adm_company { get; set; }
        public DbSet<adm_multilingual_dt> adm_multilingual_dt { get; set; }
        public DbSet<adm_multilingual_mf> adm_multilingual_mf { get; set; }
        public DbSet<adm_role_dt> adm_role_dt { get; set; }
        public DbSet<adm_role_mf> adm_role_mf { get; set; }
        public DbSet<adm_user_mf> adm_user_mf { get; set; }
        public DbSet<adm_user_company> adm_user_company { get; set; }
        public DbSet<emr_notes_favorite> emr_notes_favorite { get; set; }
        public DbSet<adm_user_token> adm_user_token { get; set; }
        public DbSet<sys_drop_down_mf> sys_drop_down_mf { get; set; }
        public DbSet<sys_drop_down_value> sys_drop_down_value { get; set; }
        public DbSet<emr_patient_mf> emr_patient_mf { get; set; }
        public DbSet<emr_appointment_mf> emr_appointment_mf { get; set; }
        public DbSet<emr_document> emr_document { get; set; }
        public DbSet<emr_prescription_complaint> emr_prescription_complaint { get; set; }
        public DbSet<emr_prescription_diagnos> emr_prescription_diagnos { get; set; }
        public DbSet<emr_prescription_investigation> emr_prescription_investigation { get; set; }
        public DbSet<emr_prescription_mf> emr_prescription_mf { get; set; }
        public DbSet<emr_prescription_observation> emr_prescription_observation { get; set; }
        public DbSet<emr_prescription_treatment> emr_prescription_treatment { get; set; }
        public DbSet<emr_prescription_treatment_template> emr_prescription_treatment_template { get; set; }
        public DbSet<emr_medicine> emr_medicine { get; set; }
        public DbSet<emr_expense> emr_expense { get; set; }
        public DbSet<emr_income> emr_income { get; set; }
        public DbSet<emr_complaint> emr_complaint { get; set; }
        public DbSet<emr_diagnos> emr_diagnos { get; set; }
        public DbSet<emr_instruction> emr_instruction { get; set; }
        public DbSet<emr_investigation> emr_investigation { get; set; }
        public DbSet<emr_observation> emr_observation { get; set; }
        public DbSet<emr_bill_type> emr_bill_type { get; set; }
        public DbSet<emr_patient_bill> emr_patient_bill { get; set; }
        public DbSet<emr_patient_bill_payment> emr_patient_bill_payment { get; set; }
        public DbSet<emr_vital> emr_vital { get; set; }

        public DbSet<ipd_admission> ipd_admission { get; set; }
        public DbSet<ipd_admission_charges> ipd_admission_charges { get; set; }
        public DbSet<ipd_admission_imaging> ipd_admission_imaging { get; set; }
        public DbSet<ipd_admission_lab> ipd_admission_lab { get; set; }
        public DbSet<ipd_admission_medication> ipd_admission_medication { get; set; }
        public DbSet<ipd_admission_notes> ipd_admission_notes { get; set; }
        public DbSet<ipd_admission_vital> ipd_admission_vital { get; set; }
        public DbSet<ipd_procedure_charged> ipd_procedure_charged { get; set; }
        public DbSet<ipd_procedure_medication> ipd_procedure_medication { get; set; }
        public DbSet<ipd_procedure_mf> ipd_procedure_mf { get; set; }
        public DbSet<ipd_diagnosis> ipd_diagnosis { get; set; }
        public DbSet<contact> contact { get; set; }
        
        public DbSet<user_payment> user_payment { get; set; }
        public DbSet<ipd_admission_discharge> ipd_admission_discharge { get; set; }
        //employee

        public DbSet<pr_employee_mf> pr_employee_mf { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new contactMap());
            modelBuilder.Configurations.Add(new ipd_admission_dischargeMap());
            modelBuilder.Configurations.Add(new user_paymentMap());
            modelBuilder.Configurations.Add(new ipd_diagnosisMap());
            modelBuilder.Configurations.Add(new emr_notes_favoriteMap());
            modelBuilder.Configurations.Add(new emr_bill_typeMap());
            modelBuilder.Configurations.Add(new emr_patient_billMap());
            modelBuilder.Configurations.Add(new emr_complaintMap());
            modelBuilder.Configurations.Add(new emr_diagnosMap());
            modelBuilder.Configurations.Add(new emr_instructionMap());
            modelBuilder.Configurations.Add(new emr_investigationMap());
            modelBuilder.Configurations.Add(new emr_observationMap());
            modelBuilder.Configurations.Add(new emr_incomeMap());
            modelBuilder.Configurations.Add(new emr_expenseMap());
            modelBuilder.Configurations.Add(new emr_appointment_mfMap());
            modelBuilder.Configurations.Add(new emr_patient_mfMap());
            modelBuilder.Configurations.Add(new adm_companyMap());
            modelBuilder.Configurations.Add(new adm_multilingual_dtMap());
            modelBuilder.Configurations.Add(new adm_multilingual_mfMap());
            modelBuilder.Configurations.Add(new adm_role_dtMap());
            modelBuilder.Configurations.Add(new adm_role_mfMap());
            modelBuilder.Configurations.Add(new adm_user_mfMap());
            modelBuilder.Configurations.Add(new emr_prescription_complaintMap());
            modelBuilder.Configurations.Add(new emr_prescription_diagnosMap());
            modelBuilder.Configurations.Add(new emr_prescription_investigationMap());
            modelBuilder.Configurations.Add(new emr_prescription_mfMap());
            modelBuilder.Configurations.Add(new emr_prescription_observationMap());
            modelBuilder.Configurations.Add(new emr_prescription_treatmentMap());
            modelBuilder.Configurations.Add(new emr_prescription_treatment_templateMap());
            modelBuilder.Configurations.Add(new adm_user_companyMap());
            modelBuilder.Configurations.Add(new adm_user_tokenMap()); modelBuilder.Configurations.Add(new emr_documentMap());
            modelBuilder.Configurations.Add(new sys_drop_down_mfMap());
            modelBuilder.Configurations.Add(new sys_drop_down_valueMap());
            modelBuilder.Configurations.Add(new emr_medicineMap());
            modelBuilder.Configurations.Add(new emr_vitalMap());
            modelBuilder.Configurations.Add(new ipd_admissionMap());
            modelBuilder.Configurations.Add(new ipd_admission_chargesMap());
            modelBuilder.Configurations.Add(new ipd_admission_imagingMap());
            modelBuilder.Configurations.Add(new ipd_admission_labMap());
            modelBuilder.Configurations.Add(new ipd_admission_medicationMap());
            modelBuilder.Configurations.Add(new ipd_admission_notesMap());
            modelBuilder.Configurations.Add(new ipd_admission_vitalMap());
            modelBuilder.Configurations.Add(new ipd_procedure_chargedMap());
            modelBuilder.Configurations.Add(new ipd_procedure_medicationMap());
            modelBuilder.Configurations.Add(new ipd_procedure_mfMap());
            modelBuilder.Configurations.Add(new emr_patient_bill_paymentMap());

        }
    }
}
