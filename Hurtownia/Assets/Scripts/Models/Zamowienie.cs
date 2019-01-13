using System.Collections.Generic;
public class Zamowienie {
	public int ID {get; set;}
	public List<Przedmiot> ListaPrzedmiotow {get; set;}
	public int IdUzytkownika {get; set;}
	public string DataZakupu {get; set;}
	public int IloscZakupionychPrzedmiotow {get; set;}
	public float CalkowitaKwotaZakupu {get; set;}
	public int PostepZamowienia {get; set;}
}
