import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vacancy } from './../../core/models/vacancy';
import { VacancyService } from './../../core/services/VacancyService';
@Component({
  selector: 'app-vacancydetail',
  templateUrl: './vacancyDetail.component.html',
  styleUrls: ['./vacancyDetail.component.css']
})
export class VacancyDetailComponent {
    id: string;
    vacancy = new Vacancy();
    constructor(private activateRoute: ActivatedRoute, private vacancyService: VacancyService) {
        this.id = activateRoute.snapshot.params['id'];
    }


    GetElementById() {
        this.vacancyService.GetById(this.id).subscribe (
          (res) => {
              console.log(res);
              this.vacancy = res.json();
          },
          (error) => {
              console.log(error);
          }
        );
    }

    // tslint:disable-next-line:use-life-cycle-interface
    ngOnInit() {
        this.GetElementById();
    }

}
