using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Data;
using System;
using Mono.Data.Sqlite;
using System.Threading;

public class PolaczenieBazy: MonoBehaviour {
	private readonly string path = "URI=file:" + Application.dataPath + "/Plugins/SQLite/Hurtownia.s3db";
	private IDbConnection dbConnection;
	private int idZamowienia;
	public PolaczenieBazy(){
        dbConnection = (IDbConnection)new SqliteConnection(path);
	}
	public Uzytkownik WyszukajUzytkownika(string login, string haslo){
		try{
			dbConnection.Open();
			IDbCommand dbCommand = dbConnection.CreateCommand();
        	Debug.Log(login + " " + haslo);
			dbCommand.CommandText = "SELECT * FROM Uzytkownicy WHERE (Login='" + login + "' AND Haslo='" + haslo + "');";
			IDataReader reader = dbCommand.ExecuteReader();
			Uzytkownik uzytkownik = new Uzytkownik();
        	uzytkownik.ID = -1;
			while(reader.Read()){
				uzytkownik.ID = reader.GetInt32(0);
				uzytkownik.Login = reader.GetString(1);
				uzytkownik.Haslo = reader.GetString(2);
				uzytkownik.NazwaFirmy = reader.GetString(3);
				uzytkownik.Adres = reader.GetString(4);
				uzytkownik.Imie = reader.GetString(5);
				uzytkownik.Nazwisko = reader.GetString(6);
				//uzytkownik.Mail = reader.GetString(7);
				uzytkownik.NIP = reader.GetInt32(8);
				uzytkownik.REGON = reader.GetInt32(9);
				uzytkownik.KRS = reader.GetInt32(10);
				uzytkownik.PoziomDostepu = reader.GetInt32(11);
			}
        	if (uzytkownik.ID == -1) return null;
			Debug.Log("id:"+uzytkownik.ID);
        	Debug.Log("login:" + uzytkownik.Login);
        	Debug.Log("haslo:" + uzytkownik.Haslo);
        	Debug.Log("imie:" + uzytkownik.Imie);
        	Debug.Log("nazwisko:" + uzytkownik.Nazwisko);
			dbConnection.Close();
        	return uzytkownik;
		}catch(Exception e){
			Debug.Log("Blad przy wyszukiwianiu uzytkownika");
			Debug.Log(e);
		}
		return null;
	}

	public List<Przedmiot> ZwrocWszystkiePrzedmioty(){
		List<Przedmiot> ListaPrzedmiotow = ZwrocListePrzedmiotow("SELECT * FROM Przedmioty;");
		if (ListaPrzedmiotow.Count == 0) return null;
        else return ListaPrzedmiotow;
	}

	public List<Przedmiot> ZwrocWszystkiePrzedmiotyPoNazwie(string zawiera){
        List<Przedmiot>  tmp = ZwrocListePrzedmiotow("SELECT * FROM Przedmioty WHERE (Nazwa LIKE '%" + zawiera + "%');");
        if (tmp.Count == 0) return null;
        else return tmp;
    }

	public void ZmienHaslo(Uzytkownik uzytkownik, string noweHaslo){
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "UPDATE Uzytkownicy SET Haslo='" + noweHaslo + "' WHERE (Login='" + uzytkownik.Login + "' AND id='" + uzytkownik.ID + "');";
		dbCommand.ExecuteReader();
		uzytkownik.Haslo = noweHaslo;
		dbConnection.Close();
	}

	public String DodajNowegoUzytkownika(Uzytkownik uzytkownik){
		try{
			dbConnection.Open();
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "INSERT INTO Uzytkownicy (Login, Haslo, NazwaFirmy, Adres, Imie, Nazwisko, Mail, NIP, REGON, KRS, PoziomDostepu) VALUES" +  
				"('" + uzytkownik.Login + "', '" + uzytkownik.Haslo +"', '" + uzytkownik.NazwaFirmy +"', '" + uzytkownik.Adres + "'," +
				"'"+ uzytkownik.Imie + "', '"+ uzytkownik.Nazwisko +"', '"+ uzytkownik.Mail +"', '"+ uzytkownik.NIP +"', '"+ uzytkownik.REGON +"', '"
				+ uzytkownik.KRS + "', '" + 0 + "');";
			dbCommand.ExecuteReader();
			dbConnection.Close();
		}
		catch(SqliteException){
			return "Login, NIP, REGON lub KRS nie sa poprawne!";
		}
		return "Uzytkownik pomyslnie dodany";
	}

	public void DodajNoweZamowienie(Zamowienie zamowienie){
		dbConnection.Open();

		new Thread(() =>{
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "INSERT INTO Zamowienia (ID_Uzytkownika, DataZakupu, IloscZakupionychPrzedmiotow, CalkowitaKwotaZakupu, PostepZamowienia) " +
			"VALUES ('"+ zamowienie.IdUzytkownika +"', '" + zamowienie.DataZakupu + "', '" + zamowienie.IloscZakupionychPrzedmiotow + 
			"', '"+ zamowienie.CalkowitaKwotaZakupu +"', '0');";
			dbCommand.ExecuteReader();
		}).Start();

		new Thread(() =>{
			IDbCommand secondCommand = dbConnection.CreateCommand();
			secondCommand.CommandText = "SELECT * FROM Zamowienia ORDER BY ID DESC LIMIT 1;";
			IDataReader secondReader = secondCommand.ExecuteReader();
			while(secondReader.Read()){
				idZamowienia = secondReader.GetInt32(0);
			}
		}).Start();

		new Thread(() =>{
			Thread.Sleep(2000);
			foreach(Przedmiot przedmiot in zamowienie.ListaPrzedmiotow){
				IDbCommand thridCommand = dbConnection.CreateCommand();
				thridCommand.CommandText = "INSERT INTO PrzedmiotyZamowienia (ID_Przedmiotu, ID_Zamowienia) VALUES ('"+ przedmiot.ID +
				"', '" + idZamowienia + "');";
				thridCommand.ExecuteReader();
			}
		}).Start();
		dbConnection.Close();
	}

	public List<Zamowienie> ZwrocListeZamowienDoUzytkownika(Uzytkownik uzytkownik){
		List<Zamowienie> listaZamowien = new List<Zamowienie>();
		dbConnection.Open();
		try{
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "SELECT * FROM Zamowienia WHERE (ID_Uzytkownika = '" + uzytkownik.ID + "');";
			IDataReader reader = dbCommand.ExecuteReader();
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
			dbConnection.Close();
			foreach(Zamowienie zamowienie in listaZamowien){
				zamowienie.ListaPrzedmiotow = ZwrocListePrzedmiotowDlaZamowienia(zamowienie.ID);
			}
		}catch(InvalidCastException e){
			Debug.Log(e);
		}
		return listaZamowien;
	}

	public List<Zamowienie> ZwrocWszystkieZamowieniaPoRealizacji(){
		List<Zamowienie> listaZamowien = new List<Zamowienie>();
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "SELECT * FROM Zamowienia ORDER BY PostepZamowienia;";
		IDataReader reader = dbCommand.ExecuteReader();
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
		dbConnection.Close();
		foreach(Zamowienie zamowienie in listaZamowien){
			zamowienie.ListaPrzedmiotow = ZwrocListePrzedmiotowDlaZamowienia(zamowienie.ID);
		}
		return listaZamowien;
	}

	public void ZmienStatusZamowieniaPlusJeden(int idZamowienia, int nowyPostep){
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "UPDATE Zamowienia SET PostepZamowienia='"+ nowyPostep +"' WHERE (ID = '" + idZamowienia + "');";
		dbCommand.ExecuteReader();
		dbConnection.Close();
	}

	private List<Przedmiot> ZwrocListePrzedmiotowDlaZamowienia(int idZamowienia){
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "SELECT * FROM PrzedmiotyZamowienia WHERE (ID_Zamowienia = '" + idZamowienia + "');";
		IDataReader reader = dbCommand.ExecuteReader();
		List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
		int idPrzedmiotu = 0;
		while(reader.Read()){
			idPrzedmiotu = reader.GetInt32(1);
		}
		IDbCommand secondCommand = dbConnection.CreateCommand();
		secondCommand.CommandText = "SELECT * FROM Przedmioty WHERE (id = '" + idPrzedmiotu + "');";
		IDataReader secondReader = secondCommand.ExecuteReader();
		while(secondReader.Read()){
			Przedmiot przedmiot = new Przedmiot{
                ID = secondReader.GetInt32(0),
                Nazwa = secondReader.GetString(1),
                Cena = secondReader.GetFloat(2),
                CalkowitaIlosc = secondReader.GetInt32(3),
                Opis = secondReader.GetString(4)
            };
            listaPrzedmiotow.Add(przedmiot);
		}
		dbConnection.Close();
		return listaPrzedmiotow;
	}

	private List<Przedmiot> ZwrocListePrzedmiotow(string komenda){
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = komenda;
        Debug.Log(komenda);
		IDataReader reader = dbCommand.ExecuteReader();
		List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
		while(reader.Read()){
            Przedmiot przedmiot = new Przedmiot
            {
                ID = reader.GetInt32(0),
                Nazwa = reader.GetString(1),
                Cena = reader.GetFloat(2),
                CalkowitaIlosc = reader.GetInt32(3),
                Opis = reader.GetString(4)
            };
            listaPrzedmiotow.Add(przedmiot);
		}
		dbConnection.Close();
		return listaPrzedmiotow;
	}
}
