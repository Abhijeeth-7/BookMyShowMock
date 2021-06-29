import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Movie, OrderSummary, Seat, Ticket } from './viewModels/viewModels';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private readonly baseUrl;
  movieId: number;
  showId: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.baseUrl}/Movie`);
  }

  getMovie(movieId: number): Observable<Movie> {
    this.movieId = movieId;
    return this.http.get<Movie>(`${this.baseUrl}/Movie/${this.movieId}`);
  }

  getShows(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Movie/${this.movieId}/Show`);
  }

  getSeatingPlan(showId: number): Observable<Seat[]> {
    this.showId = showId;
    return this.http.get<Seat[]>(`${this.baseUrl}/Movie/${this.movieId}/Show/${this.showId}`);
  }

  getOrderSummary(): Observable<OrderSummary> {
    return this.http.get<OrderSummary>(`${this.baseUrl}/Movie/${this.movieId}/Show/${this.showId}/Ticket`);
  }

  confirmTicketBooking(ticket: Ticket): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/Movie/${this.movieId}/Show/${this.showId}/Ticket`, ticket);
  }

}
