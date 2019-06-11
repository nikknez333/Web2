import { Component, OnInit } from '@angular/core';
import { LinijeService } from '../Services/linije.service';
import { linija } from '../Models/linija.model';
import { isContentQueryHost } from '@angular/core/src/render3/util';
import { RedVoznjeService } from '../Services/red-voznje.service';

@Component({
  selector: 'app-mreza-linija',
  templateUrl: './mreza-linija.component.html',
  styleUrls: ['./mreza-linija.component.css']
})
export class MrezaLinijaComponent implements OnInit {

  constructor(private linijeService: LinijeService, private initService:RedVoznjeService) { }
  linija:linija;
  stationIcon:any;
  linSelected:string;

  sveLinije: string[];

  ngOnInit() {
    this.linija = new linija(null, []);
    this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
    this.initService.getInitialData().subscribe(res => {
      var info = JSON.parse(JSON.stringify(res));
      this.sveLinije = info.Linije;
    }); 
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

}
