using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName = "±è¼º¹Î";
    public int cash = 100000;
    public int balance = 50000;

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