import { linija } from './linija.model';
import { TipDana } from './tipDana.model';
import { TipSaobracaja } from './tipSaobracaja.model';

export class BusTimetable{
    public Id:number;
    public Polazak: string;
    public Linija: linija;
    public Dan: TipDana;
    public Saobracaj: TipSaobracaja;
}