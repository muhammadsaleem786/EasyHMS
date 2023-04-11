(window.webpackJsonp=window.webpackJsonp||[]).push([[2],{"/8k+":function(t,n,e){"use strict";e.d(n,"a",function(){return r});var i=e("hFUk"),r=(e("ZEy1"),function(){function t(t){this.http=t,this.DocurlToApi=i.b.BASE_Api_URL+"/api/Appointment/emr_document",this.urlToApi=i.b.BASE_Api_URL+"/api/Appointment/emr_patient",this.urlToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_appointment_mf",this.MediurlToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_medicine",this.PresurlToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_prescription_mf",this.BillToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_patient_bill",this.VitalToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_vital",this.favoriteToApiAp=i.b.BASE_Api_URL+"/api/Appointment/emr_notes_favorite"}return t.prototype.GetPatientList=function(t,n,e,i,r,o,u,p){return this.http.Get(this.urlToApiAp+"/AppointList",{date:t,StatusId:n,CurrentPageNo:e,RecordPerPage:i,VisibleColumnInfo:r,SortName:o,SortOrder:u,SearchText:p,IgnorePaging:!1}).then(function(t){return t})},t.prototype.GetUpdatePatientList=function(t,n,e,i,r,o,u,p){return this.http.Get(this.urlToApiAp+"/UpdateAppointList",{date:t,StatusId:n,CurrentPageNo:e,RecordPerPage:i,VisibleColumnInfo:r,SortName:o,SortOrder:u,SearchText:p,IgnorePaging:!1}).then(function(t){return t})},t.prototype.GetList=function(){return this.http.Get(this.urlToApi+"/GetList",{}).then(function(t){return t})},t.prototype.ExportData=function(t,n,e,r,o,u,p){var l=this;return this.http.Get(this.urlToApi+"/ExportData",{ExportType:t,CurrentPageNo:n,RecordPerPage:e,VisibleColumnInfo:r,SortName:o,SortOrder:u,SearchText:p,IgnorePaging:!0}).then(function(t){return""!=t.FilePath&&l.http.ExportDataDownload(i.b.BASE_Api_URL,t.FilePath),t})},t.prototype.DocDownload=function(t){""!=t&&this.http.ExportDataDownload(i.b.BASE_Api_URL,t)},t.prototype.GetById=function(t){return this.http.Get(this.urlToApi+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.GetDocById=function(t){return this.http.Get(this.DocurlToApi+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.IsPhoneExist=function(t){return this.http.Get(this.urlToApi+"/IsPhoneExist",{Phone:t}).then(function(t){return t})},t.prototype.SaveOrUpdate=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.urlToApi+"/Save",t).then(function(t){return t}):this.http.Put(this.urlToApi+"/Update",t).then(function(t){return t})},t.prototype.SaveOrUpdatebill=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.BillToApiAp+"/Save",t).then(function(t){return t}):this.http.Put(this.BillToApiAp+"/Update",t).then(function(t){return t})},t.prototype.UpdateAppointment=function(t){return this.http.Put(this.urlToApiAp+"/UpdateAppointment",t).then(function(t){return t})},t.prototype.AppSaveOrUpdate=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.urlToApiAp+"/Save",t).then(function(t){return t}):this.http.Put(this.urlToApiAp+"/Update",t).then(function(t){return t})},t.prototype.GetAdmitAppointmentDropdown=function(t){return this.http.Get(this.urlToApiAp+"/GetAdmitAppointmentDropdown",{PatientId:t})},t.prototype.GetEMRNO=function(){return this.http.Get(this.urlToApi+"/GetEMRNO",{}).then(function(t){return t})},t.prototype.PatientInfo=function(t){return this.http.Post(this.urlToApi+"/PatientInfo",t).then(function(t){return t})},t.prototype.searchMedicine=function(t){return this.http.Get(this.MediurlToApiAp+"/searchMedicine",{term:t}).then(function(t){return t})},t.prototype.GetPatient=function(){return this.http.Get(this.urlToApi+"/GetPatient",{})},t.prototype.ComplaintSearch=function(t){return this.http.Get(this.PresurlToApiAp+"/ComplaintSearch",{term:t}).then(function(t){return t})},t.prototype.ServiceSearch=function(t){return this.http.Get(this.BillToApiAp+"/ServiceSearch",{term:t}).then(function(t){return t})},t.prototype.AllComplaint=function(){return this.http.Get(this.PresurlToApiAp+"/ComplaintList",{}).then(function(t){return t})},t.prototype.AllInvestigation=function(){return this.http.Get(this.PresurlToApiAp+"/InvestigationList",{}).then(function(t){return t})},t.prototype.AllObservation=function(){return this.http.Get(this.PresurlToApiAp+"/ObservationList",{}).then(function(t){return t})},t.prototype.AllDiagnosis=function(){return this.http.Get(this.PresurlToApiAp+"/DiagnosisList",{}).then(function(t){return t})},t.prototype.DiagnosSearch=function(t){return this.http.Get(this.PresurlToApiAp+"/DiagnosSearch",{term:t}).then(function(t){return t})},t.prototype.InstructionSearch=function(t){return this.http.Get(this.PresurlToApiAp+"/InstructionSearch",{term:t}).then(function(t){return t})},t.prototype.ObservationSearch=function(t){return this.http.Get(this.PresurlToApiAp+"/ObservationSearch",{term:t}).then(function(t){return t})},t.prototype.InvestigationSearch=function(t){return this.http.Get(this.PresurlToApiAp+"/InvestigationSearch",{term:t}).then(function(t){return t})},t.prototype.DoctorSearch=function(t){return this.http.Get(this.urlToApi+"/DoctorSearch",{term:t}).then(function(t){return t})},t.prototype.searchByName=function(t){return this.http.Get(this.urlToApi+"/searchByName",{term:t}).then(function(t){return t})},t.prototype.Delete=function(t){return this.http.Delete(this.urlToApi+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.DeleteDoc=function(t){return this.http.Delete(this.DocurlToApi+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.DownloadDoc=function(t){return this.http.Delete(this.DocurlToApi+"/DownloadDoc",{Id:t}).then(function(t){return t})},t.prototype.DeleteAppoint=function(t){return this.http.Delete(this.urlToApiAp+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.PatientInfoLoad=function(t,n,e){return this.http.Get(this.urlToApiAp+"/PatientInfoLoad",{id:t,Date:n,AppId:e}).then(function(t){return t})},t.prototype.PatientLoadById=function(t){return this.http.Get(this.urlToApiAp+"/PatientLoadById",{id:t}).then(function(t){return t})},t.prototype.AdmitPatientLoadById=function(t,n){return this.http.Get(this.urlToApiAp+"/AdmitPatientLoadById",{id:t,AdmitId:n}).then(function(t){return t})},t.prototype.PatientAppointmentLoad=function(t){return this.http.Get(this.urlToApiAp+"/PatientAppointmentLoad",{id:t}).then(function(t){return t})},t.prototype.FormLoad=function(t,n){return this.http.Get(this.urlToApi+"/LoadData",{date:t,StatusId:n}).then(function(t){return t})},t.prototype.DropdownFilterData=function(t,n){return this.http.Get(this.urlToApi+"/DropdownFilterData",{date:t,StatusId:n}).then(function(t){return t})},t.prototype.MonthLoadData=function(t,n,e){return this.http.Get(this.urlToApi+"/MonthLoadData",{fdate:t,tdate:n,StatusId:e}).then(function(t){return t})},t.prototype.GetAllScreens=function(){return this.http.Get(this.urlToApi+"/GetAllScreens",{}).then(function(t){return t})},t.prototype.GetAllDoctorList=function(){return this.http.Get(this.urlToApi+"/DoctorList",{}).then(function(t){return t})},t.prototype.UserSave=function(t){return this.http.Post(this.urlToApiAp+"/UserSave",t).then(function(t){return t})},t.prototype.GetDocmentType=function(){return this.http.Get(this.DocurlToApi+"/Load",{})},t.prototype.GetDocList=function(t,n,e,i,r,o){return this.http.Get(this.DocurlToApi+"/Pagination",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,IgnorePaging:!1}).then(function(t){return t})},t.prototype.GetBillingList=function(t,n,e,i,r,o,u){return this.http.Get(this.BillToApiAp+"/BillingPagination",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,PatientId:u,IgnorePaging:!1}).then(function(t){return t})},t.prototype.GetPreviousList=function(t,n,e,i,r,o,u){return this.http.Get(this.urlToApiAp+"/PreviousAppointmentLoad",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,PatientId:u,IgnorePaging:!1}).then(function(t){return t})},t.prototype.AdmitAppointmentLoad=function(t,n,e,i,r,o,u,p){return this.http.Get(this.urlToApiAp+"/AdmitAppointmentLoad",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,PatientId:u,AdmissionId:p,IgnorePaging:!1}).then(function(t){return t})},t.prototype.DocumentSave=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.DocurlToApi+"/Save",t).then(function(t){return t}):this.http.Put(this.DocurlToApi+"/Update",t).then(function(t){return t})},t.prototype.DocGetById=function(t){return this.http.Get(this.DocurlToApi+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.GetIPDBillingList=function(t,n){return this.http.Get(this.BillToApiAp+"/GetIPDBillingList",{PatientId:t,AdmitId:n}).then(function(t){return t})},t.prototype.PrescriptionDropdownList=function(){return this.http.Get(this.MediurlToApiAp+"/Load",{})},t.prototype.MedicineSave=function(t){return isNaN(t.Id)||0==t.Id?this.http.Post(this.MediurlToApiAp+"/Save",t).then(function(t){return t}):this.http.Put(this.MediurlToApiAp+"/Update",t).then(function(t){return t})},t.prototype.PrescriptionSave=function(t){return isNaN(t.Id)||0==t.Id?this.http.Post(this.PresurlToApiAp+"/Save",t).then(function(t){return t}):this.http.Put(this.PresurlToApiAp+"/Update",t).then(function(t){return t})},t.prototype.TempleteList=function(){return this.http.Get(this.PresurlToApiAp+"/Load",{})},t.prototype.TemplateLoadById=function(t){return this.http.Get(this.PresurlToApiAp+"/TemplateLoadById",{Id:t}).then(function(t){return t})},t.prototype.PrintRXById=function(t){return this.http.Get(this.PresurlToApiAp+"/PrintRXById",{Id:t}).then(function(t){return t})},t.prototype.GetAllVital=function(){return this.http.Get(this.VitalToApiAp+"/Load",{}).then(function(t){return t})},t.prototype.VitalSave=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.VitalToApiAp+"/Save",t).then(function(t){return t}):this.http.Put(this.VitalToApiAp+"/Update",t).then(function(t){return t})},t.prototype.VitalGetById=function(t){return this.http.Get(this.VitalToApiAp+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.DeleteVital=function(t,n){return this.http.Get(this.VitalToApiAp+"/Delete",{Id:t,VitalId:n}).then(function(t){return t})},t.prototype.DeleteFavorite=function(t){return this.http.Get(this.favoriteToApiAp+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.FavoriteSaveOrUpdate=function(t){if(isNaN(t.ID)||0==t.ID)return this.http.Post(this.favoriteToApiAp+"/Save",t).then(function(t){return t})},t.prototype.DeshboardLoadDropdown=function(t){return this.http.Get(this.urlToApiAp+"/DeshboardLoadDropdown",{PatientId:t}).then(function(t){return t})},t}())},"8rFi":function(t,n,e){"use strict";e.d(n,"b",function(){return i}),e.d(n,"a",function(){return r});var i=function(){return function(){this.SortOrder="Desc",this.CurrentPage=1,this.RecordPerPage=10,this.SearchText="",this.VisibleColumnInfo="",this.VisibleFilter=!1,this.FilterID="0",this.ShowSearch=!0}}(),r=function(){return function(){this.CustomAction1Icon="Action 1",this.CustomAction2Icon="Action 2",this.CustomAction3Icon="Action 3",this.Fields=[],this.Action=new o}}(),o=function(){return function(){this.AddText="fa fa-plus",this.AddTextType="I",this.IsShowGoBackArrow=!0,this.IsShowScreenName=!0,this.IsShowSearchAndAddButton=!0,this.IsCheckBox=!1,this.CopyTo=!1,this.CustomAction1=!1,this.CustomAction2=!1,this.CustomAction3=!1,this.PageHeaderVisible=!0,this.ScreenName="",this.PrintP=""}}()},EuOO:function(t,n,e){"use strict";e.d(n,"a",function(){return i});var i=function(){function t(t){this.ngControl=t}return t.prototype.onModelChange=function(t){this.onInputChange(t,!1)},t.prototype.keydownBackspace=function(t){this.onInputChange(t.target.value,!0)},t.prototype.onInputChange=function(t,n){var e=t.replace(/\D/g,"").match(/(\d{0,3})(\d{0,3})(\d{0,5})/);this.ngControl.valueAccessor.writeValue(e[1]?""+e[1]+e[2]+(e[3]?""+e[3]:""):e[1])},t}()},LtyE:function(t,n,e){"use strict";e.d(n,"f",function(){return i}),e.d(n,"c",function(){return r}),e.d(n,"d",function(){return o}),e.d(n,"g",function(){return u}),e.d(n,"e",function(){return p}),e.d(n,"h",function(){return l}),e.d(n,"a",function(){return s}),e.d(n,"b",function(){return h});var i=function(){return function(){}}(),r=function(){return function(){this.StatusId=25}}(),o=function(){return function(){}}(),u=function(){return function(){}}(),p=function(){return function(){}}(),l=function(){return function(){}}(),s=function(){return function(){}}(),h=function(){return function(){}}()},YGxW:function(t,n,e){"use strict";e.d(n,"a",function(){return o});var i=e("CcnG"),r=(e("gIcY"),e("osUM"),function(){}),o=(Object(i.Y)(function(){return o}),function(){function t(t){this.http=t,this.innerValue="",this.selectedFiles=[],this.ImageWithAddress=!1,this.ClearModel=new i.n,this.FileNameEvent=new i.n,this.IsNewFileEvent=new i.n,this.max=0,this.count=0,this.percentage=0,this.imagedata="",this.showbar=!1,this.onTouchedCallback=r,this.onChangeCallback=r}return Object.defineProperty(t.prototype,"value",{get:function(){return this.innerValue},set:function(t){t!==this.innerValue&&(this.innerValue=t,this.onChangeCallback(t))},enumerable:!0,configurable:!0}),t.prototype.onBlur=function(){this.onTouchedCallback()},t.prototype.clearValue=function(){$("#myFile").val(""),this.imagedata="",this.size=0,this.showbar=!1,this.value="",this.ClearModel.emit()},t.prototype.ClearValue=function(t){$("#myFile").val(""),this.innerValue="",this.imagedata="",this.size=null,this.showbar=!1,this.value=""},t.prototype.writeValue=function(t){t!==this.innerValue&&(t||(this.innerValue=t,this.imagedata="",this.size=null,this.showbar=!1,this.value="")),""==t&&(this.imagedata="",this.size=null,this.showbar=!1,this.value=""),null==t&&(this.imagedata="",this.size=null,this.showbar=!1,this.value="")},t.prototype.registerOnChange=function(t){this.onChangeCallback=t},t.prototype.registerOnTouched=function(t){this.onTouchedCallback=t},t.prototype.fileChangeEvent=function(t){var n=this;this.IsNewFileEvent.emit(!0);var e=this;if(e.size=t.target.files[0].size,e.size=e.size/1024,e.size=e.size/1024,e.size=Math.round(100*e.size)/100,e.size>2)return e.imagedata="File size is greater than 2 MB. File size is "+e.size+" MB",void(e.value="");e.showbar=!0,e.imagedata="File size is "+e.size+" MB",e.selectedFiles=t.target.files,0!=e.selectedFiles.length&&(e.max=100,e.percentage=0,e.http.Upload(e,e.selectedFiles,e.tempFunction).then(function(t){var i=JSON.parse(JSON.stringify(t));1==i.IsSuccess&&((i.ResultSet.length=1)?1==e.ImageWithAddress?(e.value=i.ResultSet[0],n.FileNameEvent.emit(i.ResultSet[0])):e.value=i.ResultSet[0]:e.value=i.ResultSet)},function(t){return t}),e.value="",e.innerValue="")},t.prototype.tempFunction=function(t,n){t.percentage=n},t}())},YLp1:function(t,n,e){"use strict";e.d(n,"a",function(){return i});var i=function(){return function(){this.emr_patient_bill_payment=[]}}()},f0u8:function(t,n,e){"use strict";e.d(n,"a",function(){return r});var i=e("hFUk"),r=(e("ZEy1"),function(){function t(t){this.http=t,this.urlToApi=i.b.BASE_Api_URL+"/api/Appointment/emr_patient_bill",this.urlToApiPat=i.b.BASE_Api_URL+"/api/Appointment/emr_patient"}return t.prototype.GetList=function(t,n,e,i,r,o){return this.http.Get(this.urlToApi+"/Pagination",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,IgnorePaging:!1}).then(function(t){return t})},t.prototype.ExportData=function(t,n,e,r,o,u,p){var l=this;return this.http.Get(this.urlToApi+"/ExportData",{ExportType:t,CurrentPageNo:n,RecordPerPage:e,VisibleColumnInfo:r,SortName:o,SortOrder:u,SearchText:p,IgnorePaging:!0}).then(function(t){return""!=t.FilePath&&l.http.ExportDataDownload(i.b.BASE_Api_URL,t.FilePath),t})},t.prototype.GetById=function(t){return this.http.Get(this.urlToApi+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.GetPatientById=function(t){return this.http.Get(this.urlToApiPat+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.SaveOrUpdate=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.urlToApi+"/Save",t).then(function(t){return t}):this.http.Put(this.urlToApi+"/Update",t).then(function(t){return t})},t.prototype.SaveOrUpdateBill=function(t){return this.http.Put(this.urlToApi+"/UpdateBill",t).then(function(t){return t})},t.prototype.Delete=function(t){return this.http.Delete(this.urlToApi+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.GetBillByPatient=function(t){return this.http.Get(this.urlToApi+"/GetBillByPatient",{Id:t}).then(function(t){return t})},t.prototype.GetBillByPayment=function(t,n,e){return this.http.Get(this.urlToApi+"/GetBillByPayment",{AdmissionId:t,AppointmentId:n,PatientId:e}).then(function(t){return t})},t.prototype.GetBillByAdmissionId=function(t,n){return this.http.Get(this.urlToApi+"/GetBillByAdmissionId",{Id:t,patientid:n}).then(function(t){return t})},t.prototype.GetPaymentByPatient=function(t){return this.http.Get(this.urlToApi+"/GetPaymentByPatient",{Id:t}).then(function(t){return t})},t.prototype.FormLoad=function(){return this.http.Get(this.urlToApi+"/Load",{}).then(function(t){return t})},t.prototype.GetAllScreens=function(){return this.http.Get(this.urlToApi+"/GetAllScreens",{}).then(function(t){return t})},t.prototype.PatientSearch=function(t){return this.http.Get(this.urlToApi+"/PatientSearch",{term:t}).then(function(t){return t})},t.prototype.ServiceSearch=function(t){return this.http.Get(this.urlToApi+"/ServiceSearch",{term:t}).then(function(t){return t})},t}())},kyx4:function(t,n,e){"use strict";e.d(n,"a",function(){return o}),e.d(n,"b",function(){return l});var i=e("CcnG"),r=e("Ip0R"),o=(e("gIcY"),e("YGxW"),e("osUM"),e("sE5F"),e("HVnV"),i.rb({encapsulation:0,styles:[".image-upload[_ngcontent-%COMP%]   input[_ngcontent-%COMP%] {\n        display: none;\n    }"],data:{}}));function u(t){return i.Nb(0,[(t()(),i.tb(0,0,null,null,1,"P",[["class","text-muted"]],null,null,null,null,null)),(t()(),i.Lb(-1,null,[" No File Choose "]))],null,null)}function p(t){return i.Nb(0,[(t()(),i.tb(0,0,null,null,10,"div",[["class","uk-clearfix showbarWrap col-sm-12 p-0"]],null,null,null,null,null)),(t()(),i.tb(1,0,null,null,9,"div",[["class","d-flex uploadbar_row"]],null,null,null,null,null)),(t()(),i.tb(2,0,null,null,1,"div",[["class","uploadBar text-muted"]],null,null,null,null,null)),(t()(),i.Lb(3,null,["",""])),(t()(),i.tb(4,0,null,null,2,"div",[["style","width: 198px;margin: 10px;"]],null,null,null,null,null)),(t()(),i.tb(5,0,null,null,1,"progress",[["style","width:100%;height:5px;"]],[[8,"value",0],[8,"max",0]],null,null,null,null)),(t()(),i.Lb(6,null,[" "," "])),(t()(),i.tb(7,0,null,null,3,"div",[["class","image-clear"]],null,null,null,null,null)),(t()(),i.tb(8,0,null,null,1,"label",[["class","mb-0 mt-2"],["for","myFile2"]],null,null,null,null,null)),(t()(),i.tb(9,0,null,null,0,"i",[["class","icon icon-cross text-danger"]],null,null,null,null,null)),(t()(),i.tb(10,0,null,null,0,"input",[["hidden",""],["id","myFile2"],["type","button"]],null,[[null,"click"]],function(t,n,e){var i=!0;return"click"===n&&(i=!1!==t.component.clearValue()&&i),i},null,null))],null,function(t,n){var e=n.component;t(n,3,0,e.imagedata),t(n,5,0,i.vb(1,"",e.percentage,""),i.vb(1,"",e.max,"")),t(n,6,0,e.percentage)})}function l(t){return i.Nb(0,[(t()(),i.tb(0,0,null,null,11,"div",[["class","uk-clearfix UplaodBtnWrap"]],null,null,null,null,null)),(t()(),i.tb(1,0,null,null,8,"ul",[["class","list-inline col-sm-12"],["style","display: block; text-align: center;"]],null,null,null,null,null)),(t()(),i.tb(2,0,null,null,7,"li",[],null,null,null,null,null)),(t()(),i.tb(3,0,null,null,6,"div",[["class","image-upload"]],null,null,null,null,null)),(t()(),i.tb(4,0,null,null,2,"label",[["for","myFile"]],null,null,null,null,null)),(t()(),i.Lb(-1,null,[" File Uplaod \xa0 "])),(t()(),i.tb(6,0,null,null,0,"i",[["class","icon-upload"]],null,null,null,null,null)),(t()(),i.kb(16777216,null,null,1,null,u)),i.sb(8,16384,null,0,r.m,[i.S,i.P],{ngIf:[0,"ngIf"]},null),(t()(),i.tb(9,0,null,null,0,"input",[["id","myFile"],["type","file"]],null,[[null,"change"]],function(t,n,e){var i=!0;return"change"===n&&(i=!1!==t.component.fileChangeEvent(e)&&i),i},null,null)),(t()(),i.kb(16777216,null,null,1,null,p)),i.sb(11,16384,null,0,r.m,[i.S,i.P],{ngIf:[0,"ngIf"]},null)],function(t,n){var e=n.component;t(n,8,0,!e.showbar),t(n,11,0,e.showbar)},null)}},osUM:function(t,n,e){"use strict";e.d(n,"a",function(){return o});var i=e("sE5F"),r=e("hFUk"),o=(e("HVnV"),function(){function t(t,n){this.http=t,this.encrypt=n,this.urlToApi=r.b.BASE_Api_URL+"/api/FileServer/Upload",this.progress=0}return t.prototype.Upload=function(t,n,e){var i=this;return new Promise(function(r,o){for(var u=new FormData,p=new XMLHttpRequest,l=0;l<n.length;l++)u.append(n[l].name,n[l],n[l].name),i.progress=l;p.onreadystatechange=function(){4===p.readyState&&(200===p.status?r(JSON.parse(p.response)):o(p.response))},p.upload.onprogress=function(n){e(t,n.lengthComputable?Math.round(n.loaded/n.total*100):100)},p.open("POST",i.urlToApi+"/Temporary",!0);var s=JSON.parse(i.encrypt.decryptionAES(localStorage.getItem("company"))),h=JSON.parse(i.encrypt.decryptionAES(localStorage.getItem("currentUser")));null!==localStorage.getItem("Token")&&p.setRequestHeader("Authorization","Bearer "+i.encrypt.decryptionAES(localStorage.getItem("Token"))),null!==s.CompanyID&&p.setRequestHeader("CompanyID",s.CompanyID),null!==h.ID&&p.setRequestHeader("UserID",h.ID),p.send(u)})},t.prototype.CreateAuthorizationHeader=function(){var t=JSON.parse(this.encrypt.decryptionAES(localStorage.getItem("currentUser"))),n=JSON.parse(this.encrypt.decryptionAES(localStorage.getItem("company"))),e=new i.d({"Content-Type":"application/json;charset=utf-8"});return null!==localStorage.getItem("Token")&&e.set("Authorization","Bearer "+this.encrypt.decryptionAES(localStorage.getItem("Token"))),null!==n.CompanyID&&e.set("CompanyID",n.CompanyID),null!==t.ID&&e.set("UserID",t.ID),null!==t&&e.set("User",t),e},t.prototype.handleError=function(t){return console.error("An error occurred",t),Promise.reject(t.message||t)},t}())},yuIq:function(t,n,e){"use strict";e.d(n,"a",function(){return r});var i=e("hFUk"),r=(e("ZEy1"),function(){function t(t){this.http=t,this.urlToApi=i.b.BASE_Api_URL+"/api/Appointment/emr_patient"}return t.prototype.GetList=function(t,n,e,i,r,o){return this.http.Get(this.urlToApi+"/Pagination",{CurrentPageNo:t,RecordPerPage:n,VisibleColumnInfo:e,SortName:i,SortOrder:r,SearchText:o,IgnorePaging:!1}).then(function(t){return t})},t.prototype.ExportData=function(t,n,e,r,o,u,p){var l=this;return this.http.Get(this.urlToApi+"/ExportData",{ExportType:t,CurrentPageNo:n,RecordPerPage:e,VisibleColumnInfo:r,SortName:o,SortOrder:u,SearchText:p,IgnorePaging:!0}).then(function(t){return""!=t.FilePath&&l.http.ExportDataDownload(i.b.BASE_Api_URL,t.FilePath),t})},t.prototype.GetById=function(t){return this.http.Get(this.urlToApi+"/GetById",{Id:t}).then(function(t){return t})},t.prototype.SaveOrUpdate=function(t){return isNaN(t.ID)||0==t.ID?this.http.Post(this.urlToApi+"/Save",t).then(function(t){return t}):this.http.Put(this.urlToApi+"/Update",t).then(function(t){return t})},t.prototype.Delete=function(t){return this.http.Delete(this.urlToApi+"/Delete",{Id:t}).then(function(t){return t})},t.prototype.FormLoad=function(){return this.http.Get(this.urlToApi+"/Load",{}).then(function(t){return t})},t.prototype.GetAllScreens=function(){return this.http.Get(this.urlToApi+"/GetAllScreens",{}).then(function(t){return t})},t.prototype.DoctorSearch=function(t){return this.http.Get(this.urlToApi+"/DoctorSearch",{term:t}).then(function(t){return t})},t}())}}]);