using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class sys_drop_down_value : Entity
    {
        public sys_drop_down_value()
        {
            this.adm_user_mf = new List<adm_user_mf>();
            this.adm_company = new List<adm_company>();
            this.adm_role_dt = new List<adm_role_dt>();
            this.emr_document = new List<emr_document>();
            this.emr_medicine = new List<emr_medicine>();
            this.emr_medicine1 = new List<emr_medicine>();
            this.emr_expense = new List<emr_expense>();
            this.emr_income = new List<emr_income>();
            this.emr_patient_mf = new List<emr_patient_mf>();
            this.emr_patient_mf1 = new List<emr_patient_mf>();
            this.emr_patient_mf2 = new List<emr_patient_mf>();
            this.emr_vital = new List<emr_vital>();
            this.ipd_admission = new List<ipd_admission>();           
            this.ipd_procedure_mf = new List<ipd_procedure_mf>();
            this.ipd_admission_imaging = new List<ipd_admission_imaging>();
            this.ipd_admission_imaging1 = new List<ipd_admission_imaging>();
            this.ipd_admission_imaging2 = new List<ipd_admission_imaging>();
            this.ipd_admission_lab = new List<ipd_admission_lab>();
            this.ipd_admission_lab1 = new List<ipd_admission_lab>();
            this.ipd_admission_lab2 = new List<ipd_admission_lab>();

            this.ipd_admission1 = new List<ipd_admission>();
            this.ipd_admission2 = new List<ipd_admission>();
            this.ipd_admission3 = new List<ipd_admission>();
        }
        public int ID { get; set; }
        public int DropDownID { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> DependedDropDownID { get; set; }
        public Nullable<int> DependedDropDownValueID { get; set; }
        public Nullable<bool> SystemGenerated { get; set; }
        public Nullable<decimal> CompanyID { get; set; }
        public string Unit { get; set; }
        public virtual ICollection<adm_user_mf> adm_user_mf { get; set; }
        public virtual ICollection<adm_company> adm_company { get; set; }
        public virtual ICollection<adm_role_dt> adm_role_dt { get; set; }
        public virtual sys_drop_down_mf sys_drop_down_mf { get; set; }
        public virtual ICollection<emr_document> emr_document { get; set; }
        public virtual ICollection<emr_medicine> emr_medicine { get; set; }
        public virtual ICollection<emr_medicine> emr_medicine1 { get; set; }
        public virtual ICollection<emr_patient_mf> emr_patient_mf { get; set; }
        public virtual ICollection<emr_patient_mf> emr_patient_mf1 { get; set; }
        public virtual ICollection<emr_patient_mf> emr_patient_mf2 { get; set; }
        public virtual ICollection<emr_expense> emr_expense { get; set; }
        public virtual ICollection<emr_income> emr_income { get; set; }
        public virtual ICollection<emr_vital> emr_vital { get; set; }
        public virtual ICollection<ipd_admission> ipd_admission { get; set; }

        public virtual ICollection<ipd_admission> ipd_admission1 { get; set; }
        public virtual ICollection<ipd_admission> ipd_admission2 { get; set; }
        public virtual ICollection<ipd_admission> ipd_admission3 { get; set; }
        public virtual ICollection<ipd_admission_imaging> ipd_admission_imaging { get; set; }
        public virtual ICollection<ipd_admission_imaging> ipd_admission_imaging1 { get; set; }
        public virtual ICollection<ipd_admission_imaging> ipd_admission_imaging2 { get; set; }
        public virtual ICollection<ipd_admission_lab> ipd_admission_lab { get; set; }
        public virtual ICollection<ipd_admission_lab> ipd_admission_lab1 { get; set; }
        public virtual ICollection<ipd_admission_lab> ipd_admission_lab2 { get; set; }
        public virtual ICollection<ipd_procedure_mf> ipd_procedure_mf { get; set; }
    }
}
