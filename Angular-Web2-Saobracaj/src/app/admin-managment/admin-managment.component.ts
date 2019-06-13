import { Component, OnInit } from '@angular/core';
import { AdminTableComponent } from '../admin-table/admin-table.component';
import { GetTableService } from '../Services/get-table.service';
import { PriceList } from '../Models/pricingModel';
<<<<<<< HEAD
import { Router } from '@angular/router';
=======
import { BusController } from '../Models/busController.model';
>>>>>>> eee2f52c14704b1c5474f0e05bd1a7decc24cbde

@Component({
  selector: 'app-admin-managment',
  templateUrl: './admin-managment.component.html',
  styleUrls: ['./admin-managment.component.css']
})
export class AdminManagmentComponent implements OnInit {

  constructor(private table:GetTableService, private router:Router) { }

  message="";
  listPrices:PriceList[];
  listControllers:BusController[];

  ngOnInit() {
    this.table.message.subscribe(msg => this.message = msg);
  }

  getTable(tableName:string){
    this.table.getTableService(tableName).subscribe(res =>{ 
      //let info = JSON.parse(JSON.stringify(res));
      if(tableName==="Price")
      {
        this.listPrices = res;
        this.table.changePrices(this.listPrices);
      }
      else if(tableName==="busControllers")
      {
        //console.log(res);
        let info = JSON.parse(JSON.stringify(res));
        this.listControllers = info;
        this.table.changeController(this.listControllers);
      }
    });
    console.log('usao admMan');
    this.table.changeMessage(tableName);
    console.log(this.message);
    }

  onAddClick(table){
    switch(table){
      case 'Price':
        this.router.navigate(['/CenaStavke'])
      break;

    }
  }
}

