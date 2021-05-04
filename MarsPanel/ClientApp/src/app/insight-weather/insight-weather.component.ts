import { XYData, DataPoint } from './../shared/chart-widget.model';
import { IPressure } from './weather';
import { InsightWeatherService } from './insight-weather.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-insight-weather',
  templateUrl: './insight-weather.component.html',
  styleUrls: ['./insight-weather.component.css']
})
export class InsightWeatherComponent implements OnInit, OnDestroy {
  
  pageTitle = 'Weather on Mars (Insight probe)';
  public pressure$!: IPressure;
  errorMessage = '';
  // public pressureData: XYData = {
  //   dataPoints: [[5, 2], [6, 3], [8, 2]]
  //  };
  public titlePressureChart = 'Pressure chart';
  public pressure_timeseries_av$! : [number,number][];
  public tempPressure!: [number,number][];

  _subscription!: Subscription;

  constructor(private insightWeatherService : InsightWeatherService) { }

  ngOnInit(): void {
    this._subscription = this.insightWeatherService.get().subscribe(
      {
        next: weather => {
          this.pressure$ = weather;
          this.pressure_timeseries_av$ = weather.pressure_timeseries_av;
          this.tempPressure= weather.pressure_timeseries_av;

          console.log('subscrition val ' + JSON.stringify(this.pressure_timeseries_av$));
        },
        error: err => this.errorMessage = err
      }
    );
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

}
