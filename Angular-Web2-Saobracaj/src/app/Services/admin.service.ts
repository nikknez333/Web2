import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { linija } from '../Models/linija.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  addCenaStavke(data:NgForm){
    return this.http.post('http://localhost:52295/api/CenaStavkes', data.value);
  }

  addLinija(linija:linija){
    return this.http.post('http://localhost:52295/api/Linijas', linija);
  }

  removeStanica(stanica){
    return this.http.delete('http://localhost:52295/api/Stanicas?id=' + stanica.Id);
  }

  removeLinija(linija){
    return this.http.delete('http://localhost:52295/api/Linijas?rbr=' + linija.RedniBroj);
  }
}
