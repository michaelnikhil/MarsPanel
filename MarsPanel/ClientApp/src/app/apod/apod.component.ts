import { ApodService } from './apod.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IApod } from './apod';

@Component({
  selector: 'app-apod',
  templateUrl: './apod.component.html',
  styleUrls: ['./apod.component.css']
})
export class ApodComponent implements OnInit {

  pageTitle = 'Picture of the Day';
  apod!: IApod[];
  sub: Subscription | undefined ;
  errorMessage = '';

  constructor(private apodService: ApodService) { }

  ngOnInit(): void {
    this.sub = this.apodService.get().subscribe(
      {
        next: Apod => this.apod = Apod,
        error: error => this.errorMessage = error
      }
    );
    console.log('apod component on init');
  }

  // ngOnDestroy(): void {
  //   this.sub.unsubscribe();
  // }

}
