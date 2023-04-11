﻿using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class ipd_admission_imaging:Entity
    {
        public decimal ID { get; set; }
        public decimal CompanyId { get; set; }
        public decimal AdmissionId { get; set; }
        public decimal AppointmentId { get; set; }
        public decimal PatientId { get; set; }
        public int ImagingTypeId { get; set; }
        public int ImagingTypeDropdownId { get; set; }
        public string Notes { get; set; }
        public int StatusId { get; set; }
        public int StatusDropdownId { get; set; }
        public int ResultId { get; set; }
        public int ResultDropdownId { get; set; }
        public string Image { get; set; }
        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<decimal> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual adm_company adm_company { get; set; }
        public virtual adm_user_mf adm_user_mf { get; set; }
        public virtual adm_user_mf adm_user_mf1 { get; set; }
        public virtual emr_appointment_mf emr_appointment_mf { get; set; }
        public virtual ipd_admission ipd_admission { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value1 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value2 { get; set; }
    }
}
