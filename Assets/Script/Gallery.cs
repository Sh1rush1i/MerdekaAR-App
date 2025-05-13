using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    private VurinaScript vurinaScript;
    [Header("References")]
    public GameObject galeryPanel;
    public GameObject VurinaPanel;
    [Space(10)]
    private AuthManager authManager;

    [Header("Achievement Locks")]
    public GameObject SoekarnosLock;
    public GameObject HattaLock;
    public GameObject Diorama_ProklamasiLock;
    public GameObject Dokumen_ProklamasiLock;
    public GameObject Rumah_Soekarno_HattaLock;
    [Space(50)]
    [Header("Stars ")]
    public GameObject Quiz_Stars_1;
    public GameObject Quiz_Stars_2;
    public GameObject Quiz_Stars_3;
    public GameObject Quiz_Stars_4;
    public GameObject Quiz_Stars_5;
    [Space(50)]
    [Header("Scriptable Object")]
    public GameObjectScript SoekarnosScriptableObject;
    public GameObjectScript HattaScriptableObject;
    public GameObjectScript Diorama_ProklamasiScriptableObject;
    public GameObjectScript Dokumen_ProklamasiScriptableObject;
    public GameObjectScript Rumah_Soekarno_HattaScriptableObject;

    void Start()
    {
        authManager = GetComponent<AuthManager>();
        vurinaScript = GetComponent<VurinaScript>();
    }

    public void UpdateLocks()
    {
        SoekarnosLock.SetActive(!authManager.currentUser.Soekarno);
        HattaLock.SetActive(!authManager.currentUser.Hatta);
        Diorama_ProklamasiLock.SetActive(!authManager.currentUser.Diorama_Proklamasi);
        Dokumen_ProklamasiLock.SetActive(!authManager.currentUser.Dokumen_Proklamasi);
        Rumah_Soekarno_HattaLock.SetActive(!authManager.currentUser.Rumah_Soekarno);

        Quiz_Stars_1.SetActive(authManager.currentUser.Quiz_Star_1);
        Quiz_Stars_2.SetActive(authManager.currentUser.Quiz_Star_2);
        Quiz_Stars_3.SetActive(authManager.currentUser.Quiz_Star_3);
        Quiz_Stars_4.SetActive(authManager.currentUser.Quiz_Star_4);
        Quiz_Stars_5.SetActive(authManager.currentUser.Quiz_Star_5);
    }
    void enablevurina()
    {
        VurinaPanel.SetActive(true);
        galeryPanel.SetActive(false);
    }
    public void Soekarno()
    {
        if(authManager.currentUser.Soekarno)
        {
            enablevurina();
            vurinaScript.enableVurina(SoekarnosScriptableObject);
        }
    }
    public void Hatta()
    {
        if(authManager.currentUser.Hatta)
        {
            enablevurina();
            vurinaScript.enableVurina(HattaScriptableObject);
        }
    }
    public void Diorama_Proklamasi()
    {
        if(authManager.currentUser.Diorama_Proklamasi)
        {
            enablevurina();
            vurinaScript.enableVurina(Diorama_ProklamasiScriptableObject);
        }
    }
    public void Dokumen_Proklamasi()
    {
        if(authManager.currentUser.Dokumen_Proklamasi)
        {
            enablevurina();
            vurinaScript.enableVurina(Dokumen_ProklamasiScriptableObject);
        }
    }
    public void Rumah_Soekarno()
    {
        if(authManager.currentUser.Rumah_Soekarno)
        {
            enablevurina();
            vurinaScript.enableVurina(Rumah_Soekarno_HattaScriptableObject);    
        }
    }

}
