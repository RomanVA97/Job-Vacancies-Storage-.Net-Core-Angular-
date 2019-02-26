import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Event } from './../../core/models/event';
import { EventService } from './../../core/services/EventService';
import { ApiPathProvider } from './../../core/configs/apiPathProvider';

@Component({
  selector: 'app-eventdetail',
  templateUrl: './eventDetail.component.html',
  styleUrls: ['./eventDetail.component.css']
})
export class EventDetailComponent {
    id: string;
    event = new Event();
    imageStoragePath:string;

    constructor(private activateRoute: ActivatedRoute, private eventService: EventService, apiPathConfiguration: ApiPathProvider) {
        this.id = activateRoute.snapshot.params['id'];
        this.imageStoragePath = apiPathConfiguration.imageStoragePath;
    }

    GetElementById() {
        this.eventService.GetById(this.id).subscribe (
          (res) => {
              console.log(res);
              this.event = res.json();
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
