import { Routes } from '@angular/router';
import { VacanciesComponent } from './../../components/vacancies/vacancies.component';
import { EventsComponent } from './../../components/events/events.component';
import { ContactsComponent } from './../../components/contacts/contacts.component';
import { AboutProjectComponent } from './../../components/aboutProject/aboutProject.component';
import { CreateEventComponent } from './../../components/createEvent/createEvent.component';
import { CreateVacancyComponent } from './../../components/createVacancy/createVacancy.component';
import { EventDetailComponent } from './../../components/eventDetail/eventDetail.component';
import { VacancyDetailComponent } from './../../components/vacancyDetail/vacancyDetail.component';
import { RulesComponent } from './../../components/rules/rules.component';


export const AppRoutes: Routes = [
  { path: 'vacancies', component: VacanciesComponent},
  { path: 'events', component: EventsComponent},
  { path: 'contacts', component: ContactsComponent},
  { path: 'aboutProject', component: AboutProjectComponent},
  { path: 'createEvent', component: CreateEventComponent},
  { path: 'createVacancy', component: CreateVacancyComponent},
  { path: 'eventDetail/:id', component: EventDetailComponent},
  { path: 'vacancyDetail/:id', component: VacancyDetailComponent},
  { path: 'rules', component: RulesComponent},
  { path: '**', component: VacanciesComponent}
];
