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
		dbCommand.CommandText = "SELECT * FROM Uzytkownicy WHERE (Login='" + login + "' AND Haslo='" + haslo + "');";
		IDataReader reader = dbCommand.ExecuteReader();
		Uzytkownik uzytkownik = new Uzytkownik();
		while(reader.Read()){
			uzytkownik.ID = reader.GetInt32(0);
			uzytkownik.Login = reader.GetString(1);
			uzytkownik.Haslo = reader.GetString(2);
			uzytkownik.Imie = reader.GetString(3);
			uzytkownik.Nazwisko = reader.GetString(4);
		}
		PrzypiszListeZamowienDoUzytkownika(uzytkownik);
		dbConnection.Close();
		return uzytkownik;
	}

	public List<Przedmiot> ZwrocWszystkiePrzedmioty(){
		return ZwrocListePrzedmiotow("SELECT * FROM Przedmioty;");
	}

	public List<Przedmiot> ZwrocWszystkiePrzedmiotyPoNazwie(string zawiera){
		return ZwrocListePrzedmiotow("SELECT * FROM Przedmioty WHERE Nazwa LIKE '%" + zawiera + "%';");
	}

	public void ZaktualizujHaslo(Uzytkownik uzytkownik){

	}

	private List<Przedmiot> ZwrocListePrzedmiotow(string komenda){
		dbConnection.Open();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = komenda;
		IDataReader reader = dbCommand.ExecuteReader();
		Przedmiot przedmiot;
		List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
		while(reader.Read()){
			przedmiot = new Przedmiot();
			przedmiot.ID = reader.GetInt32(0);
			przedmiot.Nazwa = reader.GetString(1);
			przedmiot.Cena = reader.GetFloat(2);
			przedmiot.CalkowitaIlosc = reader.GetInt32(3);
			listaPrzedmiotow.Add(przedmiot);
		}
		dbConnection.Close();
		return listaPrzedmiotow;
	}

	private void PrzypiszListeZamowienDoUzytkownika(Uzytkownik uzytkownik){
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "SELECT * FROM Zamowienia WHERE;";
		IDataReader reader = dbCommand.ExecuteReader();
		List<Zamowienie> ListaZamowien = new List<Zamowienie>();
		while(reader.Read()){
		}
		uzytkownik.ListaZamowien = ListaZamowien;
	}
}
