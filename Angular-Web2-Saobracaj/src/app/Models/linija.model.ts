import { stanica } from './stanica.model';

export class linija{
    public RedniBroj: string;
    public Stanice: stanica[];

    constructor(broj:string, stanice:stanica[]){
        this.RedniBroj = broj;
        this.Stanice = stanice;
    }
}