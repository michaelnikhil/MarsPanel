/* eslint-disable no-console */
import { IApod } from './apod';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from '../store/state';
@Injectable({
  providedIn: 'root'
})
export class ApodService {
  private readonly apiBaseUrl: string = '/api/apod';
  key!: Observable<string>;

  constructor(private http: HttpClient, private store: Store<AppState>) { 
    store.select(state => state.apikeyValue).subscribe(res => {
      this.key = res;
    });
  }

  public getToday(): Observable<IApod> {
    return this.http.get<IApod>(`${this.apiBaseUrl}/today/`).pipe(
      tap(out => console.log(`Apod today ${JSON.stringify(out)}`)),
      catchError(this.handleError)
    );
  }

  public getByDate(date: string): Observable<IApod> {
    return this.http.get<IApod>(`${this.apiBaseUrl}/date/${date}`).pipe(
      tap(out => console.log(`Apod by date  ${JSON.stringify(out)}`)),
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
