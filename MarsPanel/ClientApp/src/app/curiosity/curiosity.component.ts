/* eslint-disable no-console */
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { DataService } from '../shared/dataservice';

@Component({
  selector: 'curiosity',
  templateUrl: './curiosity.component.html',
  styleUrls: ['./curiosity.component.css']
})
export class CuriosityComponent implements OnInit {

  _subscription!: Subscription;
  constructor(private dataservice : DataService) { }

  ngOnInit(): void {
    this._subscription = this.dataservice.getCuriosity().subscribe(
      {
        next: data => {
          console.log(`subscrition val ${JSON.stringify(data)}`);
        }
      }
    );
  }
}
