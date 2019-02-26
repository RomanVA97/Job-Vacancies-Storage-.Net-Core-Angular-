import { Component, OnInit } from '@angular/core';
import { Vacancy } from './../../core/models/vacancy';
import { VacancyService } from './../../core/services/VacancyService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createvacancy',
  templateUrl: './createVacancy.component.html',
  styleUrls: ['./createVacancy.component.css']
})
export class CreateVacancyComponent {

  vacancy: Vacancy;

  constructor(private vacancyService: VacancyService, private router: Router) {
    this.vacancy = new Vacancy();
    this.vacancy.isRemoteWorking = false;
  }

  Create() {
    console.log(this.vacancy);
    this.vacancyService.Create(this.vacancy).subscribe (
      (res) => {
        this.router.navigate(['/vacancies']);
      },
      (error) => {
        console.log(error);
      });
  }

}
