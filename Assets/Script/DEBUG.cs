using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DEBUG : MonoBehaviour
{
    public enum ButtonAction
    {
        Soekarno,
        Hatta,
        Diorama_Proklamasi,
        Dokumen_Proklamasi,
        Rumah_Soekarno
    }

    public ButtonAction selectedAction;
    private VurinaFind vurinaFind;
    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        vurinaFind = GetComponent<VurinaFind>();
    }
    void Update()
    {
        textMeshProUGUI.text = selectedAction.ToString();
    }
    public void SetButtonAction(String action)
    {
        switch (action)
        {
            case "Soekarno":
                selectedAction = ButtonAction.Soekarno;
                break;
            case "Hatta":
                selectedAction = ButtonAction.Hatta;
                break;
            case "Diorama_Proklamasi":
                selectedAction = ButtonAction.Diorama_Proklamasi;
                break;
            case "Dokumen_Proklamasi":
                selectedAction = ButtonAction.Dokumen_Proklamasi;
                break;
            case "Rumah_Soekarno":
                selectedAction = ButtonAction.Rumah_Soekarno;
                break;
        }
    }


    public void HandleButtonClick()
    {
        switch(selectedAction)
        {
            case ButtonAction.Soekarno:
                vurinaFind.Soekarno();
                break;
            case ButtonAction.Hatta:
                vurinaFind.Hatta();
                break;
            case ButtonAction.Diorama_Proklamasi:
                vurinaFind.Diorama_Proklamasi();
                break;
            case ButtonAction.Dokumen_Proklamasi:
                vurinaFind.Dokumen_Proklamasi();
                break;
            case ButtonAction.Rumah_Soekarno:
                vurinaFind.Rumah_Soekarno_Hatta();
                break;
        }
    }
}
