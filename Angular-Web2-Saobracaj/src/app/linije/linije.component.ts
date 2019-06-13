import { Component, OnInit } from '@angular/core';
import { linija } from '../Models/linija.model';
import { stanica } from '../Models/stanica.model';
import { AdminService } from '../Services/admin.service';
import { Router } from '@angular/router';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';

@Component({
  selector: 'app-linije',
  templateUrl: './linije.component.html',
  styleUrls: ['./linije.component.css']
})
export class LinijeComponent implements OnInit {
  markerInfo: stanica;
  public polyline: linija;
  public zoom: number;
  stationIcon:any;
  imeLinije;
  selektovanaStanica:stanica;

  constructor(private adminSrv:AdminService, private router:Router) { }
  inputName= false;
  rola = "";

  ngOnInit() {
      this.polyline = new linija(null, []);
      this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
      console.log(this.rola)
  }

  placeMarker($event){
    this.polyline.addLocation(new stanica($event.coords.lat, $event.coords.lng))
    console.log(this.polyline)
  }

  onSaveClicked(){
    this.polyline.RedniBroj = this.imeLinije;
    this.adminSrv.addLinija(this.polyline).subscribe(res=>{
      this.router.navigate(['/managment'])
    },error=>{console.log(error)})
  }

  onStationClicked(stanica){
    this.inputName = true;
    this.selektovanaStanica=stanica;
  }
}
