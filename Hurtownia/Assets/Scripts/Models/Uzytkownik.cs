using System.Collections.Generic;
public class Uzytkownik{
	public int ID {get; set;}
	public string Login {get; set;}
	public string Haslo {get; set;}
	public string Imie {get; set;}
	public string Nazwisko {get; set;}
	public List<Zamowienie> ListaZamowien {get; set;}
	public List<Faktura> ListaFaktur {get; set;}
}
