import { Http, RequestOptions } from '@angular/http';
import { InjectionToken } from '@angular/core';

export const AliasIHttpProvider = new InjectionToken<IHttpProvider>('IHttpProviderImpl');


export interface IHttpProvider {

    basePath: string;

    Get(path: string, options: RequestOptions): any;

    Post(path: string, body: any, options: RequestOptions): any;

    Put(path: string, body: any, options: RequestOptions): any;

    Delete(path: string, options: RequestOptions): any;
}
