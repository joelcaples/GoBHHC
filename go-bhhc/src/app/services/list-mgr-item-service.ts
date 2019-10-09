import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { ListMgrItem } from '../models/list-mgr-item';
import { MessageService } from './message.service';


@Injectable({ providedIn: 'root' })
export class ListMgrItemService {

  private listMgrItemsUrl = 'https://localhost:44363/api/ListMgr';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET listMgrItems from the server */
  getListMgrItems (): Observable<ListMgrItem[]> {
    return this.http.get<ListMgrItem[]>(this.listMgrItemsUrl)
      .pipe(
        tap(_ => this.log('fetched listMgrItems')),
        catchError(this.handleError<ListMgrItem[]>('getListMgrItems', []))
      );
  }

  /** GET listMgrItem by id. Return `undefined` when id not found */
  getListMgrItemNo404<Data>(id: number): Observable<ListMgrItem> {
    const url = `${this.listMgrItemsUrl}/?id=${id}`;
    return this.http.get<ListMgrItem[]>(url)
      .pipe(
        map(listMgrItems => listMgrItems[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} listMgrItem id=${id}`);
        }),
        catchError(this.handleError<ListMgrItem>(`getListMgrItem id=${id}`))
      );
  }

  /** GET listMgrItem by id. Will 404 if id not found */
  getListMgrItem(id: number): Observable<ListMgrItem> {
    const url = `${this.listMgrItemsUrl}/${id}`;
    return this.http.get<ListMgrItem>(url).pipe(
      tap(_ => this.log(`fetched listMgrItem id=${id}`)),
      catchError(this.handleError<ListMgrItem>(`getListMgrItem id=${id}`))
    );
  }

  /* GET listMgrItems whose name contains search term */
  searchListMgrItems(term: string): Observable<ListMgrItem[]> {
    if (!term.trim()) {
      // if not search term, return empty listMgrItem array.
      return of([]);
    }
    return this.http.get<ListMgrItem[]>(`${this.listMgrItemsUrl}/?description=${term}`).pipe(
      tap(_ => this.log(`found listMgrItems matching "${term}"`)),
      catchError(this.handleError<ListMgrItem[]>('searchListMgrItems', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new listMgrItem to the server */
  addListMgrItem (listMgrItem: ListMgrItem): Observable<ListMgrItem> {
    return this.http.post<ListMgrItem>(this.listMgrItemsUrl, listMgrItem, this.httpOptions).pipe(
      tap((newListMgrItem: ListMgrItem) => this.log(`added listMgrItem w/ id=${newListMgrItem.listMgrID}`)),
      catchError(this.handleError<ListMgrItem>('addListMgrItem'))
    );
  }

  /** DELETE: delete the listMgrItem from the server */
  deleteListMgrItem (listMgrItem: ListMgrItem | number): Observable<ListMgrItem> {
    const id = typeof listMgrItem === 'number' ? listMgrItem : listMgrItem.listMgrID;
    const url = `${this.listMgrItemsUrl}/${id}`;

    return this.http.delete<ListMgrItem>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted listMgrItem id=${id}`)),
      catchError(this.handleError<ListMgrItem>('deleteListMgrItem'))
    );
  }

  /** PUT: update the listMgrItem on the server */
  updateListMgrItem (listMgrItem: ListMgrItem): Observable<any> {
    const url = `${this.listMgrItemsUrl}/${listMgrItem.listMgrID}`;
    return this.http.put(url, listMgrItem, this.httpOptions).pipe(
      tap(_ => this.log(`updated listMgrItem id=${listMgrItem.listMgrID}`)),
      catchError(this.handleError<any>('updateListMgrItem'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
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

  /** Log a ListMgrItemService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`ListMgrItemService: ${message}`);
  }
}
