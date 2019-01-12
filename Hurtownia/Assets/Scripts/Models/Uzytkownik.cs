using System.Collections.Generic;
public class Uzytkownik{
	public int ID {get; set;}
	public string Login {get; set;}
	public string Haslo {get; set;}
	public string NazwaFirmy {get; set;}
	public string Adres {get; set;}
	public string Mail {get; set;}
	public string Imie {get; set;}
	public string Nazwisko {get; set;}
	public int NIP {get; set;}
	public int REGON {get; set;}
	public int KRS {get; set;}
	public int PoziomDostepu {get; set;}
	public List<Zamowienie> ListaZamowien {get; set;}
}
