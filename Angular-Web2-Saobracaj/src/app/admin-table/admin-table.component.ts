import { Component, OnInit } from '@angular/core';
import { GetTableService } from '../Services/get-table.service';
import { PriceList } from '../Models/pricingModel';
import { BusController } from '../Models/busController.model';

@Component({
  selector: 'app-admin-table',
  templateUrl: './admin-table.component.html',
  styleUrls: ['./admin-table.component.css']
})
export class AdminTableComponent implements OnInit {

  constructor(private table:GetTableService) {}
  clicked="Price";
  listPrices:PriceList[];
  listControllers:BusController[];
  ngOnInit() {
    this.table.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.table.prices.subscribe(msg =>{ this.listPrices = msg;}); 
    this.table.controller.subscribe(msg => {this.listControllers = msg;});
  }
}