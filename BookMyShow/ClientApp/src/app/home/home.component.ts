import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public movies: any[];

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router) {  }

  ngOnInit(): void {
    this.sharedService.getMovies().subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  selectMovie(movieId: number) {
    this.router.navigate(['/MovieDetails', movieId]);
  }

}
