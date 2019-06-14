import { Component, OnInit } from '@angular/core';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';
import { Router } from '@angular/router';
import { BuyTicketService } from '../Services/buy-ticket.service';

@Component({
  selector: 'app-cenovnik',
  templateUrl: './cenovnik.component.html',
  styleUrls: ['./cenovnik.component.css']
})
export class CenovnikComponent implements OnInit {

  constructor(private decodeService:DecodeJwtDataService, private router:Router, private buyTicketServ:BuyTicketService) { }

  isRegistrated = false
  rola;
  data:any[];
  ngOnInit() {

    this.buyTicketServ.getTicketPrices().subscribe(res =>{
      var info = JSON.parse(JSON.stringify(res));
      this.data = info;
      
      //console.log(this.data[2].Cena);
    })

    this.rola = localStorage.getItem("token");
    if(this.rola != null)
    {
      this.isRegistrated = true;
    }

  }
  buyTicket(stavkaId){
    console.log(stavkaId)
    this.buyTicketServ.buyTicket(stavkaId).subscribe(res =>{
      this.router.navigate(['/mojeKarte']);
    });
  }

}
