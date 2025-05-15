using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VurinaFind : MonoBehaviour
{

    private VurinaScript vurinaScript;
    [Header("References")]
    public GameObject RealVurinaPanel;
    public GameObject VurinaPanel;
    [Space(10)]
    private AuthManager authManager;
    private Gallery gallery;

    void Start()
    {
        authManager = GetComponent<AuthManager>();
        vurinaScript = GetComponent<VurinaScript>();
        gallery = GetComponent<Gallery>();
    }

    private void enableVurina()
    {
        VurinaPanel.SetActive(false);
        RealVurinaPanel.SetActive(true);
    }
    public void Soekarno()
    {
        if(!authManager.currentUser.Soekarno)
        {
            authManager.currentUser.Soekarno = true;
            authManager.Save();
        }
        vurinaScript.enableVurina(gallery.SoekarnosScriptableObject);
        enableVurina();
    }
    public void Hatta()
    {
        if(!authManager.currentUser.Hatta)
        {
            authManager.currentUser.Hatta = true;
            authManager.Save();
        }
        vurinaScript.enableVurina(gallery.HattaScriptableObject);
        enableVurina();
    }
    public void Diorama_Proklamasi()
    {
        if(!authManager.currentUser.Diorama_Proklamasi)
        {
            authManager.currentUser.Diorama_Proklamasi = true;
            authManager.Save();
        }
        vurinaScript.enableVurina(gallery.Diorama_ProklamasiScriptableObject);
        enableVurina();
    }
    public void Dokumen_Proklamasi()
    {
        if(!authManager.currentUser.Dokumen_Proklamasi)
        {
            authManager.currentUser.Dokumen_Proklamasi = true;
            authManager.Save();
        }
        vurinaScript.enableVurina(gallery.Dokumen_ProklamasiScriptableObject);
        enableVurina();
    }
    public void Rumah_Soekarno_Hatta()
    {
        if(!authManager.currentUser.Rumah_Soekarno)
        {
            authManager.currentUser.Rumah_Soekarno = true;
            authManager.Save();
        }
        vurinaScript.enableVurina(gallery.Rumah_Soekarno_HattaScriptableObject);
        enableVurina();
    }

}
