using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    
    private AuthManager authManager;

    [Header("UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI QuizText;
    public TextMeshProUGUI ScoreText;

    
    public Button[] Buttons;

    private List<DialogueEntry> currentDialogues;
    private int currentIndex = 0;
    private int Scores = 0;

void Start()
    {
        authManager = GetComponent<AuthManager>();
    }
    public void StartDialogue(GameObjectScript gameObjectData)
    {
        currentDialogues = gameObjectData.dialogues;
        currentIndex = 0;
        ShowDialogue(currentIndex);
    }

    void ShowDialogue(int index)
{
    if (currentDialogues == null || index >= currentDialogues.Count)
    {
        Debug.Log("End of dialogue.");
        nameText.text = "";
        dialogueText.text = "Selesai!";
        foreach (var btn in Buttons) btn.gameObject.SetActive(false);
        return;
    }

    DialogueEntry data = currentDialogues[index];
    nameText.text = data.characterName;
    dialogueText.text = data.dialogueText;
    QuizText.text = index + 1 + "/" + currentDialogues.Count;
    ScoreText.text = "Score: " + Scores;
    // Collect all answers
    List<(string text, bool isCorrect)> allAnswers = new List<(string, bool)>();
    allAnswers.Add((data.correctAnswer, true));

    foreach (var wrong in data.wrongAnswers)
        allAnswers.Add((wrong, false));

    // Shuffle the answers
    ShuffleList(allAnswers);

    // Assign to buttons
    for (int i = 0; i < Buttons.Length; i++)
    {
        if (i < allAnswers.Count)
        {
            Buttons[i].gameObject.SetActive(true);
            Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = allAnswers[i].text;
            Buttons[i].onClick.RemoveAllListeners();
            Buttons[i].onClick.AddListener(() =>
            {
                
                Debug.Log(allAnswers[i].isCorrect ? "Correct!" : "Wrong!");
                if (allAnswers[i].isCorrect)
                {
                    Scores += 10;
                    authManager.currentUser.Score += Scores;
                    
                    authManager.Save();
                }
                NextDialogue();
            });
        }
        else
        {
            Buttons[i].gameObject.SetActive(false);
        }
    }
}
void ShuffleList<T>(List<T> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        T temp = list[i];
        int randomIndex = Random.Range(i, list.Count);
        list[i] = list[randomIndex];
        list[randomIndex] = temp;
    }
}



    void NextDialogue()
    {
        currentIndex++;
        ShowDialogue(currentIndex);
    }
}
