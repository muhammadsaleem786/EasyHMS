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
    public static class emr_instructionRepository
    {
        public static PaginationResult Pagination(this IRepository<emr_instruction> repository, decimal ID, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            var objResult = new PaginationResult();
            try
            {
                var PFilter = Utility.SetPaginationFilter(CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText);
                Expression<Func<emr_instruction, bool>> predicate = (e => e.CompanyID == ID);
                bool DisplayName;
                bool OrderByName;
                if (!string.IsNullOrEmpty(PFilter.SearchText))
                {
                    DisplayName = PFilter.VisibleColumnInfoList.IndexOf("Instructions") > -1;
                    predicate = (c =>
                    (DisplayName && c.Instructions.ToLower().Contains(PFilter.SearchText.ToLower()
                    )));
                }
                IQueryable<emr_instruction> filteredData = repository.Queryable().Where(predicate);

                if (string.IsNullOrEmpty(PFilter.OrderBy))
                    PFilter.OrderBy = "Id";
                OrderByName = PFilter.OrderBy.IndexOf("Instructions") > -1;

                Expression<Func<emr_instruction, string>> orderingFunction = (c =>
                                                              OrderByName ? c.Instructions : ""
                                                              );

                if (PFilter.IsOrderAsc)
                    filteredData = filteredData.OrderBy(orderingFunction);
                else
                    filteredData = filteredData.OrderByDescending(orderingFunction);

                objResult.TotalRecord = filteredData.Count();

                if (IgnorePaging)
                {
                    objResult.DataList = filteredData
                        .Select(s => new
                        {
                            ID = s.Id,
                            Instructions = s.Instructions,
                        }).OrderByDescending(a => a.ID).ToList<object>();
                }
                else
                {

                    objResult.DataList = filteredData.Skip(PFilter.SkipRecord).Take(PFilter.TakeRecord)
                       .Select(s => new
                       {
                          ID= s.Id,
                           Instructions = s.Instructions,
                       }).OrderByDescending(a => a.ID).ToList<object>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }
    }
}
