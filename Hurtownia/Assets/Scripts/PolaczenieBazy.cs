using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Data;
using System;
using Mono.Data.Sqlite;

public class PolaczenieBazy: MonoBehaviour {
	private readonly string path = "URI=file:" + Application.dataPath + "/Plugins/SQLite/Hurtownia.s3db";
	private IDbConnection dbConnection;
	public PolaczenieBazy(){
        dbConnection = (IDbConnection)new SqliteConnection(path);
	}
	public Uzytkownik WyszukajUzytkownika(string login, string haslo){
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
			uzytkownik.Mail = reader.GetString(7);
			uzytkownik.NIP = reader.GetInt32(8);
			uzytkownik.REGON = reader.GetInt32(9);
			uzytkownik.KRS = reader.GetInt32(10);
			uzytkownik.PoziomDostepu = reader.GetInt32(11);
		}
        if (uzytkownik.ID == -1) return null;
        //PrzypiszListeZamowienDoUzytkownika(uzytkownik);
        dbConnection.Close();
        Debug.Log("id:"+uzytkownik.ID);
        Debug.Log("login:" + uzytkownik.Login);
        Debug.Log("haslo:" + uzytkownik.Haslo);
        Debug.Log("imie:" + uzytkownik.Imie);
        Debug.Log("nazwisko:" + uzytkownik.Nazwisko);
        return uzytkownik;
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
		IDataReader reader = dbCommand.ExecuteReader();
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
			IDataReader reader = dbCommand.ExecuteReader();
			dbConnection.Close();
		}
		catch(SqliteException){
			return "Login, NIP, REGON lub KRS nie sa poprawne!";
		}
		return "Uzytkownik pomyslnie dodany";
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

	private void PrzypiszListeZamowienDoUzytkownika(Uzytkownik uzytkownik){
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "SELECT * FROM Zamowienia WHERE UzytkownikID = " + uzytkownik.ID + ";";
		IDataReader reader = dbCommand.ExecuteReader();
		List<Zamowienie> ListaZamowien = new List<Zamowienie>();
		while(reader.Read()){

		}
		uzytkownik.ListaZamowien = ListaZamowien;
	}
}
