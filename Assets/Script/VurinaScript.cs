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

    [Header("references GAMEOBJECT DAN JUDOL")]
    public TextMeshProUGUI TextJudol;
    public TextMeshProUGUI TextJudol2;
    public GameObject prefebsVerina;
    [Header("Scriptable Object")]
    public GameObjectScript gameObjectData;
    void Start()
    {
        dialogueDisplay = GetComponent<DialogueDisplay>();
    }

    // Update is called once per frame
    public void enableVurina(GameObjectScript gameObjectScript)
    {
        gameObjectData = gameObjectScript;
        prefebsVerina = gameObjectData.prefab;
        Debug.Log("VurinaScript: " + gameObjectData.objectName);
        TextJudol.text = gameObjectData.objectName;
        TextJudol2.text = gameObjectData.objectName;
        
    }
    public void Startquiz()
    {
        VurinaPanel.SetActive(false);
        QuizPanel.SetActive(true);
        dialogueDisplay.StartDialogue(gameObjectData);
    }
}
