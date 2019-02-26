import { Component, OnInit } from '@angular/core';
import { Event } from './../../core/models/event';
import { EventService } from './../../core/services/EventService';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent {
  viewModel = new ViewModel();
  length = 100;
  pageSize = 5;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  page = 1;

  constructor(private eventService: EventService) {
    
  }

  GetElements() {
    this.eventService.GetAll(this.page, this.pageSize).subscribe (
      (res) => {
          this.viewModel = res.json();
          this.length = this.viewModel.pageCount * this.pageSize;
      },
      (error) => {
          console.log(error);
      }
    );
  }
  changePage(event: PageEvent) {
    this.pageEvent = event;
    this.page = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.GetElements();
  }
  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.GetElements();
  }

}
export class ViewModel {
  pageCount: number;
  elements: Event[];
}
