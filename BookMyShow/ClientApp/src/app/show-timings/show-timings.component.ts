import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-show-timings',
  templateUrl: './show-timings.component.html',
  styleUrls: ['./show-timings.component.css']
})
export class ShowTimingsComponent implements OnInit {

  shows: any[];
  theaters: any[];

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router  ) {  }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.sharedService.getShows(+id).subscribe(result => {
      this.shows = result[0];
      this.theaters = result[1];
      console.log(this.shows[0].startTime)
    }, error => console.error(error));
  }

  getTime(time: string) {
    let hours: any = +time.slice(0, 2);
    let period = (hours >= 12) ? ' PM' : ' AM';
    hours = (hours > 12) ? hours - 12 : hours;
    hours = (hours < 10) ? '0' + hours : hours;
    let result = hours + time.slice(2, 5);
    result += period;
    return result
  }

  BookTimeSlot(showId: number) {
    this.router.navigate(['' + showId], { relativeTo: this.route });
  }
}
