import { Component, OnInit } from '@angular/core';
import { ValidateTicketService } from '../Services/validate-ticket.service';

@Component({
  selector: 'app-validate-tickets',
  templateUrl: './validate-tickets.component.html',
  styleUrls: ['./validate-tickets.component.css']
})
export class ValidateTicketsComponent implements OnInit {

  constructor(private validateService: ValidateTicketService) { }

  ngOnInit() {
  }
  isValid = false;

  onValidate(ticketId)
  {
    if(ticketId != null)
    {
      this.validateService.validateTicket(ticketId).subscribe(res => {
        this.isValid = res;
      }, 
      error =>{
        this.isValid = false;
        console.log(error);
      });      
    }
  }
}
