import { Component, Input, Output, OnInit, OnChanges, EventEmitter, ViewChild, ElementRef, HostListener } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { emr_Income } from './IncomeModel';
import { LoaderService } from '../../../../CommonService/LoaderService';
import { IncomeService } from './IncomeService';
import { ValidationVariables } from '../../../../AngularConfig/global';
import { CommonService } from '../../../../CommonService/CommonService';
import { EncryptionService } from '../../../../CommonService/encryption.service';
import { CommonToastrService } from '../../../../CommonService/CommonToastrService';
import { IMyDateModel } from 'mydatepicker';
import { GlobalVariable } from '../../../../AngularConfig/global';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
@Component({
    selector: 'setup-IncomeComponentForm',
    templateUrl: './IncomeComponentForm.html',
    moduleId: module.id,
    providers: [IncomeService],
})
export class IncomeComponentForm implements OnInit {
    public Form1: FormGroup;
    public submitted: boolean;
    @Input() ScreenName: string;
    @Input() id: number;
    public IsReadOnly = false;
    public ScreenLists = [];
    public Modules = [];
    public filterdData = [];
    public IsSameModuleName: string;
    public IsChecked: boolean;
    public IsEmpExist: boolean = false;
    public IsAdmin: boolean = false;
    public IsUpdateText: boolean = false;
    public model = new emr_Income();
    public PayrollRegion: string;
    public CategoryList: any[] = [];
    public Keywords: any[] = [];
    public sub: any;
    public Rights: any;
    public ControlRights: any;
    public IsEdit: boolean = false;
    constructor(public _CommonService: CommonService, private encrypt: EncryptionService,public _fb: FormBuilder, public loader: LoaderService
        , public _IncomeService: IncomeService, public commonservice: CommonService
        , public toastr: CommonToastrService, public route: ActivatedRoute, public _router: Router) {
        this.PayrollRegion = "PK";//  this.commonservice.getPayrollRegion();
        this.Rights = JSON.parse(this.encrypt.decryptionAES(localStorage.getItem('Rights')));
        this.ControlRights = this._CommonService.ScreenRights("20");
        //this.Keywords = this.commonservice.GetKeywords("Expense");
    }
    ngOnInit() {
        this.loadDropdown();
        this.Form1 = this._fb.group({
            CategoryId: ['', [Validators.required]],
            CategoryDropdownId: [''],
            Date: ['', [Validators.required]],
            Remark: ['', [Validators.required]],
            DueAmount: ['', [Validators.required]],
            ReceivedAmount: [''],
        });
        this.sub = this.route.queryParams
            .pipe(filter(params => params.id))
            .subscribe(params => {
                this.id = params.id;
                if (this.id > 0) {
                    this.loader.ShowLoader();
                    this.IsEdit = true;
                    this.loader.ShowLoader();
                    this._IncomeService.GetById(this.id).then(m => {
                        this.model = m.ResultSet;
                    });
                } else {
                    this.model.Date = new Date();
                    this.loader.HideLoader();
                }
            });
    }
    loadDropdown() {
        this.loader.ShowLoader();
        this._IncomeService.FormLoad().then(m => {
            if (m.IsSuccess) {
                this.CategoryList = m.ResultSet.categoryList;
                this.loader.HideLoader();
            } else
                this.loader.HideLoader();
        });
    }
    SaveOrUpdate(isValid: boolean): void {
        this.submitted = true; // set form submit to true
        if (isValid) {
            this.submitted = false;
            this.loader.ShowLoader();
            this._IncomeService.SaveOrUpdate(this.model).then(m => {
                var result = JSON.parse(m._body);
                if (result.IsSuccess) {
                    this.toastr.Success(result.Message);
                    this._router.navigate(['home/Income']);
                    this.loader.HideLoader();
                }
                else {
                    this.toastr.Error('Error', result.ErrorMessage);
                    this.loader.HideLoader();
                }
            });
        }
    }
    onDateChanged(event: IMyDateModel) {
        if (event) {
            var dob = new Date(this.model.Date);
        }
    }
    Delete() {
        var result = confirm("Are you sure you want to delete selected record.");
        if (result) {
            this.loader.ShowLoader();
            this._IncomeService.Delete(this.model.ID.toString()).then(m => {
                if (m.ErrorMessage != null)
                    this.toastr.Error('Error', m.ErrorMessage);
                else
                    this._router.navigate(['/home/Income']);
                this.loader.HideLoader();
            });
        }
    }
    Close() {
        this.model = new emr_Income();
        this.submitted = false;
        this.IsEmpExist = false;
        this.IsAdmin = false;
        this.IsUpdateText = false;
    }
}