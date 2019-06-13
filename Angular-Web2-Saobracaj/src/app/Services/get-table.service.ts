import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { PriceList} from 'src/app/Models/pricingModel'
import {BusStation} from '../Models/busStation.model'
import {BusLine} from '../Models/busLine.model'
import {BusTimetable} from '../Models/busTimetables.model'
import {BusController} from '../Models/busController.model'
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Injectable({
  providedIn: 'root'
})
export class GetTableService {

  constructor(private http:HttpClient) { }

  private messageSource = new BehaviorSubject("default");
  message = this.messageSource.asObservable();

  private pricesSource = new BehaviorSubject(null);
  prices = this.pricesSource.asObservable();

  private controllerSource = new BehaviorSubject(null);
  controller = this.controllerSource.asObservable();

  private timetableSource = new BehaviorSubject(null);
  timetable = this.timetableSource.asObservable();

  changePrices(prices:PriceList[])
  {
    this.pricesSource.next(prices);
  }

  changeController(controller:BusController[])
  {
    this.controllerSource.next(controller);
  }

  changeTimetable(timetable:BusTimetable[])
  {
    this.timetableSource.next(timetable);
  }

  changeMessage(msg:string){
    this.messageSource.next(msg);
  }

  deletePriceList(id){
    return this.http.delete('http://localhost:52295/api/CenaStavkes?id='+id);
  }

  getTableService(tableName:string):Observable<any>{

    if(tableName === 'Price'){
      return this.http.get<PriceList>('http://localhost:52295/api/CenaStavkes')
    }
    else if(tableName === 'busLine'){
      return this.http.get<BusLine>('http://localhost:52295/api/Linijas')

    }
    else if(tableName === 'busStation'){
      return this.http.get<BusStation>('http://localhost:52295/api/Stanicas')
    }
    else if(tableName === 'busTimetable'){
      return this.http.get<BusTimetable>('http://localhost:52295/RedVoznjes/AllRedoviVoznje')

    }
    else if(tableName === 'busControllers'){
      return this.http.get<BusController>('http://localhost:52295/api/Korisniks')

    }
  }
}