import { XYData } from './../shared/chart-widget.model';
import { IPressure } from './weather';
import { InsightWeatherService } from './insight-weather.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-insight-weather',
  templateUrl: './insight-weather.component.html',
  styleUrls: ['./insight-weather.component.css']
})
export class InsightWeatherComponent implements OnInit, OnDestroy {
  
  pageTitle = 'Weather on Mars (Insight probe)';
  pressure!: IPressure;
  public pressureData: XYData = {
    dataPoints: [[5, 2], [6, 3], [8, 2]]
   };
   public titlePressureChart = 'Pressure chart';


  private _subscription: Subscription = new Subscription;
  errorMessage = '';

  constructor(private insightWeatherService : InsightWeatherService) { }

  ngOnInit(): void {
    this._subscription = this.insightWeatherService.get().subscribe(
      {
        next: Pressure => this.pressure = Pressure,
        error: error => this.errorMessage = error
      }
    );
    console.log('pressure component on init');
    this.pressureData.dataPoints = [[5, 2], [6, 3], [8, 2]];
    console.log('pressure data = ' + this.pressureData.dataPoints);
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

}
