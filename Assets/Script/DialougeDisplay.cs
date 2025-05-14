using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class DialogueDisplay : MonoBehaviour
{
    
    private AuthManager authManager;

    [Header("UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI QuizText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreText2;

    
    public Button[] Buttons;

    private List<DialogueEntry> currentDialogues;
    private int currentIndex = 0;
    private int Scores = 0;
    private GameObjectScript gameObjectDatas;

void Start()
    {
        authManager = GetComponent<AuthManager>();
    }
    public void StartDialogue(GameObjectScript gameObjectData)
    {
        Scores = 0;
        gameObjectDatas = gameObjectData;
        currentDialogues = gameObjectData.dialogues;
        currentIndex = 0;
        ShowDialogue(currentIndex);
    }

    void ShowDialogue(int index)
{
    ScoreText.text = "Score: " + Scores;
    ScoreText2.text = "Highscore: " + authManager.Returnhighscore(gameObjectDatas).ToString();
    if (currentDialogues == null || index >= currentDialogues.Count)
    {
        Debug.Log("End of dialogue.");
        nameText.text = "";
        
        foreach (var btn in Buttons) btn.gameObject.SetActive(false);
        if(Scores >= 100)
        {
            authManager.Checkstar(gameObjectDatas);
            dialogueText.text = "Nilai mu 100!, Selamat Kau mendapatkan Bintang!";
        }
        else
        {
            dialogueText.text = "Selesai!, kau bisa kembali dan mengulang lagi!";
        }
        gameObjectDatas = null;
        return;
    }

    DialogueEntry data = currentDialogues[index];
    nameText.text = data.characterName;
    dialogueText.text = data.dialogueText;
    QuizText.text = index + 1 + "/" + currentDialogues.Count;
    
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

        int buttonIndex = i; // fix: capture the index safely

        Buttons[i].onClick.AddListener(() =>
        {
            Debug.Log(allAnswers[buttonIndex].isCorrect ? "Correct!" : "Wrong!");
            if (allAnswers[buttonIndex].isCorrect)
            {
                Scores += 25;
                authManager.CheckHighscore(gameObjectDatas, Scores);
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
