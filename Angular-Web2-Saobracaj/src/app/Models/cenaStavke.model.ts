import { Cenovnik } from './cenovnik.model';
import { Stavka } from './stavka.model';

export class cenaStavke{
    public Id:number;
    public Cena:number;
    public Cenovnik:Cenovnik;
    public Stavka:Stavka;
}