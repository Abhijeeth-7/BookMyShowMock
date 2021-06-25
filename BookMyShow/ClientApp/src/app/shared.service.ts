import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { Movie, OrderSummary, Seat, Show, Ticket } from './viewModels/viewModels';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private readonly baseUrl;
  movieId: number;
  showId: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute) {
    this.baseUrl = baseUrl;
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.baseUrl + 'Movie');
  }

  getMovie(movieId?: number): Observable<Movie> {
    this.movieId = movieId || this.movieId;
    return this.http.get<Movie>(this.baseUrl + 'Movie/' + this.movieId);
  }

  getShows(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'Movie/' + this.movieId + '/Show');
  }

  getSeatingPlan(showId?: number): Observable<Seat[]> {
    this.showId = showId || this.showId;
    return this.http.get<Seat[]>(this.baseUrl + 'Movie/' + this.movieId + '/Show/' + this.showId);
  }

  GetOrderSummary(): Observable<OrderSummary> {
    return this.http.get<OrderSummary>(this.baseUrl + 'Movie/' + this.movieId + '/Show/' + this.showId + '/Ticket');
  }

  ConfirmTicketBooking(ticket: Ticket): Observable<void> {
    return this.http.post<void>(this.baseUrl + 'Movie/' + this.movieId + '/Show/' + this.showId + '/Ticket', ticket);
  }
}
