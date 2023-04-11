﻿using HMS.Entities.CustomModel;
using HMS.Entities.Models;
using HMS.Repository.Repositories.Admission;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.Admission
{
    public interface Iipd_admission_imagingService : IService<ipd_admission_imaging>
    {
        PaginationResult Pagination(decimal CompanyID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText,string AdmitId,string PatientId, bool IgnorePaging = false);

    }

    public class ipd_admission_imagingService : Service<ipd_admission_imaging>, Iipd_admission_imagingService
    {
        private readonly IRepositoryAsync<ipd_admission_imaging> _repository;
        public ipd_admission_imagingService(IRepositoryAsync<ipd_admission_imaging> repository) : base(repository)
        {
            _repository = repository;
        }

        public PaginationResult Pagination(decimal CompanyID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText,string AdmitId,string PatientId, bool IgnorePaging = false)
        {
            return _repository.Pagination(CompanyID, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, AdmitId, PatientId, IgnorePaging);
        }
    }
}
