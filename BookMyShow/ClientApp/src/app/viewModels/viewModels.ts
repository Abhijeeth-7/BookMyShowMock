export class Movie {
  id: number;
  title: string;
  description: string;
  genre: string;
  duration: string;
}

export class Show {
  id: number;
  theaterId: number;
  movieId: number;
  startTime: string;
  endTime: string;
  seatingId: number;
}

export class Theater {
  id: number;
  theaterName: string;
  totalSeats: number;
  price: number;
}

export class Ticket {
  id: number;
  showId: number;
  seatIds: string[];
  price: number;
}

export class Seat {
  Id: number;
  isAvailable: number;
}

export class OrderSummary {
  movieTitle: string;
  theaterName: string;
  showStartTime: string;
  showEndTime: string;
  ticketPrice: number;
  seatIds: string[];
  totalPrice: number;
}
