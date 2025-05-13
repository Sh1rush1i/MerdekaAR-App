using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class VurinaScript : MonoBehaviour
{
    private DialogueDisplay dialogueDisplay;
    [Header("References")]
    public GameObject VurinaPanel;
    public GameObject galeryPanel;
    public GameObject QuizPanel;

    [Header("references GAMEOBJECT DAN JUDOL")]
    public TextMeshProUGUI TextJudol;
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
        TextJudol.text = gameObjectData.objectName;
    }
    public void Startquiz()
    {
        VurinaPanel.SetActive(false);
        QuizPanel.SetActive(true);
        dialogueDisplay.StartDialogue(gameObjectData);
    }
}
