using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class emr_prescription_treatment:Entity
    {
        public decimal Id { get; set; }
        public decimal CompanyID { get; set; }
        public decimal PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public Nullable<decimal> MedicineId { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<decimal> PatientId { get; set; }
        public string Measure { get; set; }
        public bool IsMorning { get; set; }
        public bool IsEvening { get; set; }
        public bool IsSOS { get; set; }
        public bool IsNoon { get; set; }
        public string Instructions { get; set; }
        public Nullable<decimal> InstructionId { get; set; }
        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public decimal ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual adm_company adm_company { get; set; }
        public virtual adm_user_mf adm_user_mf { get; set; }
        public virtual adm_user_mf adm_user_mf1 { get; set; }
        public virtual emr_prescription_mf emr_prescription_mf { get; set; }
    }
}
