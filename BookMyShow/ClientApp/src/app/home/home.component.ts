import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Movie } from '../viewModels/viewModels';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public movies: Movie[];

  constructor(private sharedService: SharedService, private router: Router) {  }

  ngOnInit(): void {
    this.sharedService.getMovies().subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  selectMovie(movie: Movie) {
    this.router.navigate(['/MovieDetails', movie.title], { state: { movieId: movie.id } });
  }

}
