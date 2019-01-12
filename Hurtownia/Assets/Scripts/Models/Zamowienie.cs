using System;
public class Zamowienie {
	public int ID {get; set;}
	public Przedmiot ZamowionyPrzedmiot {get; set;}
	public int IdUzytkownika {get; set;}
	public string DataZakupu {get; set;}
	public int IloscZakupionychPrzedmiotow {get; set;}
	public float CalkowitaKwotaZakupu {get; set;}
}
