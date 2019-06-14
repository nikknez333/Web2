import { Component, OnInit } from '@angular/core';
import { BuyTicketService } from '../Services/buy-ticket.service';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';
import { karta } from '../Models/karta.model';

@Component({
  selector: 'app-moje-karte',
  templateUrl: './moje-karte.component.html',
  styleUrls: ['./moje-karte.component.css']
})
export class MojeKarteComponent implements OnInit {

  constructor(private service:BuyTicketService, private decoder:DecodeJwtDataService) { }
  email;
  tickets:karta[];

  ngOnInit() {
    this.email = this.decoder.getEmailFromToken();
    this.service.getUserTickets(this.email).subscribe(res =>{
        this.tickets = res;
        console.log(this.tickets);
    })
  }



}
