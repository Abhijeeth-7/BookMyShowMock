 import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { OrderSummary, Ticket } from '../viewModels/viewModels';
import { ToastrService } from 'ngx-toastr'
import { Router } from '@angular/router';

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
    preLoadText: string = "Getting Your Order Summary Please wait...";

  constructor(private sharedService: SharedService, private router: Router, private toastr: ToastrService) {
    this.date = new Date().toUTCString().slice(0, -3);
    try {
      this.showId = this.router.getCurrentNavigation().extras.state.showId;
      this.seatIds = this.router.getCurrentNavigation().extras.state.selectedSeats;

      this.sharedService.getOrderSummary().subscribe(result => {
        this.orderSummary = result;
        this.orderSummary.seatIds = this.seatIds;
        this.orderSummary.totalPrice = this.orderSummary.ticketPrice * this.orderSummary.seatIds.length;
      }, error => this.toastr.error(error.message, `${error.status}`));
    }
    catch (e) {
      this.toastr.error("Please Go back to Movies page and Try Again", "Invalid Access");
      this.preLoadText = "Invalid Access, Go back to Movies page and try again";
    }
  }

  ngOnInit() {
    
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
    this.sharedService.confirmTicketBooking(this.ticket).subscribe(data => {
      this.isTicketBooked = true;
      this.toastr.success("Your tickets have been booked successfully", "Booking Successful !!");
    });
  }

  createTicket() {
    this.ticket.id = 0;
    this.ticket.showId = this.showId;
    this.ticket.seatIds = this.orderSummary.seatIds;
    this.ticket.price = this.orderSummary.ticketPrice;
  }
}
