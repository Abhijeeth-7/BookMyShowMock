 import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { OrderSummary, Ticket } from '../viewModels/viewModels';

@Component({
  selector: 'app-ticket-booking',
  templateUrl: './ticket-booking.component.html',
})
export class TicketBookingComponent implements OnInit {

    orderSummary: OrderSummary;
    ticket: Ticket = new Ticket();
    date: string;
    movieId: number;
    showId: number;
    seatIds: string[];
    isTicketBooked: boolean;
    errorMsg: string;

  constructor(private sharedService: SharedService, private route: ActivatedRoute, private router: Router) {
    this.date = new Date().toUTCString().slice(0, -3);
    try {
      this.showId = this.router.getCurrentNavigation().extras.state.showId;
      this.seatIds = this.router.getCurrentNavigation().extras.state.selectedSeats;
    } catch (e) {
      this.errorMsg = "Invalid Access, Try Booking Again by going back to Movies page";
    }
  }

  ngOnInit() {
    this.sharedService.GetOrderSummary().subscribe(result => {
      this.orderSummary = result;
      this.orderSummary.seatIds = this.seatIds;
      this.orderSummary.totalPrice = this.orderSummary.ticketPrice * this.orderSummary.seatIds.length;
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

  buyTickets() {
    this.createTicket();
    this.sharedService.ConfirmTicketBooking(this.ticket).subscribe(data => {
      this.isTicketBooked = true;
    }, error => console.error(error));
  }

  createTicket() {
    this.ticket.id = 0;
    this.ticket.showId = this.showId;
    this.ticket.seatIds = this.orderSummary.seatIds;
    this.ticket.price = this.orderSummary.ticketPrice;
  }
}
