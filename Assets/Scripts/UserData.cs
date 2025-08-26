using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName = "�÷��̾�";
    public int cash = 100000;
    public int balance = 50000;

    public string id = "tempID";
    public string password = "tempPassword";
    public string name = "�÷��̾�";
    public UserData()
    {

    }
    public UserData(string name, int initialCash, int initialBalance)
    {
        this.userName = name;
        this.cash = initialCash;
        this.balance = initialBalance;
    }
}