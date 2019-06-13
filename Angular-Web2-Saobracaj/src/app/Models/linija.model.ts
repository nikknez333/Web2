import { stanica } from './stanica.model';

export class linija{
    public Id:number;
    public RedniBroj: string;
    public Stanice: stanica[];

    constructor(broj:string, stanice:stanica[]){
        this.RedniBroj = broj;
        this.Stanice = stanice;
    }

    addLocation(stan:stanica){
        this.Stanice.push(stan);
    }
}