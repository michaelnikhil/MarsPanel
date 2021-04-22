import { DatePickerComponent } from './date-picker/date-picker.component';
import { ApodService } from './apod.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IApod } from './apod';

@Component({
  selector: 'app-apod',
  templateUrl: './apod.component.html',
  styleUrls: ['./apod.component.css']
})
export class ApodComponent implements OnInit, OnDestroy {

  pageTitle = 'Picture of the Day';
  apod!: IApod;

  private _subscription: Subscription = new Subscription;
  errorMessage = '';

  constructor(private apodService: ApodService) { }

  ngOnInit(): void {
    this._subscription = this.apodService.get().subscribe(
      {
        next: Apod => this.apod = Apod,
        error: error => this.errorMessage = error
      }
    );
    console.log('apod component on init');

  }

   ngOnDestroy(): void {
     this._subscription.unsubscribe();
   }

}
