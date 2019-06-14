import { Component, OnInit } from '@angular/core';
import { ValidateTicketService } from '../Services/validate-ticket.service';

@Component({
  selector: 'app-validate-tickets',
  templateUrl: './validate-tickets.component.html',
  styleUrls: ['./validate-tickets.component.css']
})
export class ValidateTicketsComponent implements OnInit {

  constructor(private validateService: ValidateTicketService) { }
  btnClicked=false;

  ngOnInit() {
  }
  isValid = false;
  validText = "Invalid";

  onValidate(ticketId)
  {
    if(ticketId != null)
    {
      this.validateService.validateTicket(ticketId).subscribe(res => {
        this.isValid = res;
        this.btnClicked=true;
        this.validText = this.isValid ? 'Valid' : 'Invalid';
      }, 
      error =>{
        this.isValid = false;
        this.btnClicked=false;
        console.log(error);
      });      
    }
  }
}
