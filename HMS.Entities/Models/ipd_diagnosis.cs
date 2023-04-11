﻿using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class ipd_diagnosis : Entity
    {
        public decimal Id { get; set; }
        public decimal CompanyID { get; set; }
        public decimal AdmissionId { get; set; }
        [NotMapped]
        public decimal PatientId { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string IsType { get; set; }
        public bool IsVisitType { get; set; }
        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public decimal ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ipd_admission ipd_admission { get; set; }
        public virtual adm_company adm_company { get; set; }
        public virtual adm_user_mf adm_user_mf { get; set; }
        public virtual adm_user_mf adm_user_mf1 { get; set; }
    }
}
