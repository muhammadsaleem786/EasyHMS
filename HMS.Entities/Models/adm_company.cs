using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class adm_company : Entity
    {
        public adm_company()
        {
            this.ipd_diagnosis = new List<ipd_diagnosis>();
            this.emr_notes_favorite = new List<emr_notes_favorite>();
            this.emr_bill_type = new List<emr_bill_type>();
            this.emr_patient_bill = new List<emr_patient_bill>();
            this.emr_expense = new List<emr_expense>();
            this.adm_role_mf = new List<adm_role_mf>();
            this.adm_user_company = new List<adm_user_company>();
            this.emr_appointment_mf = new List<emr_appointment_mf>();
            this.emr_medicine = new List<emr_medicine>();
            this.emr_patient_mf = new List<emr_patient_mf>(); this.emr_income = new List<emr_income>();
            this.emr_prescription_complaint = new List<emr_prescription_complaint>();
            this.emr_prescription_diagnos = new List<emr_prescription_diagnos>();
            this.emr_prescription_investigation = new List<emr_prescription_investigation>();
            this.emr_prescription_mf = new List<emr_prescription_mf>();
            this.emr_prescription_observation = new List<emr_prescription_observation>();
            this.emr_prescription_treatment = new List<emr_prescription_treatment>();
            this.emr_prescription_treatment_template = new List<emr_prescription_treatment_template>();
            this.sys_notification_alert = new List<sys_notification_alert>();
            this.emr_document = new List<emr_document>();
            this.emr_vital = new List<emr_vital>();
            this.ipd_admission = new List<ipd_admission>();
            this.ipd_admission_charges = new List<ipd_admission_charges>();
            this.ipd_admission_imaging = new List<ipd_admission_imaging>();
            this.ipd_admission_lab = new List<ipd_admission_lab>();
            this.ipd_admission_medication = new List<ipd_admission_medication>();
            this.ipd_admission_notes = new List<ipd_admission_notes>();
            this.ipd_admission_vital = new List<ipd_admission_vital>();
            this.ipd_procedure_charged = new List<ipd_procedure_charged>();
            this.ipd_procedure_medication = new List<ipd_procedure_medication>();
            this.ipd_procedure_mf = new List<ipd_procedure_mf>();
            this.emr_patient_bill_payment = new List<emr_patient_bill_payment>();
            this.user_payment = new List<user_payment>();
            this.ipd_admission_discharge = new List<ipd_admission_discharge>();

        }

        public decimal ID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyTypeDropDownID { get; set; }
        public Nullable<int> CompanyTypeID { get; set; }
        public string ReceiptFooter { get; set; }
        public Nullable<int> GenderID { get; set; }
        public string ContactPersonFirstName { get; set; }
        public bool IsCNICMandatory { get; set; }
        public string ContactPersonLastName { get; set; }
        public bool IsShowBillReceptionist { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> CityDropDownId { get; set; }
        public string CompanyLogo { get; set; }
        public Nullable<int> CountryDropdownId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool IsTrialVersion { get; set; }
        public bool IsBackDatedAppointment { get; set; }

        public int DateFormatDropDownID { get; set; }
        public Nullable<int> DateFormatId { get; set; }

        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<decimal> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual adm_user_mf adm_user_mf { get; set; }
        public virtual adm_user_mf adm_user_mf1 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual ICollection<adm_role_mf> adm_role_mf { get; set; }
        public virtual ICollection<emr_prescription_complaint> emr_prescription_complaint { get; set; }
        public virtual ICollection<emr_prescription_diagnos> emr_prescription_diagnos { get; set; }
        public virtual ICollection<emr_prescription_investigation> emr_prescription_investigation { get; set; }
        public virtual ICollection<emr_prescription_mf> emr_prescription_mf { get; set; }
        public virtual ICollection<emr_prescription_observation> emr_prescription_observation { get; set; }
        public virtual ICollection<emr_prescription_treatment> emr_prescription_treatment { get; set; }
        public virtual ICollection<emr_prescription_treatment_template> emr_prescription_treatment_template { get; set; }
        public virtual ICollection<adm_user_company> adm_user_company { get; set; }
        public virtual ICollection<emr_appointment_mf> emr_appointment_mf { get; set; }
        public virtual ICollection<emr_notes_favorite> emr_notes_favorite { get; set; }
        public virtual ICollection<emr_patient_mf> emr_patient_mf { get; set; }
        public virtual ICollection<sys_notification_alert> sys_notification_alert { get; set; }
        public virtual ICollection<emr_medicine> emr_medicine { get; set; }
        public virtual ICollection<emr_document> emr_document { get; set; }
        public virtual ICollection<emr_expense> emr_expense { get; set; }
        public virtual ICollection<emr_income> emr_income { get; set; }
        public virtual ICollection<emr_bill_type> emr_bill_type { get; set; }
        public virtual ICollection<ipd_diagnosis> ipd_diagnosis { get; set; }


        public virtual ICollection<emr_patient_bill> emr_patient_bill { get; set; }
        public virtual ICollection<emr_vital> emr_vital { get; set; }
        public virtual ICollection<ipd_admission> ipd_admission { get; set; }
        public virtual ICollection<ipd_admission_charges> ipd_admission_charges { get; set; }
        public virtual ICollection<ipd_admission_imaging> ipd_admission_imaging { get; set; }
        public virtual ICollection<ipd_admission_lab> ipd_admission_lab { get; set; }
        public virtual ICollection<ipd_admission_medication> ipd_admission_medication { get; set; }
        public virtual ICollection<ipd_admission_notes> ipd_admission_notes { get; set; }
        public virtual ICollection<ipd_admission_vital> ipd_admission_vital { get; set; }
        public virtual ICollection<ipd_procedure_charged> ipd_procedure_charged { get; set; }
        public virtual ICollection<ipd_procedure_medication> ipd_procedure_medication { get; set; }
        public virtual ICollection<ipd_procedure_mf> ipd_procedure_mf { get; set; }
        public virtual ICollection<emr_patient_bill_payment> emr_patient_bill_payment { get; set; }
        public virtual ICollection<user_payment> user_payment { get; set; }
        public virtual ICollection<ipd_admission_discharge> ipd_admission_discharge { get; set; }


    }
}
