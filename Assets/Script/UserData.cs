using UnityEngine;

[System.Serializable]
public class UserData
{
    public string username;
    public string hashedPassword;

    [Header("Lencana")]
    public bool Pejuang_Muda;
    public bool Sejarawan_Cilik;
    [Header("Stat")]
    public int Score;
    [Header("Level")]
    public bool Soekarno;
    public int HighScoresoekarno;
    public bool Hatta;
    public int HighScorehatta;
    public bool Diorama_Proklamasi;
    public int HighScoreDiorama_Proklamasi;
    public bool Dokumen_Proklamasi;
    public int HighScoreDokumen_Proklamasi;
    public bool Rumah_Soekarno;
    public int HighScoreRumah_Soekarno;
    [Space(10)]
    [Header("Quiz Star")]
    public bool Quiz_Star_1;
    public bool Quiz_Star_2;   
    public bool Quiz_Star_3;
    public bool Quiz_Star_4;
    public bool Quiz_Star_5;
    [Space(10)]
    [Header("Settings")]
    public float SFX;
    public float Music;


    public UserData(string username, string password)
    {
        this.username = username;
        this.hashedPassword = PasswordHasher.Hash(password);

        Pejuang_Muda = false;
        Sejarawan_Cilik = false;
        Soekarno = false;
        Hatta = false;
        Diorama_Proklamasi = false;
        Dokumen_Proklamasi = false;
        Rumah_Soekarno = false;
        Quiz_Star_1 = false;
        Quiz_Star_2 = false;
        Quiz_Star_3 = false;
        Quiz_Star_4 = false;
        Quiz_Star_5 = false;
        Score = 0;
        HighScoresoekarno = 0;
        HighScorehatta = 0;
        HighScoreDiorama_Proklamasi = 0;
        HighScoreDokumen_Proklamasi = 0;
        HighScoreRumah_Soekarno = 0;
        SFX = 1;
        Music = 1;
    }
}
