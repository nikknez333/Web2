import { Component, OnInit } from '@angular/core';
import { AdminTableComponent } from '../admin-table/admin-table.component';
import { GetTableService } from '../Services/get-table.service';
import { PriceList } from '../Models/pricingModel';

@Component({
  selector: 'app-admin-managment',
  templateUrl: './admin-managment.component.html',
  styleUrls: ['./admin-managment.component.css']
})
export class AdminManagmentComponent implements OnInit {

  constructor(private table:GetTableService) { }

  message="";
  listPrices:PriceList[];

  ngOnInit() {
    this.table.message.subscribe(msg => this.message = msg);
  }

  getTable(tableName:string){
    this.table.getTableService(tableName).subscribe(res =>{ 
      //let info = JSON.parse(JSON.stringify(res));
      this.listPrices = res;
      console.log( this.listPrices);
      this.table.changePrices(this.listPrices);
    });
    console.log('usao admMan');
    this.table.changeMessage(tableName);
    console.log(this.message);
    }
  }

