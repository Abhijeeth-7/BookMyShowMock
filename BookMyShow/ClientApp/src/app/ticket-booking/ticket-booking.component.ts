 import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-ticket-booking',
  templateUrl: './ticket-booking.component.html',
  styleUrls: ['./ticket-booking.component.css']
})
export class TicketBookingComponent implements OnInit {

    orderSummary: any;
    ticket: any = new Object();
    date: string;
    id: string;
    showId: string;
    seatIds: string;
    isTicketBooked: boolean;

  constructor(
    private sharedService: SharedService,
    private route: ActivatedRoute,
    private router: Router
    ) {
    this.date = new Date().toUTCString().slice(0, -3);
    this.id = this.route.snapshot.paramMap.get('id');
    this.showId = this.route.snapshot.paramMap.get('showId');
    this.seatIds = this.route.snapshot.paramMap.get('selectedSeats');
  }

  ngOnInit() {
    this.sharedService.GetOrderSummary(+this.id, +this.showId).subscribe(result => {
      this.orderSummary = result;
      this.orderSummary.seatIds = this.seatIds;
      this.orderSummary.totalPrice = this.orderSummary.ticketPrice * this.orderSummary.seatIds.split(',').length
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

  BuyTickets() {
    this.createTicket();
    this.sharedService.ConfirmTicketBooking(this.ticket).subscribe(data => {
      this.isTicketBooked = true;
      console.log(data);
    }, error => console.error(error));
  }

  createTicket() {
    this.ticket.Id = 0;
    this.ticket.ShowId = +this.showId;
    this.ticket.SeatIds = []
    this.orderSummary.seatIds.split(',').forEach(seatId => {
      this.ticket.SeatIds.push(seatId);
    });
    this.ticket.Price = this.orderSummary.ticketPrice;
  }
}
