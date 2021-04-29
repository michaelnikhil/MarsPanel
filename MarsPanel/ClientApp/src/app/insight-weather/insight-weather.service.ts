import { IPressure } from './weather';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InsightWeatherService {
  private readonly apiBaseUrl: string = '/api/marsweather';

  constructor(private http: HttpClient) { }
  public get(): Observable<IPressure> {
    return this.http.get<IPressure>(this.apiBaseUrl).pipe(
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