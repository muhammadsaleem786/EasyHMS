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

namespace HMS.Repository.Repositories.Appointment
{
    public static class emr_prescription_treatment_templateRepository
    {
        public static PaginationResult Pagination(this IRepository<emr_prescription_treatment_template> repository, decimal ID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            var objResult = new PaginationResult();
            try
            {
                var PFilter = Utility.SetPaginationFilter(CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText);
                Expression<Func<emr_prescription_treatment_template, bool>> predicate = (e => e.CompanyID == ID);

                bool DisplayName, DisplayUserName, DisplayPhoneNo, DisplayEmail;
                bool OrderByName, OrderByUserName, OrderByPhoneNo, OrderByEmail;


                //if (!string.IsNullOrEmpty(PFilter.SearchText))
                //{
                //    DisplayName = PFilter.VisibleColumnInfoList.IndexOf("Name") > -1;
                //    //DisplayUserName = PFilter.VisibleColumnInfoList.IndexOf("UserName") > -1;
                //    DisplayPhoneNo = PFilter.VisibleColumnInfoList.IndexOf("PhoneNo") > -1;
                //    DisplayEmail = PFilter.VisibleColumnInfoList.IndexOf("Email") > -1;
                //    predicate = (c =>
                //    (DisplayName && c.Name.ToLower().Contains(PFilter.SearchText.ToLower()) ||
                //    (DisplayEmail && c.Email.ToLower().Contains(PFilter.SearchText.ToLower())

                //    //
                //    )));
                //}

                //IQueryable<adm_user> filteredData = repository.Queryable().Where(predicate);

                ////if (string.IsNullOrEmpty(PFilter.OrderBy))
                ////    PFilter.OrderBy = "TaxCode";

                //OrderByName = PFilter.OrderBy.IndexOf("Name") > -1;
                ////OrderByUserName = PFilter.OrderBy.IndexOf("UserName") > -1;
                //OrderByPhoneNo = PFilter.OrderBy.IndexOf("PhoneNo") > -1;
                //OrderByEmail = PFilter.OrderBy.IndexOf("Email") > -1;

                //Expression<Func<adm_user, string>> orderingFunction = (c =>
                //                                              OrderByName ? c.Name :
                //                                              OrderByEmail ? c.Email : ""
                //                                              );

                //if (PFilter.IsOrderAsc)
                //    filteredData = filteredData.OrderBy(orderingFunction);
                //else
                //    filteredData = filteredData.OrderByDescending(orderingFunction);

                //objResult.TotalRecord = filteredData.Count();

                //if (IgnorePaging)
                //    objResult.DataList = (from c in filteredData select c).ToList<object>();
                //else
                //{
                //    var PageResult = filteredData.Skip(PFilter.SkipRecord).Take(PFilter.TakeRecord);
                //    objResult.DataList = (from c in PageResult select c).ToList<object>();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }
    }
}
