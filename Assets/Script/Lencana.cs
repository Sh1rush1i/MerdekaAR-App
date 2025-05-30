using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lencana : MonoBehaviour
{
    private AuthManager authManager;
    public GameObject lencanaPejuangMuda;
    [Space(50)]
    public GameObject lencanaSejarawanCilik;
    void Start()
    {
        authManager = GetComponent<AuthManager>();
    }
    // Update is called once per frame
    public void UpdateAchivment()
    {
        if (authManager.currentUser.Pejuang_Muda)
        {
            lencanaPejuangMuda.SetActive(false);
        }
        if (authManager.currentUser.Sejarawan_Cilik)
        {
            lencanaSejarawanCilik.SetActive(false);
        }
        if(authManager.currentUser.Soekarno && authManager.currentUser.Hatta && authManager.currentUser.Diorama_Proklamasi && authManager.currentUser.Dokumen_Proklamasi && authManager.currentUser.Rumah_Soekarno)
        {
            authManager.currentUser.Pejuang_Muda = true;
        }
        if(authManager.currentUser.Quiz_Star_1 && authManager.currentUser.Quiz_Star_2 && authManager.currentUser.Quiz_Star_3 && authManager.currentUser.Quiz_Star_4 && authManager.currentUser.Quiz_Star_5)
        {
            authManager.currentUser.Sejarawan_Cilik = true;
        }
        UpdateDisableAchivment();
    }
        public void UpdateDisableAchivment()
    {
        if(!authManager.currentUser.Pejuang_Muda)
        {
            lencanaPejuangMuda.SetActive(true);
        }
        if(!authManager.currentUser.Sejarawan_Cilik)
        {
            lencanaSejarawanCilik.SetActive(true);
        }
    }
}
