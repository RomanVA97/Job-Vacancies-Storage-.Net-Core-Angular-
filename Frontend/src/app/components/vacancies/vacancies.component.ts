import { Component, OnInit } from '@angular/core';
import { Vacancy } from './../../core/models/vacancy';
import { VacancyService } from './../../core/services/VacancyService';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: ['./vacancies.component.css'],
  providers: [VacancyService]
})
export class VacanciesComponent {
  viewModel = new ViewModel();
  length = 100;
  pageSize = 5;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  page = 1;

  constructor(private vacancyService: VacancyService) {
    
  }

  GetElements() {
    this.vacancyService.GetAll(this.page, this.pageSize).subscribe (
      (res) => {
          this.viewModel = res.json();
          this.length = this.viewModel.pageCount * this.pageSize;
      },
      (error) => {
          console.log(error);
      }
    );
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.GetElements();
  }

  changePage(event: PageEvent) {
    this.pageEvent = event;
    this.page = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.GetElements();
  }

}

export class ViewModel {
  pageCount: number;
  elements: Vacancy[];
}
