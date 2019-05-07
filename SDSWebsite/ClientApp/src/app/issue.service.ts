import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Issue } from './issue';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  private issuesUrl = 'https://g1zvmyq232.execute-api.ap-southeast-1.amazonaws.com/Prod/issues';

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  getIssues (): Observable<Issue[]> {
    return this.http.get<Issue[]>(this.issuesUrl).pipe(
      tap(_ => console.log('get issues')),
      catchError(this.handleError<Issue[]>('getIssues', []))
    );
  }

  getIssue<Data>(id: number): Observable<Issue> {
    const url = `${this.issuesUrl}/${id}`;
    return this.http.get<Issue>(url)
    .pipe(
      tap(_ => this.log(`fetched issue id=${id}`)),
      catchError(this.handleError<Issue>(`getIssue id=${id}`))
    );
  }

  private log(message: string) {
    this.messageService.add(`IssuesService: ${message}`);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
