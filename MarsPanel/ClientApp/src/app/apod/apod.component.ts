import { ApodService } from './apod.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { IApod } from './apod';

@Component({
  selector: 'app-apod',
  templateUrl: './apod.component.html',
  styleUrls: ['./apod.component.css']
})
export class ApodComponent implements OnInit, OnDestroy {

  pageTitle = 'Picture of the Day';
  apod!: IApod;
  public apod$: Observable<IApod> | undefined;

  private _apodDefault: Subscription = new Subscription;
  private _apodByDate: Subscription = new Subscription;
  errorMessage = '';

  public get date(): Observable<string> {
    return this._date.asObservable();
}

private _date = new BehaviorSubject<string>("");

  constructor(private apodService: ApodService) { }

  ngOnInit(): void {
    this._apodDefault = this.apodService.getToday().subscribe(
      {
        next: Apod => this.apod = Apod,
        error: error => this.errorMessage = error
      }
    );
  }

  onDateChange(date: string): void {
    console.log('change date ' + date);
    this.apodService.getByDate(date).subscribe({
      next: Apod => this.apod = Apod,
      error: error => this.errorMessage = error
    });
  }

   ngOnDestroy(): void {
     this._apodDefault.unsubscribe();
   }

}
