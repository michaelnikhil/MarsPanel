import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ApodComponent } from './apod/apod.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DatePickerComponent } from './apod/date-picker/date-picker.component';
import { AngularMaterialModule } from './shared/angular-material.module';
import { InsightWeatherComponent } from './insight-weather/insight-weather.component';
import { LineChartComponent } from './insight-weather/line-chart/line-chart.component';
import { HighchartsChartModule } from 'highcharts-angular';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ApodComponent,
    DatePickerComponent,
    InsightWeatherComponent,
    LineChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'apod', component: ApodComponent },
      { path: 'insight-weather', component: InsightWeatherComponent },
    ]),
    BrowserAnimationsModule,
    AngularMaterialModule,
    HighchartsChartModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
