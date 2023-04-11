﻿import { Injectable } from '@angular/core';
import { GlobalVariable } from '../../../../../AngularConfig/global';
import { HttpService } from '../../../../../CommonService/HttpService';
import { sys_drop_down_value } from './DropDownModel';


@Injectable()
export class DropDownService {


    

    private urlToApi = GlobalVariable.BASE_Api_URL + "/api/Admin/sys_drop_down"

    constructor(private http: HttpService) { }

    GetList(CurrentPage: number, RecordPerPage: number, VisibleColumnInfo: string, SortName: string, SortOrder: string, SearchText: string): Promise<any> {
        var data = { 'CurrentPageNo': CurrentPage, 'RecordPerPage': RecordPerPage, 'VisibleColumnInfo': VisibleColumnInfo, 'SortName': SortName, 'SortOrder': SortOrder, 'SearchText': SearchText, 'IgnorePaging': false };
        return this.http.Get(this.urlToApi + '/Pagination', data).then(e => e);
    }


    ExportData(ExportType: number, CurrentPage: number, RecordPerPage: number, VisibleColumnInfo: string, SortName: string, SortOrder: string, SearchText: string): Promise<any> {

        var data = { 'ExportType': ExportType, 'CurrentPageNo': CurrentPage, 'RecordPerPage': RecordPerPage, 'VisibleColumnInfo': VisibleColumnInfo, 'SortName': SortName, 'SortOrder': SortOrder, 'SearchText': SearchText, 'IgnorePaging': true };
        return this.http.Get(this.urlToApi + '/ExportData', data).then(e => {
            
            if (e.FilePath != "")
                this.http.ExportDataDownload(GlobalVariable.BASE_Api_URL, e.FilePath);

            return e;
        });
    }

    GetById(Id: number): Promise<any> {
        var data = { 'Id': Id };
        return this.http.Get(this.urlToApi + '/GetById', data).then(e => e);
    }

    SaveOrUpdate(entity: sys_drop_down_value): Promise<any> {
        if (isNaN(entity.ID) || entity.ID == 0)
            return this.http.Post(this.urlToApi + '/Save', entity).then(e => e);
        else
            return this.http.Put(this.urlToApi + '/Update', entity).then(e => e);
    }

    SaveAndReturnDeptList(entity: sys_drop_down_value): Promise<any> {
        return this.http.Post(this.urlToApi + '/SaveAndReturnDeptList', entity).then(e => e);
    }

    Delete(entity: sys_drop_down_value): Promise<any> {
        return this.http.Post(this.urlToApi + '/Delete', entity).then(e => e);
    }

    FormLoad(): Promise<any> {
        return this.http.Get(this.urlToApi + '/Load', {}).then(e => e);
    }

    GetValueByMFID(entity: sys_drop_down_value): Promise<any> {
        return this.http.Post(this.urlToApi + '/GetValueByMFID', entity).then(e => e);
    }

    GetDependentValueByDepID(entity: sys_drop_down_value): Promise<any> {
        return this.http.Post(this.urlToApi + '/GetDependentValueByDepID', entity).then(e => e);
    }
}
