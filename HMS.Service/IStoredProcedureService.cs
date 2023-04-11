#region
using System.Collections.Generic;
using HMS.Entities.CustomModel;

#endregion

namespace HMS.Service
{
    public interface IStoredProcedureService
    {
        IEnumerable<ScreenModel> GetAllScreen();
        IEnumerable<TemplateModel> GetAlLTemplate(decimal CompanyID);
    }
}