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
    public interface Iipd_admission_notesService : IService<ipd_admission_notes>
    {
        PaginationResult Pagination(decimal CompanyID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText,string AdmitId, string PatientId, string Appointmentid, bool IgnorePaging = false);

    }

    public class ipd_admission_notesService : Service<ipd_admission_notes>, Iipd_admission_notesService
    {
        private readonly IRepositoryAsync<ipd_admission_notes> _repository;
        public ipd_admission_notesService(IRepositoryAsync<ipd_admission_notes> repository) : base(repository)
        {
            _repository = repository;
        }

        public PaginationResult Pagination(decimal CompanyID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText,string AdmitId, string PatientId, string Appointmentid, bool IgnorePaging = false)
        {
            return _repository.Pagination(CompanyID, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, AdmitId, PatientId, Appointmentid, IgnorePaging);
        }
    }
}
