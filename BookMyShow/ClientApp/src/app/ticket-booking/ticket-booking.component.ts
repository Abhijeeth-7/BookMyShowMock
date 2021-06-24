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
    ticket: Ticket = new Ticket();
    date: string;
    id: string;
    showId: string;
    seatIds: string;
    isTicketBooked: boolean;

  constructor(private sharedService: SharedService, private route: ActivatedRoute) {
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

  buyTickets() {
    this.createTicket();
    this.sharedService.ConfirmTicketBooking(this.ticket).subscribe(data => {
      this.isTicketBooked = true;
      console.log(data);
    }, error => console.error(error));
  }

  createTicket() {
    this.ticket.id = 0;
    this.ticket.showId = +this.showId;
    this.ticket.seatIds = []
    this.orderSummary.seatIds.split(',').forEach(seatId => {
      this.ticket.seatIds.push(seatId);
    });
    this.ticket.price = this.orderSummary.ticketPrice;
  }
}

class Ticket {
  id: number;
  showId: number;
  seatIds: string[];
  price: number;
}
