import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ObservableLike } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuyTicketService {

  constructor(private http:HttpClient) { }

  buyTicket(stavkaId) : Observable<any>{

    var data = stavkaId;

    return this.http.post('http://localhost:52295/api/Kartas?stavkaId=' +data, data);
  }

  getTicketPrices(): Observable<any>{
    return this.http.get('http://localhost:52295/api/Kartas');
  }
}
