#region

using HMS.Entities.CustomModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

#endregion

namespace HMS.Entities.Models
{
    public partial class HMSContext : IERPStoredProcedures
    {
        public IEnumerable<ScreenModel> GetAllScreen()
        {
            return Database.SqlQuery<ScreenModel>("SP_Adm_GetAllScreen");
        }
        public IEnumerable<TemplateModel> GetAlLTemplate(decimal CompanyID)
        {
            var CompanyIDParameter = new SqlParameter("@CompanyId", CompanyID);
            return Database.SqlQuery<TemplateModel>("LoadTemplate @CompanyId", CompanyIDParameter);
        }

    }
}