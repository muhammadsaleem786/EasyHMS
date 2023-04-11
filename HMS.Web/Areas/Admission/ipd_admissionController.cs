using HMS.Entities.CustomModel;
using HMS.Entities.Enum;
using HMS.Entities.Models;
using HMS.Service.Services.Admin;
using HMS.Service.Services.Admission;
using HMS.Service.Services.Appointment;
using HMS.Web.API.Common;
using HMS.Web.API.Filters;
using HMS.Web.API.Interface;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HMS.Web.API.Areas.Appointment.Controllers
{
    [JwtAuthentication]
    public class ipd_admissionController : ApiController, IERPAPIInterface<ipd_admission>, IDisposable
    {
        private readonly Iipd_admissionService _service;
        private readonly Iemr_appointment_mfService _emr_appointment_mfService;
        private readonly Isys_drop_down_valueService _sys_drop_down_valueService;
        private readonly Iemr_patient_billService _emr_patient_billService;
        private readonly Iemr_bill_typeService _emr_bill_typeService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ipd_admissionController(IUnitOfWorkAsync unitOfWorkAsync, Iemr_bill_typeService emr_bill_typeService, Iemr_patient_billService emr_patient_billService, Iipd_admissionService service, Iemr_appointment_mfService emr_appointment_mfService,
            Isys_drop_down_valueService sys_drop_down_valueService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _service = service;
            _sys_drop_down_valueService = sys_drop_down_valueService;
            _emr_appointment_mfService = emr_appointment_mfService;
            _emr_patient_billService = emr_patient_billService;
            _emr_bill_typeService = emr_bill_typeService;
        }
        [HttpPost]
        [HttpGet]
        [ActionName("Save")]
        public async Task<ResponseInfo> Save(ipd_admission Model)
        {
            var objResponse = new ResponseInfo();
            try
            {
                if (!ModelState.IsValid)
                {
                    objResponse.IsSuccess = false;
                    objResponse.ErrorMessage = MessageStatement.BadRequest;
                    return objResponse;
                }
                decimal CompanyID = Request.CompanyID();
                decimal UserID = Request.LoginID();
                decimal ID = 1;
                if (_service.Queryable().Count() > 0)
                    ID = _service.Queryable().Max(e => e.ID) + 1;
                Model.ID = ID;
                var date = DateTime.Now.ToString("MMddyyyy");
                Model.AdmissionNo = "IP-" + date + "-" + Model.AdmissionNo;
                Model.AdmissionTypeDropdownId = (int)sys_dropdown_mfEnum.AdmissionTypeDropdownId;
                if (Model.WardTypeId != null)
                {
                    Model.WardTypeDropdownId = (int)sys_dropdown_mfEnum.WardTypeDropdownId;
                }
                if (Model.BedId != null)
                {
                    Model.BedDropdownId = (int)sys_dropdown_mfEnum.BedDropdownId;
                }
                if (Model.RoomId != null)
                {
                    Model.RoomDropdownId = (int)sys_dropdown_mfEnum.RoomDropdownId;
                }
                Model.CompanyId = Request.CompanyID();
                Model.CreatedBy = Request.LoginID();
                Model.CreatedDate = Request.DateTimes();
                Model.ModifiedBy = Request.LoginID();
                Model.ModifiedDate = Request.DateTimes();
                Model.ObjectState = ObjectState.Added;
                _service.Insert(Model);

                decimal AppID = 1;
                var findAppointment = _emr_appointment_mfService.Queryable().Where(a => a.CompanyId == CompanyID && a.PatientId == Model.PatientId && DbFunctions.TruncateTime(a.AppointmentDate) == DbFunctions.TruncateTime(Model.AdmissionDate)).FirstOrDefault();
                if (findAppointment == null)
                {
                    emr_appointment_mf appoint = new emr_appointment_mf();
                    if (_emr_appointment_mfService.Queryable().Count() > 0)
                        AppID = _emr_appointment_mfService.Queryable().Max(e => e.ID) + 1;
                    appoint.ID = AppID;
                    appoint.AdmissionId = Model.ID;
                    appoint.PatientId = Model.PatientId;
                    appoint.DoctorId = Model.DoctorId;
                    appoint.AppointmentDate = Model.AdmissionDate;
                    appoint.AppointmentTime = Model.AdmissionTime;
                    appoint.IsAdmit = true;
                    appoint.StatusId = 25;
                    appoint.IsAdmission = true;
                    appoint.TokenNo = 1;
                    appoint.CompanyId = Request.CompanyID();
                    appoint.CreatedBy = Request.LoginID();
                    appoint.CreatedDate = Request.DateTimes();
                    appoint.ModifiedBy = Request.LoginID();
                    appoint.ModifiedDate = Request.DateTimes();
                    appoint.ObjectState = ObjectState.Added;
                    _emr_appointment_mfService.Insert(appoint);
                }

                var findService = _emr_bill_typeService.Queryable().Where(a => a.CompanyId == CompanyID && a.ServiceName == "InPatient").FirstOrDefault();

                decimal billID = 1;
                if (_emr_patient_billService.Queryable().Count() > 0)
                    billID = _emr_patient_billService.Queryable().Max(e => e.ID) + 1;
                emr_patient_bill billObj = new emr_patient_bill();
                billObj.ID = billID;
                if (findAppointment != null)
                    billObj.AppointmentId = findAppointment.ID;
                else
                    billObj.AppointmentId = AppID;
                billObj.AdmissionId = Model.ID;
                billObj.PatientId = Model.PatientId;
                billObj.DoctorId = Model.DoctorId;
                billObj.BillDate = DateTime.Now;
                billObj.ServiceId = findService.ID;
                billObj.Price =0;
                billObj.Discount = 0;
                billObj.PaidAmount = 0;
                billObj.OutstandingBalance = 0;
                billObj.CompanyId = Request.CompanyID();
                billObj.CreatedBy = Request.LoginID();
                billObj.CreatedDate = Request.DateTimes();
                billObj.ModifiedBy = Request.LoginID();
                billObj.ModifiedDate = Request.DateTimes();
                billObj.ObjectState = ObjectState.Added;
                _emr_patient_billService.Insert(billObj);

                try
                {
                    await _unitOfWorkAsync.SaveChangesAsync();
                    objResponse.Message = MessageStatement.Save;
                    objResponse.IsSuccess = true;


                }
                catch (DbUpdateException)
                {
                    if (ModelExists(Model.ID.ToString()))
                    {
                        objResponse.IsSuccess = false;
                        objResponse.ErrorMessage = MessageStatement.Conflict;
                        return objResponse;
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        [HttpPut]
        [HttpGet]
        [ActionName("Update")]
        public async Task<ResponseInfo> Update(ipd_admission Model)
        {
            var objResponse = new ResponseInfo();
            try
            {
                if (!ModelState.IsValid)
                {
                    objResponse.IsSuccess = false;
                    objResponse.ErrorMessage = MessageStatement.BadRequest;
                    return objResponse;
                }
                Model.ModifiedBy = Request.LoginID();
                Model.ModifiedDate = Request.DateTimes();
                if (Model.WardTypeId != null)
                {
                    Model.WardTypeDropdownId = (int)sys_dropdown_mfEnum.WardTypeDropdownId;
                }
                if (Model.BedId != null)
                {
                    Model.BedDropdownId = (int)sys_dropdown_mfEnum.BedDropdownId;
                }
                if (Model.RoomId != null)
                {
                    Model.RoomDropdownId = (int)sys_dropdown_mfEnum.RoomDropdownId;
                }
                Model.ObjectState = ObjectState.Modified;
                _service.Update(Model);

                try
                {
                    await _unitOfWorkAsync.SaveChangesAsync();
                    objResponse.Message = MessageStatement.Update;
                    objResponse.IsSuccess = true;
                }
                catch (DbUpdateException)
                {
                    if (!ModelExists(Model.ID.ToString()))
                    {
                        objResponse.IsSuccess = false;
                        objResponse.ErrorMessage = MessageStatement.NotFound;
                        return objResponse;
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }

        [HttpGet]
        [ActionName("GetList")]
        public ResponseInfo GetList()
        {
            var objResponse = new ResponseInfo();
            try
            {
                decimal CompanyID = Request.CompanyID();
                var GenderType = _sys_drop_down_valueService.Queryable().Where(e => e.DropDownID == 2).ToList();
                objResponse.ResultSet = new
                {
                    GenderList = GenderType
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        private bool ModelExists(string key)
        {
            return _service.Query(e => e.ID.ToString() == key).Select().Any();
        }
        [HttpGet]
        [ActionName("GetById")]
        public ResponseInfo GetById(string Id)
        {
            var objResponse = new ResponseInfo();
            try
            {
                decimal CompanyID = Request.CompanyID();
                int ID = Convert.ToInt32(Id);
                var obj = _service.Queryable().Where(a => a.CompanyId == CompanyID && a.ID == ID).Include(a => a.emr_patient_mf).FirstOrDefault();
                objResponse.IsSuccess = true;
                objResponse.ResultSet = new
                {
                    obj = obj,
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        public ResponseInfo GetById(string Id, int NextPreviousIndex)
        {
            var objResponse = new ResponseInfo();
            try
            {
                var CompanyID = Request.CompanyID();
                objResponse.ResultSet = _service.Queryable().Where(e => e.ID.ToString() == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        [HttpGet]
        [ActionName("Pagination")]
        public PaginationResult Pagination(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            var objResult = new PaginationResult();
            try
            {
                decimal CompanyID = Request.CompanyID();
                objResult = _service.Pagination(CompanyID, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging);
            }
            catch (Exception ex)
            {
                Logger.Trace.Error(ex);
            }
            return objResult;
        }
        [HttpGet]
        [ActionName("ExportData")]
        public ResponseInfo ExportData(int ExportType, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText)
        {
            var objResponse = new ResponseInfo();
            try
            {
                var ObjList = Pagination(0, 0, VisibleColumnInfo, SortName, SortOrder, SearchText, true);
                objResponse.FilePath = Documents.ExportWithType(ExportType, VisibleColumnInfo, ObjList.DataList);

            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ResponseInfo> Delete(string Id, string VitalId)
        {
            var objResponse = new ResponseInfo();
            try
            {
                decimal CompanyID = Request.CompanyID();
                decimal ID = Convert.ToDecimal(Id);
                ipd_admission model = _service.Queryable().Where(e => e.CompanyId == CompanyID && e.ID == ID).FirstOrDefault();

                if (model == null)
                {
                    objResponse.IsSuccess = false;
                    objResponse.ErrorMessage = MessageStatement.NotFound;
                    return objResponse;
                }

                model.ObjectState = ObjectState.Deleted;
                _service.Delete(model);
                await _unitOfWorkAsync.SaveChangesAsync();
                objResponse.Message = MessageStatement.Delete;

            }
            catch (Exception ex)
            {
                string Message = "";
                objResponse.IsSuccess = false;

                if (ex.InnerException == null)
                    Message = ex.Message;
                else if (ex.InnerException.InnerException == null)
                    Message = ex.InnerException.Message;
                else
                    Message = ex.InnerException.InnerException.Message;

                if (Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    Message = MessageStatement.RelationExists;

                objResponse.ErrorMessage = Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        [ActionName("Load")]
        public ResponseInfo Load()
        {
            var objResponse = new ResponseInfo();
            try
            {
                decimal CompanyID = Request.CompanyID();
                int userid = Convert.ToInt32(Request.LoginID());
                DataAccessManager dataAccessManager = new DataAccessManager();
                var ht = new Hashtable();
                ht.Add("@CompanyID", CompanyID);
                ht.Add("@UserId", userid);
                var AllData = dataAccessManager.GetDataSet("SP_LoadDropdown", ht);
                var GenderType = AllData.Tables[0];
                var BloodList = AllData.Tables[6];
                var StatusList = AllData.Tables[10];

                var BillTypeList = AllData.Tables[11];

                var TittleList = AllData.Tables[12];
                var AdmissionTypeList = AllData.Tables[15];
                var AdmissionLocation = AllData.Tables[16];

                var DoctorList = AllData.Tables[1];
                decimal[] IdList = null;
                var isShowIds = AllData.Tables[2].Rows[0]["IsShowDoctorIds"].ToString();
                if (isShowIds != "")
                    IdList = isShowIds.Split(',').Select(decimal.Parse).ToArray();
                var DoctorCalander = AllData.Tables[3];
                var AdmissionNo = AllData.Tables[13].Rows[0]["AdmissionNo"].ToString();

                decimal getMaxMRNO = Convert.ToDecimal(AllData.Tables[14].Rows[0]["MRNO"].ToString());
                string MRNO = "";
                MRNO = (getMaxMRNO).ToString("0000000000");

                objResponse.ResultSet = new
                {
                    MRNO = MRNO,
                    GenderList = GenderType,
                    AdmissionNo = AdmissionNo,
                    DoctorList = DoctorList,
                    AllStatusList = StatusList,
                    BloodList = BloodList,
                    DoctorCalander = DoctorCalander,
                    BillTypeList = BillTypeList,
                    TittleList = TittleList,
                    AdmissionTypeList = AdmissionTypeList,
                    AdmissionLocation = AdmissionLocation,
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        [HttpGet]
        [ActionName("WardDropDown")]
        public ResponseInfo WardDropDown(string Id)
        {
            var objResponse = new ResponseInfo();
            try
            {
                decimal CompanyID = Request.CompanyID();
                decimal UserID = Request.LoginID();
                int ID = Convert.ToInt32(Id);
                var obj = _service.Queryable().Where(a => a.CompanyId == CompanyID && a.ID == ID).Include(a => a.emr_patient_mf).FirstOrDefault();

                DataAccessManager dataAccessManager = new DataAccessManager();
                var ht = new Hashtable();
                ht.Add("@CompanyID", CompanyID);
                ht.Add("@UserId", UserID);
                var AllData = dataAccessManager.GetDataSet("SP_LoadDropdown", ht);


                var WardList = AllData.Tables[21];
                var RoomList = AllData.Tables[22];
                var BedList = AllData.Tables[23];


                objResponse.ResultSet = new
                {
                    RoomList = RoomList,
                    WardList = WardList,
                    BedList = BedList,
                    obj = obj,
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
        public Task<ResponseInfo> Delete(string Id)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [HttpGet]
        [ActionName("DischargePatient")]
        public async Task<ResponseInfo> DischargePatient(string Id)
        {
            var objResponse = new ResponseInfo();
            try
            {
                if (!ModelState.IsValid)
                {
                    objResponse.IsSuccess = false;
                    objResponse.ErrorMessage = MessageStatement.BadRequest;
                    return objResponse;
                }
                decimal ID = Convert.ToDecimal(Id);
                decimal CompanyID = Request.CompanyID();
                var findIPD = _service.Queryable().Where(a => a.ID == ID && a.CompanyId == CompanyID).FirstOrDefault();
                if (findIPD != null)
                {
                    findIPD.DischargeDate = DateTime.Now;
                    _service.Update(findIPD);
                }
                DataAccessManager dataAccessManager = new DataAccessManager();
                var ht = new Hashtable();
                ht.Add("@CompanyId", CompanyID);
                ht.Add("@AdmissionId", ID);
                ht.Add("@PatientId", findIPD.PatientId);
                var AllData = dataAccessManager.GetDataSet("SP_OnDischargeUpdateBillAmount", ht);

                try
                {
                    await _unitOfWorkAsync.SaveChangesAsync();
                    objResponse.Message = MessageStatement.Update;
                    objResponse.IsSuccess = true;
                }
                catch (DbUpdateException)
                {
                    if (!ModelExists(findIPD.ID.ToString()))
                    {
                        objResponse.IsSuccess = false;
                        objResponse.ErrorMessage = MessageStatement.NotFound;
                        return objResponse;
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
                Logger.Trace.Error(ex);
            }
            return objResponse;
        }
    }
}
