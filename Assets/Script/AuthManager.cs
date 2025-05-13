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

    private void Start()
    {
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
public void Logout()
{
    currentUser = null;
    messageText.text = "Logged out.";
    PlayerPrefs.DeleteKey("current_session");
    menuPanel.SetActive(false);
    loginPanel.SetActive(true);
}


}
