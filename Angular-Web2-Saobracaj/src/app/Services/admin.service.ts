import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  addCenaStavke(data:NgForm){
    return this.http.post('http://localhost:52295/api/CenaStavkes', data.value);
  }
}
