using HMS.Entities.CustomModel;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public interface IERPStoredProcedures
    {
        IEnumerable<ScreenModel> GetAllScreen();
        IEnumerable<TemplateModel> GetAlLTemplate(decimal CompanyID);
        
    }
}