import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutes } from './route.config';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { DlDateTimePickerDateModule } from 'angular-bootstrap-datetimepicker';
import { AngularDateTimePickerModule } from 'angular2-datetimepicker';
import { MatChipsModule } from '@angular/material/chips';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AngularEditorModule } from '@kolkov/angular-editor';


export const Imports = [
    BrowserModule, RouterModule.forRoot(AppRoutes), HttpModule, FormsModule, BrowserAnimationsModule, MatDatepickerModule,
    MatFormFieldModule, MatNativeDateModule, MatInputModule, MatSelectModule, DlDateTimePickerDateModule, AngularDateTimePickerModule,
    MatChipsModule, MatPaginatorModule, AngularEditorModule, HttpClientModule
];
