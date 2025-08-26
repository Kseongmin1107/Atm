using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loginUIPrefab;
    public GameObject mainUIPrefab;
    
    private string userDataPath;
    public UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        loginUIPrefab.SetActive(true);
    }
    public void SaveUserData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, userData.id + "_userData.json");
        string jsonData = JsonUtility.ToJson(userData);
        File.WriteAllText(filePath, jsonData);
    }

    public void LoadUserData(string targetID)
    {
        string filePath = Path.Combine(Application.persistentDataPath, targetID + "_userData.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            userData = JsonUtility.FromJson<UserData>(jsonData);
        }
        else
        {
            userData = new UserData();
            userData.id = targetID;
        }
    }
    public UserData GetUserData(string targetID)
    {
        string filePath = Path.Combine(Application.persistentDataPath, targetID + "_userData.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<UserData>(jsonData);
        }

        return null;
    }

    public void SaveUserData(string targetID, UserData data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, targetID + "_userData.json");
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jsonData);
    }

}