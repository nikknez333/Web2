import { Component, OnInit } from '@angular/core';
import { GetTableService } from '../Services/get-table.service';
import { PriceList } from '../Models/pricingModel';
import { BusController } from '../Models/busController.model';
import { BusTimetable } from '../Models/busTimetables.model';

@Component({
  selector: 'app-admin-table',
  templateUrl: './admin-table.component.html',
  styleUrls: ['./admin-table.component.css']
})
export class AdminTableComponent implements OnInit {

  constructor(private table:GetTableService) {}
  clicked="Price";
  selected = false;
  listPrices:PriceList[];
  listControllers:BusController[];
  listTimetables:BusTimetable[];
  ngOnInit() {
    this.table.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.table.prices.subscribe(msg =>{ this.listPrices = msg;}); 
    this.table.controller.subscribe(msg => {this.listControllers = msg;});
    this.table.timetable.subscribe(msg => {this.listTimetables = msg;});
  }

  onPriceDeleteClick(id){
    this.table.deletePriceList(id).subscribe(res =>{
    }, error=>{console.log(error)});
  }

  onControllorDeleteClick(email){
    this.table.deleteControllor(email).subscribe(res =>{
      }, error=>{console.log(error)});
  }

}