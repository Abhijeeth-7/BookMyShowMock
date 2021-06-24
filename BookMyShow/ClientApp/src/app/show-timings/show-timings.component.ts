import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Show, Theater } from '../viewModels/viewModels';

@Component({
  selector: 'app-show-timings',
  templateUrl: './show-timings.component.html',
})
export class ShowTimingsComponent implements OnInit {

  shows: Show[];
  theaters: Theater[];

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router  ) {  }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.sharedService.getShows(+id).subscribe((result: {[index:string]:any} )=> {
      this.shows = result.item1;
      this.theaters = result.item2;
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

  bookTimeSlot(showId: number) {
    this.router.navigate(['' + showId], { relativeTo: this.route });
  }
}
