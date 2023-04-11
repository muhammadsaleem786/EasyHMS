using System.Collections.Generic;
using System;
using HMS.Entities.Models;
using HMS.Entities.CustomModel;

namespace HMS.Service
{
    public class StoredProcedureService : IStoredProcedureService
    {
        private readonly IERPStoredProcedures _storedProcedures;

        public StoredProcedureService(IERPStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }
        public IEnumerable<ScreenModel> GetAllScreen()
        {
            return _storedProcedures.GetAllScreen();
        }
        public IEnumerable<TemplateModel> GetAlLTemplate(decimal CompanyID)
        {
            return _storedProcedures.GetAlLTemplate(CompanyID);
        }
    }
}