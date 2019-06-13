import { Component, OnInit } from '@angular/core';
import { GetTableService } from '../Services/get-table.service';
import { PriceList } from '../Models/pricingModel';

@Component({
  selector: 'app-admin-table',
  templateUrl: './admin-table.component.html',
  styleUrls: ['./admin-table.component.css']
})
export class AdminTableComponent implements OnInit {

  constructor(private table:GetTableService) {}
  clicked="Price";
  listPrices:PriceList[];
  ngOnInit() {
    this.table.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.table.prices.subscribe(msg =>{ this.listPrices = msg;}); 
  }

  onDeleteClick(id){
    this.table.deletePriceList(id).subscribe(res =>{
    }, error=>{console.log(error)});
  }
}