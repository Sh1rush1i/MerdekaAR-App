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
        if(authManager.currentUser.Pejuang_Muda)
        {
            lencanaPejuangMuda.SetActive(false);
        }
        if(authManager.currentUser.Sejarawan_Cilik)
        {
            lencanaSejarawanCilik.SetActive(false);
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
