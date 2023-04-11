﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models.Mapping
{
    public class emr_prescription_treatment_templateMap : EntityTypeConfiguration<emr_prescription_treatment_template>
    {
        public emr_prescription_treatment_templateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.CompanyID });
            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(t => t.TemplateName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("emr_prescription_treatment_template");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.TemplateName).HasColumnName("TemplateName");
            this.Property(t => t.PrescriptionId).HasColumnName("PrescriptionId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            // Relationships
            this.HasRequired(t => t.adm_company)
                .WithMany(t => t.emr_prescription_treatment_template)
                .HasForeignKey(d => d.CompanyID);
            this.HasRequired(t => t.adm_user_mf)
                .WithMany(t => t.emr_prescription_treatment_template)
                .HasForeignKey(d => d.CreatedBy);
            this.HasRequired(t => t.adm_user_mf1)
                .WithMany(t => t.emr_prescription_treatment_template1)
                .HasForeignKey(d => d.ModifiedBy);
            this.HasRequired(t => t.emr_prescription_mf)
                .WithMany(t => t.emr_prescription_treatment_template)
                .HasForeignKey(d => new { d.PrescriptionId, d.CompanyID });
        }
    }
}
