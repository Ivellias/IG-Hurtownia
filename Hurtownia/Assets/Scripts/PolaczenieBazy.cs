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
		dbConnection.Close();
		return uzytkownik;
	}
}
