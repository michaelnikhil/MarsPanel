/* eslint-disable no-console */
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ICuriosityData } from './model';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private readonly apiBaseUrl: string = '/api/marsweather';
  private readonly apiCuriosity: string = '/api/curiosity';

  constructor(private http: HttpClient) { }

  public getCuriosity(): Observable<ICuriosityData> {
    return this.http.get<ICuriosityData>(this.apiCuriosity).pipe(
      tap(out => console.log(`Curiosity number of data= ${Object.keys(out).length}`)),
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
