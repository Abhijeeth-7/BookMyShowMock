import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Movie } from '../viewModels/viewModels';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
})
export class MovieDetailsComponent implements OnInit {

    movie: Movie;

  constructor(private route: ActivatedRoute, private router: Router, private sharedService: SharedService) {  }

  //change the life hook to avoid errors while coming to this page
  ngOnInit() {
    let id = history.state.movieId;
    this.sharedService.getMovie(id).subscribe(result => {
      this.movie = result;
    }, error => console.error(error));
  }

  bookTheShow() {
    this.router.navigate(['Shows'], { state: { movieId: this.movie.id}, relativeTo: this.route });
  }
}
