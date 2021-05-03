import { IPressure } from './weather';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { XYData } from '../shared/chart-widget.model';

@Injectable({
  providedIn: 'root'
})
export class InsightWeatherService {
  private readonly apiBaseUrl: string = '/api/marsweather';

  constructor(private http: HttpClient) { }
  
  public get(): Observable<any[]> {
    return this.http.get<any[]>(this.apiBaseUrl).pipe(
      tap(out => console.log('Pressure = ' + JSON.stringify(out))),
      catchError(this.handleError)
    );
    }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is : ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}