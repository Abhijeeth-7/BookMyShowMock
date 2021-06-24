import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Movie, OrderSummary, Seat, Show } from './viewModels/viewModels';

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

  GetOrderSummary(id: number, showId: number): Observable<OrderSummary> {
    return this.http.get<OrderSummary>(this.baseUrl + 'Movie/' + id + '/Show/' + showId + '/Ticket');
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.baseUrl + 'Movie');
  }

  getMovie(id: number): Observable<Movie> {
    this.id = id
    return this.http.get<Movie>(this.baseUrl + 'Movie/'+this.id);
  }

  getShows(id: number): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'Movie/' + this.id + '/Show');
  }

  getSeatingPlan(id: number, showId: number): Observable<Seat[]> {
    this.showId = showId;
    return this.http.get<Seat[]>(this.baseUrl + 'Movie/' + this.id + '/Show/' + this.showId);
  }

  ConfirmTicketBooking(body: Object): Observable<void> {
    return this.http.post<void>(this.baseUrl + 'Movie/' + this.id + '/Show/' + this.showId + '/Ticket', body);
  }
}
