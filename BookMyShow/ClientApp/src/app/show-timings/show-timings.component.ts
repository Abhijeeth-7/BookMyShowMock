import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Show, Theater } from '../viewModels/viewModels';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-show-timings',
  templateUrl: './show-timings.component.html',
})
export class ShowTimingsComponent implements OnInit {

  shows: Show[];
  theaters: Theater[];
  movieTitle: string;

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router, private toastr:ToastrService) {  }

  ngOnInit() {
    this.sharedService.getShows().subscribe((result: { [index: string]: any }) => {
      this.shows = result.item1;
      this.theaters = result.item2;
    }, error => this.toastr.error(error.message, `Error Code ${error.status}`));
    this.movieTitle = history.state.movieTitle;
  }

  getTime(time: string) {
    let hours: number|string = +time.slice(0, 2);
    let period = (hours >= 12) ? ' PM' : ' AM';
    hours = (hours > 12) ? hours - 12 : hours;
    hours = (hours < 10) ? '0' + hours : hours;
    let result = hours + time.slice(2, 5);
    result += period;
    return result
  }

  bookTimeSlot(showId: number) {
    this.router.navigate([showId], { state: { showId: showId }, relativeTo: this.route });
  }
}
