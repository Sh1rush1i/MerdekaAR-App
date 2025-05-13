using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string characterName;

    [TextArea(3, 5)]
    public string dialogueText;

    public string correctAnswer;
    public string[] wrongAnswers;
}
