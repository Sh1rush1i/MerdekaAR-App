using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VurinaScript : MonoBehaviour
{
    private DialogueDisplay dialogueDisplay;
    [Header("References")]
    public GameObject VurinaPanel;
    public GameObject galeryPanel;
    public GameObject QuizPanel;
    public AudioSource audioSource;

    [Header("references GAMEOBJECT DAN JUDOL")]
    public TextMeshProUGUI TextJudol;
    public TextMeshProUGUI TextJudol2;
    public TextMeshProUGUI TextJudol3;
    public TextMeshProUGUI TextJudol4;
    public GameObject prefebsVerina;
    [Header("Scriptable Object")]
    public GameObjectScript gameObjectData;
    [Header("Gameobject ")]
    public GameObject Soekarno;
    public GameObject Hatta;
    public GameObject Diorama_Proklamasi;
    public GameObject Dokumen_Proklamasi;
    public GameObject Rumah_Soekarno_Hatta;
    void Start()
    {
        dialogueDisplay = GetComponent<DialogueDisplay>();
    }

    // Update is called once per frame
    public void enableVurina(GameObjectScript gameObjectScript)
    {
        gameObjectData = gameObjectScript;
        Debug.Log("VurinaScript: " + gameObjectData.objectName);
        TextJudol.text = gameObjectData.objectName;
        TextJudol2.text = gameObjectData.objectName;
        TextJudol3.text = gameObjectData.objectName;
        TextJudol4.text = gameObjectData.objectName;
        audioSource.clip = gameObjectData.audioClip;


        if (gameObjectData.objectName == "Soekarno")
        {
            Soekarno.SetActive(true);
        }
        else if (gameObjectData.objectName == "Hatta")
        {
            Hatta.SetActive(true);
        }
        else if (gameObjectData.objectName == "Diorama Proklamasi")
        {
            Diorama_Proklamasi.SetActive(true);
        }
        else if (gameObjectData.objectName == "Dokumen Proklamasi")
        {
            Dokumen_Proklamasi.SetActive(true);
        }
        else if (gameObjectData.objectName == "Rumah Soekarno")
        {
            Rumah_Soekarno_Hatta.SetActive(true);
        }
        turnonaudio();
    }
    public void turnonaudio()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            audioSource.Play();
        }
    }
    public void turnoffaudio()
    {
        audioSource.Stop();
    }

    public void disableall()
    {
        turnoffaudio();
        Soekarno.SetActive(false);
        Hatta.SetActive(false);
        Diorama_Proklamasi.SetActive(false);
        Dokumen_Proklamasi.SetActive(false);
        Rumah_Soekarno_Hatta.SetActive(false);
    }
    public void Startquiz()
    {
        VurinaPanel.SetActive(false);
        QuizPanel.SetActive(true);
        dialogueDisplay.StartDialogue(gameObjectData);
    }
}
