import { Injectable } from '@angular/core';

@Injectable()
export class ApiPathProvider {

    basePath: string;
    imageStoragePath:string;

    constructor() {
        this.basePath = 'http://localhost:57980/api/';
        this.imageStoragePath = 'http://localhost:57980/FileStorage';
    }

}
