﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models.Mapping
{
    public class emr_prescription_treatmentMap : EntityTypeConfiguration<emr_prescription_treatment>
    {
        public emr_prescription_treatmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.CompanyID });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MedicineName)
                .IsRequired()
                .HasMaxLength(250);
            this.Property(t => t.Measure)
                .HasMaxLength(50);

            this.Property(t => t.Instructions)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("emr_prescription_treatment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.MedicineName).HasColumnName("MedicineName");
            this.Property(t => t.MedicineId).HasColumnName("MedicineId");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.PrescriptionId).HasColumnName("PrescriptionId");
            this.Property(t => t.PatientId).HasColumnName("PatientId");
            this.Property(t => t.Measure).HasColumnName("Measure");
            this.Property(t => t.IsMorning).HasColumnName("IsMorning");
            this.Property(t => t.IsEvening).HasColumnName("IsEvening");
            this.Property(t => t.IsSOS).HasColumnName("IsSOS");
            this.Property(t => t.IsNoon).HasColumnName("IsNoon");
            this.Property(t => t.Instructions).HasColumnName("Instructions");
            this.Property(t => t.InstructionId).HasColumnName("InstructionId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            // Relationships
            this.HasRequired(t => t.adm_company)
                .WithMany(t => t.emr_prescription_treatment)
                .HasForeignKey(d => d.CompanyID);
            this.HasRequired(t => t.adm_user_mf)
                .WithMany(t => t.emr_prescription_treatment)
                .HasForeignKey(d => d.CreatedBy);
            this.HasRequired(t => t.adm_user_mf1)
                .WithMany(t => t.emr_prescription_treatment1)
                .HasForeignKey(d => d.ModifiedBy);
            this.HasRequired(t => t.emr_prescription_mf)
                .WithMany(t => t.emr_prescription_treatment)
                .HasForeignKey(d => new { d.PrescriptionId, d.CompanyID });
        }
    }
}
