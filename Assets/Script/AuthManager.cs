using UnityEngine;
using TMPro;


public class AuthManager : MonoBehaviour

{
    public UserData currentUser;
    [Header("Panel References")]
    public GameObject loginPanel;
    public GameObject menuPanel;
    [Space(50)]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI messageText;
    [Header("Button")]
    public TextMeshProUGUI loginText;
    public TextMeshProUGUI BelowText;
    [Space(50)]
    [Header("Menu References")]
    public TextMeshProUGUI menuUsername;
    public TextMeshProUGUI HighscoreText;
    [Space(50)]
    [Header("Menu References")]
    public TextMeshProUGUI StartUsername;



    public bool isRegistering = false;
    private LeaderboardManager leaderboardManager;

    private void Start()
    {
        leaderboardManager = GetComponent<LeaderboardManager>();
        messageText.text = "";
        loginText.text = "Login";
        BelowText.text = "Dont have an account? Register"; 
        isRegistering = false;
        if (!PlayerPrefs.HasKey("current_session"))
        {
            StartUsername.text = "";
        }
    }
    public void BukaLogin()
    {
        if (PlayerPrefs.HasKey("current_session"))
        {
            string username = PlayerPrefs.GetString("current_session");
            currentUser = LoadUserData(username);
            StartUsername.text = $"Welcome back, {currentUser.username}!";
            menuUsername.text = $"Welcome, {currentUser.username}";
            HighscoreText.text = "Highscore: " + currentUser.Score.ToString();
            menuPanel.SetActive(true);
            return;
        }
        
        loginPanel.SetActive(true);
    }

    private void SaveUserData(UserData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(data.username, json);
        PlayerPrefs.Save();
    }
    private UserData LoadUserData(string username)
    {
        if (!PlayerPrefs.HasKey(username)) return null;

        string json = PlayerPrefs.GetString(username);
        return JsonUtility.FromJson<UserData>(json);
    }
    public void Save()
    {
        SaveUserData(currentUser);
    }
    public void Saveleaderboard()
    {
        leaderboardManager.AddOrUpdateScore(currentUser.username, currentUser.Score);
    }


    public void ChangeButton()
    {
        if(isRegistering)
        {
            loginText.text = "Login";
            BelowText.text = "Dont have an account? Register"; 
            isRegistering = false;
        }
        else
        {
            loginText.text = "Register";
            BelowText.text = "Already have an account? Login";
            isRegistering = true;
        }
    }
    void ChangePanel()
    {
        loginPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void OnSubmit()
    {
        if (isRegistering)
        {
            Register();
        }
        else
        {
            Login();
        }
    }

    public void Register()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (PlayerPrefs.HasKey(username))
        {
            messageText.text = "Username already exists.";
            return;
        }

        UserData newUser = new UserData(username, password);
        SaveUserData(newUser);
        ChangeButton();
        messageText.text = "Registered successfully!";
    }
public void updatescroe()
{
    if (currentUser != null)
    {
        HighscoreText.text = "Highscore: " + currentUser.Score.ToString();
    }
}
public void CheckHighscore(GameObjectScript gameObjectScript, int score)
{
    if (gameObjectScript.objectName == "Soekarno")
    {
        if (score > currentUser.HighScoresoekarno)
        {
            currentUser.HighScoresoekarno = score;
            Save();
        }
    }
    else if (gameObjectScript.objectName == "Hatta")
    {
        if (score > currentUser.HighScorehatta)
        {
            currentUser.HighScorehatta = score;
            Save();
        }
    }
    else if (gameObjectScript.objectName == "Diorama Proklamasi")
    {
        if (score > currentUser.HighScoreDiorama_Proklamasi)
        {
            currentUser.HighScoreDiorama_Proklamasi = score;
            Save();
        }
    }
    else if (gameObjectScript.objectName == "Dokumen Proklamasi")
    {
        if (score > currentUser.HighScoreDokumen_Proklamasi)
        {
            currentUser.HighScoreDokumen_Proklamasi = score;
            Save();
        }
    }
    else if (gameObjectScript.objectName == "Rumah Soekarno")
    {
        if (score > currentUser.HighScoreRumah_Soekarno)
        {
            currentUser.HighScoreRumah_Soekarno = score;
            Save();
        }
    }

}
public int Returnhighscore(GameObjectScript gameObjectScript)
{
    if (gameObjectScript.objectName == "Soekarno")
    {
        return currentUser.HighScoresoekarno;
    }
    else if (gameObjectScript.objectName == "Hatta")
    {
        return currentUser.HighScorehatta;
    }
    else if (gameObjectScript.objectName == "Diorama Proklamasi")
    {
        return currentUser.HighScoreDiorama_Proklamasi;
    }
    else if (gameObjectScript.objectName == "Dokumen Proklamasi")
    {
        return currentUser.HighScoreDokumen_Proklamasi;
    }
    else if (gameObjectScript.objectName == "Rumah Soekarno")
    {
        return currentUser.HighScoreRumah_Soekarno;
    }
    return 0;
}
public void Checkstar(GameObjectScript gameObjectScript)
{
    if (gameObjectScript.objectName == "Soekarno")
    {
        currentUser.Quiz_Star_1 = true;
        Save();
    }
    else if (gameObjectScript.objectName == "Hatta")
    {
        currentUser.Quiz_Star_2 = true;
        Save();
    }
    else if (gameObjectScript.objectName == "Diorama Proklamasi")
    {
        currentUser.Quiz_Star_3 = true;
        Save();
    }
    else if (gameObjectScript.objectName == "Dokumen Proklamasi")
    {
        currentUser.Quiz_Star_4 = true;
        Save();
    }
    else if (gameObjectScript.objectName == "Rumah Soekarno")
    {
        currentUser.Quiz_Star_5 = true;
        Save();
    }
}


public void Login()
{
    string username = usernameInput.text;
    string password = passwordInput.text;

    UserData loadedUser = LoadUserData(username);
    if (loadedUser == null)
    {
        messageText.text = "User not found.";
        return;
    }

    if (loadedUser.hashedPassword == PasswordHasher.Hash(password))
    {
        messageText.text = "Login successful!";
        currentUser = loadedUser;
        PlayerPrefs.SetString("current_session", currentUser.username);
        menuUsername.text = "Welcome, " + currentUser.username;
        HighscoreText.text = "Highscore: " + currentUser.Score.ToString();
        ChangePanel();
    }
    else
    {
        messageText.text = "Incorrect password.";
    }
}
public void DeleteUser()
{
    if (PlayerPrefs.HasKey(currentUser.username))
    {
        PlayerPrefs.DeleteKey(currentUser.username);
        PlayerPrefs.Save();
        Debug.Log($"User '{currentUser.username}' deleted.");
    }
    else
    {
        Debug.Log("User not found.");
    }
}

public void Logout()
{
    currentUser = null;
    messageText.text = "Logged out.";
    PlayerPrefs.DeleteKey("current_session");
    menuPanel.SetActive(false);
    loginPanel.SetActive(true);
}


}
