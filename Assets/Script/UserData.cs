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
    public bool Hatta;
    public bool Diorama_Proklamasi;
    public bool Dokumen_Proklamasi;
    public bool Rumah_Soekarno;
    [Space(10)]
    [Header("Quiz Star")]
    public bool Quiz_Star_1;
    public bool Quiz_Star_2;   
    public bool Quiz_Star_3;
    public bool Quiz_Star_4;
    public bool Quiz_Star_5;


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
    }
}
