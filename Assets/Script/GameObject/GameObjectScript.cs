using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameObjectData", menuName = "Custom/GameObjectScript")]
public class GameObjectScript : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public AudioClip audioClip;

    [Header("Dialogue List")]
    public List<DialogueEntry> dialogues = new List<DialogueEntry>();
}
