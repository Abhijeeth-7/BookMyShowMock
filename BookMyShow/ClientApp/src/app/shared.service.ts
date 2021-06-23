import { HttpClient } from '@angular/common/http';
import { Inject, inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private readonly baseUrl;
  id: number;
  showId: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  GetOrderSummary(id: number, showId: number): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'Movie/' + id + '/Show/' + showId + '/Ticket');
  }

  getMovies(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'Movie');
  }

  getMovie(id: number): Observable<any> {
    this.id = id
    return this.http.get<any>(this.baseUrl + 'Movie/'+this.id);
  }

  getShows(id: number): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'Movie/' + this.id + '/Show');
  }

  getSeatingPlan(id: number, showId: number): Observable<any> {
    this.showId = showId;
    return this.http.get<any[]>(this.baseUrl + 'Movie/' + this.id + '/Show/' + this.showId);
  }

  ConfirmTicketBooking(body: Object): Observable<any> {
    return this.http.post<string>(this.baseUrl + 'Movie/' + this.id + '/Show/' + this.showId + '/Ticket', body);
  }
}
