using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class emr_bill_type:Entity
    {
        public emr_bill_type()
        {
            this.emr_patient_bill = new List<emr_patient_bill>();
        }

        public decimal ID { get; set; }
        public decimal CompanyId { get; set; }
        public string ServiceName { get; set; }
        public bool IsItem { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsSystemGenerated { get; set; }
        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<decimal> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual adm_company adm_company { get; set; }
        public virtual adm_user_mf adm_user_mf { get; set; }
        public virtual adm_user_mf adm_user_mf1 { get; set; }
        public virtual ICollection<emr_patient_bill> emr_patient_bill { get; set; }
    }
}
