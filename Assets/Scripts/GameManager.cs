using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loginUIPrefab;
    public GameObject mainUIPrefab;

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
        LoadUserData();
    }
    public void SaveUserData()
    {
        string jsonData = JsonUtility.ToJson(userData);

        string filePath = Path.Combine(Application.persistentDataPath, "userData.json");

        File.WriteAllText(filePath, jsonData);
    }

    public void LoadUserData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "userData.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            userData = JsonUtility.FromJson<UserData>(jsonData);
        }
        else
        {
            userData = new UserData();
        }
    }
}