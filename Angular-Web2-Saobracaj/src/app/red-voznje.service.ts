import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RedVoznjeService {

  constructor(
    private http: HttpClient
  ) { }


  getPolasci(): Observable<string[]> {
    return this.http.get<string[]>(this.polasciUrl)
  }

  private polasciUrl = 'http://localhost:52295/api/RedVoznjes'
}
