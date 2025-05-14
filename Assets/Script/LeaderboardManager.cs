using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    [System.Serializable]
    public class LeaderboardEntryData
    {
        public string username;
        public int score;

        public LeaderboardEntryData(string username, int score)
        {
            this.username = username;
            this.score = score;
        }
    }

    public GameObject entryPrefab;
    public Transform contentPanel;

    public List<LeaderboardEntryData> leaderboardData = new List<LeaderboardEntryData>();

    void Start()
    {
        // Example test data (replace with your real data source later)
        leaderboardData.Add(new LeaderboardEntryData("Farrel", 500));
        leaderboardData.Add(new LeaderboardEntryData("Alpha", 450));
        leaderboardData.Add(new LeaderboardEntryData("Beta", 300));

        RefreshLeaderboard();
    }

    public void RefreshLeaderboard()
    {
        // Clear existing entries
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Sort by score descending
        leaderboardData.Sort((a, b) => b.score.CompareTo(a.score));

        // Create entry UI for each
        for (int i = 0; i < leaderboardData.Count; i++)
        {
            var entry = Instantiate(entryPrefab, contentPanel);
            var texts = entry.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = (i + 1).ToString(); // Rank
            texts[1].text = leaderboardData[i].username;
            texts[2].text = leaderboardData[i].score.ToString();
        }
    }
    public void AddOrUpdateScore(string username, int newScore)
    {
        bool found = false;
    
        for (int i = 0; i < leaderboardData.Count; i++)
        {
            if (leaderboardData[i].username == username)
            {
                // Replace only if the new score is higher
                if (newScore > leaderboardData[i].score)
                {
                    leaderboardData[i].score = newScore;
                    Debug.Log($"Updated {username}'s score to {newScore}");
                }
                found = true;
                break;
            }
        }
    
        if (!found)
        {
            leaderboardData.Add(new LeaderboardEntryData(username, newScore));
            Debug.Log($"Added new user {username} with score {newScore}");
        }
    
        RefreshLeaderboard();
    }


}

