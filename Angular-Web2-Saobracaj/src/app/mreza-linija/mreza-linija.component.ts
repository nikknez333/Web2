import { Component, OnInit } from '@angular/core';
import { LinijeService } from '../Services/linije.service';
import { linija } from '../Models/linija.model';
import { isContentQueryHost } from '@angular/core/src/render3/util';
import { RedVoznjeService } from '../Services/red-voznje.service';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';
import { AdminService } from '../Services/admin.service';
import { stanica } from '../Models/stanica.model';

@Component({
  selector: 'app-mreza-linija',
  templateUrl: './mreza-linija.component.html',
  styleUrls: ['./mreza-linija.component.css']
})
export class MrezaLinijaComponent implements OnInit {

  constructor(private linijeService: LinijeService, private initService:RedVoznjeService, private jwt:DecodeJwtDataService, private adminSrv: AdminService) { }
  linija:linija;
  stationIcon:any;
  linSelected:string;
  rola = "";
  selektovanaStanica : stanica;
  selektovanaLinija:linija;
  sveLinije: string[];


  ngOnInit() {
    this.linija = new linija(null, []);
    this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
    this.initService.getInitialData().subscribe(res => {
      var info = JSON.parse(JSON.stringify(res));
      this.sveLinije = info.Linije;
      
    }); 
    this.rola = this.jwt.getRoleFromToken();
  }  

  onClickPrikazi(broj)
  {
    this.linijeService.getLinija(broj).subscribe(res => {
        console.log(res);
        this.linija = new linija(res.RedniBroj, res.Stanice);
        //console.log("evo ih stanice: "+ this.linija.Stanice[0].Lat);
    },
    error=>{console.log(error)}
    )
  }

  OnDeleteClicked(){
    if(this.selektovanaStanica != null){
      this.adminSrv.removeStanica(this.selektovanaStanica).subscribe(res => {});
    }
      

    if(this.selektovanaLinija != null){
      this.adminSrv.removeLinija(this.selektovanaLinija).subscribe(res=>{});
    }
      
  }

  onStationClicked(stanica){
    this.selektovanaStanica=stanica;
  }

  onLineClick(linija){
    this.selektovanaLinija = linija;
    console.log(this.selektovanaLinija);
  }

  // onMapClick(){
  //   this.selektovanaStanica= null;
  //   this.selektovanaLinija = null;
  // }

}
