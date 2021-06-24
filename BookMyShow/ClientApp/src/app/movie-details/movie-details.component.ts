import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

    movie: Movie;
    id: string;

  constructor(private route: ActivatedRoute, private router: Router, private sharedService: SharedService) { }

  //change the life hook to avoid errors while coming to this page
  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.sharedService.getMovie(+this.id).subscribe(result => {
      this.movie = result;
    }, error => console.error(error));
  }

  bookTheShow(movieId: number) {
    this.router.navigate(['Shows'], { relativeTo: this.route });
  }
}
class Movie {
  id: number;
  title: string;
  description: string;
  genre: string;
  duration: string;
}
