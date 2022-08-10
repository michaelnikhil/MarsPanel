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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LineChartComponent } from './shared/line-chart/line-chart.component';
import { HighchartsChartModule } from 'highcharts-angular';
import { ApodDetailComponent } from './apod/apod-detail/apod-detail.component';
import { ApikeyComponent } from './apikey/apikey.component';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/state';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ApodComponent,
    DatePickerComponent,
    LineChartComponent,
    ApodDetailComponent,
    ApikeyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'apod', component: ApodComponent },
      { path: 'apikey', component: ApikeyComponent },
    ]),
    BrowserAnimationsModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HighchartsChartModule,
    EffectsModule.forRoot([]),
    StoreModule.forRoot({}, {}),
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
