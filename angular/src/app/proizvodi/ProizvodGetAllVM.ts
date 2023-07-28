export interface ProizvodGetAllVM{
 id:number;
 marka:string;
 cijena:number;
 slika_bajtovi?:string|null;
 slika_umanjena?:string|null;

 specifikacije:string;
 boja:string;

 proizvodTipID:number;
 proizvodTipNaziv:string;
  kratakOpisProizvoda:string;

}
