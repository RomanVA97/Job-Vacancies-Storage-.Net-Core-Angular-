import { Injectable } from '@angular/core';
import { ApiPathProvider } from './../configs/apiPathProvider';
import { Inject } from '@angular/core';
import { AliasIHttpProvider, IHttpProvider } from '../interfaces/IHttpProvider';
import { RequestOptions, Headers } from '@angular/http';
import { Vacancy } from '../models/vacancy';

@Injectable()
export class VacancyService {

    basePath: string;
    constructor(@Inject(AliasIHttpProvider)private httpProvider: IHttpProvider, apiPathConfiguration: ApiPathProvider) {
        this.httpProvider.basePath = apiPathConfiguration.basePath;
    }

    GetAll(page: number, pageSize: number) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;
        return this.httpProvider.Get('Vacancies?page=' + page + '&pageSize=' + pageSize, requestOptions);
    }

    GetById(id: string) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;
        return this.httpProvider.Get('Vacancies/' + id, requestOptions);
    }

    Create(item: Vacancy) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;

        const body = new FormData();
        body.append('Title', item.title);
        body.append('WorkingCondition', item.workingCondition.toString());
        body.append('Description', item.description);
        body.append('City', item.city);
        body.append('IsRemoteWorking', item.isRemoteWorking.toString());
        body.append('OrganizationName', item.organizationName);
        body.append('Email', item.email);
        body.append('CompanyURL', item.companyURL);
        body.append('PhoneNumber', item.phoneNumber);
        body.append('ContactPartner', item.contactPartner);
        body.append('Salary', item.salary.toString());
        body.append('CurrencyType', item.currencyType.toString());

        return this.httpProvider.Post('Vacancies/', body, requestOptions);
    }

/*
    Post(path: string, body: any, options: RequestOptions) {
        return this.http.post(this.basePath + path, body, options);
    }*/

    /*Put(path: string, body: any, options: RequestOptions) {
        return this.http.put(this.basePath + path, body, options);
    }

    Delete(path: string, options: RequestOptions) {
        return this.http.delete(this.basePath + path, options);
    }*/
}
