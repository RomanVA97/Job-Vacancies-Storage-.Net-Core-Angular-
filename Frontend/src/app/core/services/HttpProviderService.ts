import { Http, RequestOptions } from '@angular/http';
import { IHttpProvider } from '../interfaces/IHttpProvider';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpProviderService implements IHttpProvider {

    basePath: string;
    constructor(private http: Http) {

    }

    Get(path: string, options: RequestOptions) {
        return this.http.get(this.basePath + path, options);
    }

    Post(path: string, body: any, options: RequestOptions) {
        return this.http.post(this.basePath + path, body, options);
    }

    Put(path: string, body: any, options: RequestOptions) {
        return this.http.put(this.basePath + path, body, options);
    }

    Delete(path: string, options: RequestOptions) {
        return this.http.delete(this.basePath + path, options);
    }
}
