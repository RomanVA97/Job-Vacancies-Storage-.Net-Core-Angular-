import { Injectable } from '@angular/core';
import { ApiPathProvider } from './../configs/apiPathProvider';
import { Inject } from '@angular/core';
import { AliasIHttpProvider, IHttpProvider } from '../interfaces/IHttpProvider';
import { RequestOptions, Headers } from '@angular/http';
import { Event } from '../models/event';

@Injectable()
export class EventService {

    basePath: string;
    constructor(@Inject(AliasIHttpProvider)private httpProvider: IHttpProvider, apiPathConfiguration: ApiPathProvider) {
        this.httpProvider.basePath = apiPathConfiguration.basePath;
    }

    GetAll(page: number, pageSize: number) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;
        return this.httpProvider.Get('Events?page=' + page + '&pageSize=' + pageSize, requestOptions);
    }

    GetById(id: string) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;
        return this.httpProvider.Get('Events/' + id, requestOptions);
    }

    Create(title: string, description: string, registrationLink: string, city: string,
        address: string, email: string, phoneNumber: string, date: string, file: File) {
        const requestOptions = new RequestOptions();
        const headers = new Headers();
        requestOptions.headers = headers;

        const body = new FormData();
        body.append('Title', title);
        body.append('Description', description);
        body.append('RegistrationLink', registrationLink);
        body.append('City', city);
        body.append('Address', address);
        body.append('Email', email);
        body.append('PhoneNumber', phoneNumber);
        body.append('Date', date);
        body.append('File', file, file.name);

        return this.httpProvider.Post('Events/', body, requestOptions);
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
