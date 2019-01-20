using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Data;
using System;
using Mono.Data.Sqlite;
using System.Threading;

public static class PolaczenieBazy {
    private static readonly string path = "URI=file:" + Application.dataPath + "/Plugins/SQLite/Hurtownia.s3db";
	private static int idZamowienia;
	public static Uzytkownik WyszukajUzytkownika(string login, string haslo){
		try{
			string sqlQuery = "SELECT * FROM Uzytkownicy WHERE (Login='" + login + "' AND Haslo='" + haslo + "');";
			Uzytkownik uzytkownik = new Uzytkownik();
        	uzytkownik.ID = -1;

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							uzytkownik.ID = reader.GetInt32(0);
							uzytkownik.Login = reader.GetString(1);
							uzytkownik.Haslo = reader.GetString(2);
							uzytkownik.NazwaFirmy = reader.GetString(3);
							uzytkownik.Adres = reader.GetString(4);
							uzytkownik.Imie = reader.GetString(5);
							uzytkownik.Nazwisko = reader.GetString(6);
							if(!reader.GetString(7).Equals(null))
								uzytkownik.Mail = reader.GetString(7);
							uzytkownik.NIP = reader.GetInt32(8);
							uzytkownik.REGON = reader.GetInt32(9);
							if(reader.GetInt32(10) != 0)
								uzytkownik.KRS = reader.GetInt32(10);
							uzytkownik.PoziomDostepu = reader.GetInt32(11);
						}
					}
    			}
  			}
        	//Debug.Log(login + " " + haslo);
        	if (uzytkownik.ID == -1) 
				return null;

			Debug.Log("id:"+uzytkownik.ID);
        	Debug.Log("login:" + uzytkownik.Login);
        	Debug.Log("haslo:" + uzytkownik.Haslo);
        	Debug.Log("imie:" + uzytkownik.Imie);
        	Debug.Log("nazwisko:" + uzytkownik.Nazwisko);

        	return uzytkownik;
		}catch(Exception e){
			Debug.Log("Blad przy wyszukiwianiu uzytkownika");
			Debug.Log(e);
		}
		return null;
	}

	public static List<Uzytkownik> ZwrocListeWszystkichUzytkownikow(){
		try{
			string sqlQuery = "SELECT * FROM Uzytkownicy ORDER BY PoziomDostepu;";
			List<Uzytkownik> listaUzytykownikow = new List<Uzytkownik>();

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							Uzytkownik uzytkownik = new Uzytkownik();
							uzytkownik.ID = reader.GetInt32(0);
							uzytkownik.Login = reader.GetString(1);
							uzytkownik.Haslo = reader.GetString(2);
							uzytkownik.NazwaFirmy = reader.GetString(3);
							uzytkownik.Adres = reader.GetString(4);
							uzytkownik.Imie = reader.GetString(5);
							uzytkownik.Nazwisko = reader.GetString(6);
							if(!reader.GetString(7).Equals(null))
								uzytkownik.Mail = reader.GetString(7);
							uzytkownik.NIP = reader.GetInt32(8);
							uzytkownik.REGON = reader.GetInt32(9);
							if(reader.GetInt32(10) != 0)
								uzytkownik.KRS = reader.GetInt32(10);
							uzytkownik.PoziomDostepu = reader.GetInt32(11);

							listaUzytykownikow.Add(uzytkownik);
						}
					}
    			}
  			}
        	return listaUzytykownikow;
		}catch(Exception e){
			Debug.Log("Blad przy zwracaniu listy wszystkich uzytkownikow");
			Debug.Log(e);
		}
		return null;
	}

	public static void ZmienDaneUzytkownika(int idUzytkownika, string nowyLogin, string noweHaslo, string nowaNazwaFirmy, string nowyAdres, string noweImie, 
						string noweNazwisko, string nowyMail, int nowyNip, int nowyRegon, int nowyKrs, int nowyPoziomDostepu){
		try{
			string sqlQuery = "UPDATE Uzytkownicy SET Login='" + nowyLogin + "', Haslo='" + noweHaslo + "', NazwaFirmy='" + nowaNazwaFirmy + 
			"', Adres='" + nowyAdres + "', Imie='" + noweImie + "', Nazwisko='" + noweNazwisko + "', Mail='" + nowyMail + "', NIP='" + nowyNip + 
			"', REGON='" + nowyRegon + "', KRS='" + nowyKrs + "', PoziomDostepu='" + nowyPoziomDostepu + "' WHERE (id='" + idUzytkownika + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
					}
    			}
  			}
		}catch(Exception e){
			Debug.Log("Blad przy zmianie danych uzytkownika");
			Debug.Log(e);
		}
	}

	public static void ZmienWartosciPrzedmiotu(int idPrzedmiotu, string nowaNazwa, float nowaCena, int nowaIlosc, string nowyOpis){
		try{
			string sqlQuery = "UPDATE Przedmioty SET Nazwa='" + nowaNazwa + "', Cena='" + nowaCena + "', Ilosc='" + nowaIlosc + "', Opis='" + nowyOpis + 
			"' WHERE (id='" + idPrzedmiotu + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
					}
    			}
  			}
		}catch(Exception e){
			Debug.Log("Blad przy zmianie wartosci przedmiotu");
			Debug.Log(e);
		}
	}

    public static String DodajNowyPrzedmiot(Przedmiot przedmiot)
    {
        try
        {
            string sqlQuery = "INSERT INTO Przedmioty(Nazwa, Cena, Ilosc, Opis) VALUES('" + przedmiot.Nazwa + "', '" + przedmiot.Cena + "', '" + przedmiot.CalkowitaIlosc +
            "', '" + przedmiot.Opis + "');";

            using (IDbConnection connection = new SqliteConnection(path) as IDbConnection)
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            return "Pomyslnie dodano przedmiot";
        }
        catch (Exception e)
        {
            Debug.Log("Blad przy dodawaniu nowego przedmiotu");
            Debug.Log(e);
            return "Nie udalo sie dodac przedmiotu";
        }
    }

    public static void UsunPrzedmiot(int idPrzedmiotu)
    {
        try
        {
            string sqlQuery = "DELETE FROM Przedmioty WHERE(id = '" + idPrzedmiotu + "'); ";


            using (IDbConnection connection = new SqliteConnection(path) as IDbConnection)
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Blad przy zmianie wartosci przedmiotu");
            Debug.Log(e);
        }
    }

    public static List<Przedmiot> ZwrocWszystkiePrzedmioty(){
		List<Przedmiot> ListaPrzedmiotow = ZwrocListePrzedmiotow("SELECT * FROM Przedmioty;");
		if (ListaPrzedmiotow.Count == 0) 
			return null;
        else 
			return ListaPrzedmiotow;
	}

	public static List<Przedmiot> ZwrocWszystkiePrzedmiotyPoNazwie(string zawiera){
        List<Przedmiot>  tmp = ZwrocListePrzedmiotow("SELECT * FROM Przedmioty WHERE (Nazwa LIKE '%" + zawiera + "%');");
        if (tmp.Count == 0) 
			return null;
        else 
			return tmp;
    }

	public static void ZmienHaslo(Uzytkownik uzytkownik, string noweHaslo){
		try{
			string sqlQuery = "UPDATE Uzytkownicy SET Haslo='" + noweHaslo + "' WHERE (Login='" + uzytkownik.Login + "' AND id='" + uzytkownik.ID + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						uzytkownik.Haslo = noweHaslo;
					}
    			}
  			}
		}catch(Exception e){
			Debug.Log("Blad przy zmianie hasla uzytkownika");
			Debug.Log(e);
		}
	}

	public static String DodajNowegoUzytkownika(Uzytkownik uzytkownik){
		try{
			string sqlQuery = "INSERT INTO Uzytkownicy (Login, Haslo, NazwaFirmy, Adres, Imie, Nazwisko, Mail, NIP, REGON, KRS, PoziomDostepu) VALUES" +  
				"('" + uzytkownik.Login + "', '" + uzytkownik.Haslo +"', '" + uzytkownik.NazwaFirmy +"', '" + uzytkownik.Adres + "'," +
				"'"+ uzytkownik.Imie + "', '"+ uzytkownik.Nazwisko +"', '"+ uzytkownik.Mail +"', '"+ uzytkownik.NIP +"', '"+ uzytkownik.REGON +"', '"
				+ uzytkownik.KRS + "', '" + 0 + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
					}
    			}
  			}			
		}
		catch(SqliteException){
			return "Login, NIP, REGON lub KRS nie sa poprawne!";
		}
		return "Uzytkownik pomyslnie dodany";
	}

	public static void DodajNoweZamowienie(Zamowienie zamowienie){
		try{

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					string sqlQuery = "INSERT INTO Zamowienia (ID_Uzytkownika, DataZakupu, IloscZakupionychPrzedmiotow, CalkowitaKwotaZakupu, PostepZamowienia) " +
									"VALUES ('"+ zamowienie.IdUzytkownika +"', '" + zamowienie.DataZakupu + "', '" + zamowienie.IloscZakupionychPrzedmiotow + 
									"', '"+ zamowienie.CalkowitaKwotaZakupu +"', '0');";
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
					}

    			}

				using (IDbCommand command = connection.CreateCommand()) {
					string sqlQuery = "SELECT * FROM Zamowienia ORDER BY ID DESC LIMIT 1;";
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							idZamowienia = reader.GetInt32(0);
						}
					}
					
    			}

				foreach(Przedmiot przedmiot in zamowienie.ListaPrzedmiotow){
					using (IDbCommand command = connection.CreateCommand()) {
						string sqlQuery = "INSERT INTO PrzedmiotyZamowienia (ID_Przedmiotu, ID_Zamowienia) VALUES ('"+ przedmiot.ID +
								"', '" + idZamowienia + "');";
						command.CommandText = sqlQuery;
						using (IDataReader reader = command.ExecuteReader()){
						}
					
    				}
				}
  			}			
		}
		catch(Exception e){
			Debug.Log("Blad przy dodawaniu nowego zamowienia");
			Debug.Log(e);
		}
	}

	public static List<Zamowienie> ZwrocListeZamowienDoUzytkownika(Uzytkownik uzytkownik){
		try{
			List<Zamowienie> listaZamowien = new List<Zamowienie>();
			string sqlQuery = "SELECT * FROM Zamowienia WHERE (ID_Uzytkownika = '" + uzytkownik.ID + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							Zamowienie noweZamowienie = new Zamowienie(){
								ID = reader.GetInt32(0),
								IdUzytkownika = reader.GetInt32(1),
								DataZakupu = reader.GetString(2),
								IloscZakupionychPrzedmiotow = reader.GetInt32(3),
								CalkowitaKwotaZakupu = reader.GetFloat(4),
								PostepZamowienia = reader.GetInt32(5)
							};
							listaZamowien.Add(noweZamowienie);
						}
					}
    			}
  			}
			foreach(Zamowienie zamowienie in listaZamowien){
				zamowienie.ListaPrzedmiotow = ZwrocListePrzedmiotowDlaZamowienia(zamowienie.ID);
			}
			return listaZamowien;
		}catch(Exception e){
			Debug.Log("Blad przy zwracaniu listy zamowien dla uzytkownika");
			Debug.Log(e);
		}
		return null;
	}

	public static List<Zamowienie> ZwrocWszystkieZamowieniaPoRealizacji(){
		try{
			List<Zamowienie> listaZamowien = new List<Zamowienie>();
			string sqlQuery = "SELECT * FROM Zamowienia ORDER BY PostepZamowienia;";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							Zamowienie noweZamowienie = new Zamowienie(){
								ID = reader.GetInt32(0),
								IdUzytkownika = reader.GetInt32(1),
								DataZakupu = reader.GetString(2),
								IloscZakupionychPrzedmiotow = reader.GetInt32(3),
								CalkowitaKwotaZakupu = reader.GetFloat(4),
								PostepZamowienia = reader.GetInt32(5)
							};
							listaZamowien.Add(noweZamowienie);
						}
					}
    			}
  			}
			foreach(Zamowienie zamowienie in listaZamowien){
				zamowienie.ListaPrzedmiotow = ZwrocListePrzedmiotowDlaZamowienia(zamowienie.ID);
			}
			return listaZamowien;
		}catch(Exception e){
			Debug.Log("Blad przy zwracaniu listy zamowien po realizacji");
			Debug.Log(e);
		}
		return null;
	}

	public static void ZmienStatusZamowieniaPlusJeden(int idZamowienia, int nowyPostep){
		try{
			string sqlQuery = "UPDATE Zamowienia SET PostepZamowienia='"+ nowyPostep +"' WHERE (ID = '" + idZamowienia + "');";

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
					}
    			}
  			}
		}catch(Exception e){
			Debug.Log("Blad przy zmianie statusu zamowienia");
			Debug.Log(e);
		}
	}

	private static List<Przedmiot> ZwrocListePrzedmiotowDlaZamowienia(int idZamowienia){
		try{
			List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
			List<int> idPrzedmiotow = new List<int>();

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					string sqlQuery = "SELECT * FROM PrzedmiotyZamowienia WHERE (ID_Zamowienia = '" + idZamowienia + "');";
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
							idPrzedmiotow.Add(reader.GetInt32(1));
						}
					}
    			}
				
				foreach(int idPrzedmiotu in idPrzedmiotow){
					using (IDbCommand command = connection.CreateCommand()) {
						string sqlQuery = "SELECT * FROM Przedmioty WHERE (id = '" + idPrzedmiotu + "');";
						command.CommandText = sqlQuery;
						using (IDataReader reader = command.ExecuteReader()){
							while(reader.Read()){
								Przedmiot przedmiot = new Przedmiot{
                					ID = reader.GetInt32(0),
                					Nazwa = reader.GetString(1),
                					Cena = reader.GetFloat(2),
                					CalkowitaIlosc = reader.GetInt32(3),
                					Opis = reader.GetString(4)
								};
            					listaPrzedmiotow.Add(przedmiot);
							}
						}
    				}
				}
  			}
			return listaPrzedmiotow;
		}catch(Exception e){
			Debug.Log("Blad przy zwracaniu listy przedmiotow dla zamowienia");
			Debug.Log(e);
		}
		return null;
	}

	private static List<Przedmiot> ZwrocListePrzedmiotow(string komenda){
		try{
			List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
			string sqlQuery = komenda;
			Debug.Log(komenda);

			using (IDbConnection connection = new SqliteConnection(path) as IDbConnection) {
    			connection.Open();

    			using (IDbCommand command = connection.CreateCommand()) {
					command.CommandText = sqlQuery;
					using (IDataReader reader = command.ExecuteReader()){
						while(reader.Read()){
            				Przedmiot przedmiot = new Przedmiot{
                				ID = reader.GetInt32(0),
                				Nazwa = reader.GetString(1),
                				Cena = reader.GetFloat(2),
                				CalkowitaIlosc = reader.GetInt32(3),
                				Opis = reader.GetString(4)
            				};
            				listaPrzedmiotow.Add(przedmiot);
						}
					}
    			}
  			}
			return listaPrzedmiotow;
		}catch(Exception e){
			Debug.Log("Blad przy zwracaniu listy przedmiotow");
			Debug.Log(e);
		}
		return null;
	}
}
