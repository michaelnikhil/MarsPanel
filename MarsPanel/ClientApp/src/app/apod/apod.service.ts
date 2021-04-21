import { IApod } from './apod';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApodService {
  private readonly apiBaseUrl: string = '/api/apod';

  constructor(private http: HttpClient) { }

  public get(): Observable<IApod[]> {
    return this.http.get<IApod[]>(this.apiBaseUrl).pipe(
      tap(out => console.log('Apod = ' + JSON.stringify(out))),
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
