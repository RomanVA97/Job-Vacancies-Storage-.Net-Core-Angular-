import { Component } from '@angular/core';
import {Router} from '@angular/router';
import { ActivatedRoute} from '@angular/router';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-navmenu',
  templateUrl: './navMenu.component.html',
  styleUrls: ['./navMenu.component.css']
})
export class NavMenuComponent {


  constructor(private router: Router, private activateRoute: ActivatedRoute) {

  }






  ngOnInit() {

  }

}
