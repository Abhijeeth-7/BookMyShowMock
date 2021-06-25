import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { Seat } from '../viewModels/viewModels';

@Component({
  selector: 'app-seat-booking',
  templateUrl: './seat-booking.component.html',
})
export class SeatBookingComponent implements OnInit {

    public seats: Seat[];
    selectedSeatIds: string[] = [];

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router) {  }

  ngOnInit() {
    let showId = history.state.showId;
    this.sharedService.getSeatingPlan(showId).subscribe(result => {
      this.seats = result;
    }, error => console.error(error));
  }

  toggleSeatSelection(seatId: string) {
    let index = this.selectedSeatIds.indexOf(seatId);
    if (index == -1) {
      this.selectedSeatIds.push(seatId);
    }
    else {
      this.selectedSeatIds.splice(index, 1);
    }
  }

  bookTickets() {
    this.router.navigate(['Ticket'], {
      state: {
        selectedSeats: this.selectedSeatIds
      },
      relativeTo: this.route
    })
  }
}

