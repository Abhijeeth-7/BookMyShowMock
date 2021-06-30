import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { ShowTimingsComponent } from './show-timings/show-timings.component';
import { SeatBookingComponent } from './seat-booking/seat-booking.component';
import { TicketBookingComponent } from './ticket-booking/ticket-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MovieDetailsComponent,
    ShowTimingsComponent,
    SeatBookingComponent,
    TicketBookingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-top-full-width',
        closeButton: true,
        timeOut: 0,
        //extendedTimeOut:0
      }
    ),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'MovieDetails/:name', component: MovieDetailsComponent },
      { path: 'MovieDetails/:name/Shows', component: ShowTimingsComponent },
      { path: 'MovieDetails/:name/Shows/:showId', component: SeatBookingComponent },
      { path: 'MovieDetails/:name/Shows/:showId/Ticket', component: TicketBookingComponent },
    ])
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
