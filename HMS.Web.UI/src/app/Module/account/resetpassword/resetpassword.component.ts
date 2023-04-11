import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { AuthenticationService } from '../../../CommonService/AuthenticationService';
import { Router, ActivatedRoute } from '@angular/router';
import { ValidationVariables } from '../../../AngularConfig/global';
import { User } from '../../model/User.model';
import { LoaderService } from '../../../CommonService/LoaderService';
import { CommonToastrService } from '../../../CommonService/CommonToastrService';
import { CommonService } from '../../../CommonService/CommonService';

@Component({
    selector: 'app-resetpassword',
    templateUrl: './resetpassword.component.html',
    styleUrls: ['./resetpassword.component.css'],
    providers: [AuthenticationService]
})
export class ResetpasswordComponent implements OnInit {

    public model = new User();
    public Form: FormGroup;
    public submitted: boolean;
    currentURL = '';
    public checked: boolean = false;
    public token: any = '';
    public params;
    public PayrollRegion: string;
    public Keywords: any[] = [];

    constructor(public _fb: FormBuilder, public router: ActivatedRoute, public accountService: AccountService, public _router: Router, public loader: LoaderService
        , public toastr: CommonToastrService, public _commonService: CommonService, ) {
        this.PayrollRegion = this._commonService.getPayrollRegion();
        //this.Keywords = this._commonService.GetKeywords("resetpassword");
    }
    ngOnInit() {
        this.Form = this._fb.group({
            Email: ['', [<any>Validators.required, Validators.pattern(ValidationVariables.EmailPattern)]],
            Pwd: ['', [Validators.required, <any>Validators.minLength(6)]],
            CPassword: [''],
        });

        this.currentURL = window.location.href;
        if (this.currentURL) {
            ;
            this.params = this.currentURL.split('/resetpassword?')[1];
            if (this.params) {
                this.loader.ShowLoader();
                this.accountService.IsForgotTokenExist(this.params).then(
                    data => {
                        if (data.IsSuccess) {
                            var result = data.ResultSet;
                            if (data.Message == 'true') {
                                this.model.Email = result.Email;
                                this.checked = true;
                                this.token = this.params;
                            }
                            if (data.Message == 'TokenExpired')
                                this.toastr.Error('Token Expired', 'token has been expired.');
                        }
                        else
                            this.toastr.Error('Request Denied', 'The code is invalid, password reset request denied.');

                        this.loader.HideLoader();
                    });
            }
            else {
                this._router.navigate(['/login']);
            }
        }
    }

    ResetPass(isValid: boolean): void {
        this.submitted = true;
        if (isValid) {
            isValid = this.model.Pwd == this.model.CPassword;
            this.submitted = true;
            if (isValid) {
                this.submitted = false;
                this.model.ForgotToken = this.token;
                this.model.MultilingualId = 1;
                this.loader.ShowLoader();
                debugger
                this.accountService.resetpasswd(this.model).then(
                    data => {
                        var result = JSON.parse(data._body);

                        if (result.IsSuccess)
                            this._router.navigate(['/Resetpasswordchanged']);
                        else {
                            this.loader.HideLoader();
                            this.toastr.Error('Invalid', 'Invalid Link');
                        }
                        this.loader.HideLoader();
                    },
                    error => {
                        this.loader.HideLoader();
                        this.toastr.Error('Error', error);
                    });
            }
        }
    }
}
