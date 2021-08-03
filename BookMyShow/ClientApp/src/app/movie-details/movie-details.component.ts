 import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Movie } from '../viewModels/viewModels';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
})
export class MovieDetailsComponent implements OnInit {

    movie: Movie;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sharedService: SharedService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    let movieId = history.state.movieId || this.sharedService.movieId;
    if (movieId == null) {
      this.toastr.error("Please go back to Movies Page and Select a movie", "Invalid Path");
    }
    else {
      this.sharedService.getMovie(movieId).subscribe(result => {
        this.movie = result;
      }, error => this.toastr.error(error.message, `Error Code ${error.status}`));
    }
  }

  bookTheShow() {
    this.router.navigate(['Shows'], { state: { movieId: this.movie.id, movieTitle: this.movie.title }, relativeTo: this.route });
  }
}
