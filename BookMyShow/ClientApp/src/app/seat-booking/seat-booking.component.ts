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
    id: string;
    showId: string;

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router) {  }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.showId = this.route.snapshot.paramMap.get('showId');
    this.sharedService.getSeatingPlan(+this.id, +this.showId).subscribe(result => {
      this.seats = result;
    }, error => console.error(error));
  }

  toggleSeatSelection(seatId: string, obj: HTMLButtonElement) {
    let index = this.selectedSeatIds.indexOf(seatId);
    if (index == -1) {
      this.selectedSeatIds.push(seatId);
    }
    else {
      this.selectedSeatIds.splice(index, 1);
    }
    console.log(this.selectedSeatIds);
    if (obj.style.backgroundColor == "yellowgreen") {
      obj.style.backgroundColor = ""
      obj.style.color = ""
    }
    else {
      obj.style.backgroundColor = "yellowgreen"
      obj.style.color = "white"
    }
  }

  BookTickets() {
    this.router.navigate(['Ticket', { selectedSeats: this.selectedSeatIds }], { relativeTo: this.route })
  }
}

