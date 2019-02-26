import { Component } from '@angular/core';
import { Event } from './../../core/models/event';
import { EventService } from './../../core/services/EventService';
import { ViewModel } from './createEvent.viewModel';
import { Router } from '@angular/router';
import * as moment from 'moment';

@Component({
  selector: 'app-createevent',
  templateUrl: './createEvent.component.html',
  styleUrls: ['./createEvent.component.css']
})
export class CreateEventComponent {

  event = new ViewModel();
  file: File;
  settings = {
    bigBanner: true,
    timePicker: true,
    format: 'dd.MM.yyyy hh:mm a',
    defaultOpen: false,
    closeOnSelect: false
  };
  constructor(private eventService: EventService, private router: Router) {
    moment.locale("ru-Ru");
  }

  Create() {
    console.log(this.event.date);
    this.eventService.Create(this.event.title, this.event.description, this.event.registrationLink,
      this.event.city, this.event.address, this.event.email, this.event.phoneNumber,
      this.event.date.toUTCString(), this.file).subscribe (
      (res) => {
        console.log(res);
        this.router.navigate(['/events']);
      },
      (error) => {
        console.log(error);
      });
  }

  upload(file: File) {
    this.file = file;
  }

}
