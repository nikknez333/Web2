import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidateTicketService {

  constructor(private http:HttpClient) { }

  validateTicket(ticketId):Observable<any>
  {
      return this.http.get('http://localhost:52295/api/Kartas/' + ticketId);
  }
}
