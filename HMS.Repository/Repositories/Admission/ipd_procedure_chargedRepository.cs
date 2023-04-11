﻿using HMS.Entities.CustomModel;
using HMS.Entities.Models;
using HMS.Repository.Common;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Repositories.Admission
{
    public static class ipd_procedure_chargedRepository
    {
        public static PaginationResult Pagination(this IRepository<ipd_procedure_charged> repository, decimal ID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            var objResult = new PaginationResult();
            try
            {
                var PFilter = Utility.SetPaginationFilter(CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText);
                Expression<Func<ipd_procedure_charged, bool>> predicate = (e => e.CompanyId == ID);

                bool DisplayName, DisplayUserName, DisplayPhoneNo, DisplayEmail;
                bool OrderByName, OrderByUserName, OrderByPhoneNo, OrderByEmail;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }

    }
}
