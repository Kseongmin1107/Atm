using System;
using TMPro;
using UnityEngine;

public class BankSystem : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    private PopUpBank popupBank;

    private void Start()
    {
        Refresh();
        popupBank = FindObjectOfType<PopUpBank>();
    }

    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;
        userNameText.text = userData.userName;
        cashText.text = string.Format("{0:N0}", userData.cash);
        balanceText.text = string.Format("{0:N0}", userData.balance);
    }

    public void Deposit(int amount)
    {
        UserData userData = GameManager.Instance.userData;
        if (userData.cash >= amount)
        {
            userData.cash -= amount;
            userData.balance += amount;
            GameManager.Instance.SaveUserData();
            Refresh();
        }
        else
        {
            if (popupBank != null)
            {
                popupBank.ShowPopupError("������ �����մϴ�.");
            }
        }
    }

    public void Withdraw(int amount)
    {
        UserData userData = GameManager.Instance.userData;
        if (userData.balance >= amount)
        {
            userData.balance -= amount;
            userData.cash += amount;
            GameManager.Instance.SaveUserData();
            Refresh();
        }
        else
        {
            if (popupBank != null)
            {
                popupBank.ShowPopupError("�ܰ� �����մϴ�.");
            }
        }
    }

    public void OnSendMoney(string targetID, int amount)
    {
        UserData myData = GameManager.Instance.userData;
        if (myData.balance < amount)
        {
            popupBank.ShowPopupError("�ܰ� �����մϴ�.");
            return;
        }

        if (myData.id == targetID)
        {
            popupBank.ShowPopupError("�ڽſ��Դ� �۱��� �� �����ϴ�.");
            return;
        }

        UserData targetData = GameManager.Instance.GetUserData(targetID);
        if (targetData == null)
        {
            popupBank.ShowPopupError("�������� �ʴ� ����� ID�Դϴ�.");
            return;
        }

        myData.balance -= amount;
        targetData.balance += amount;

        GameManager.Instance.SaveUserData();
        GameManager.Instance.SaveUserData(targetData.id, targetData);

        Refresh();

        Debug.Log($"�۱� �Ϸ�! {targetID}���� {amount}���� ���½��ϴ�.");

        if (popupBank != null)
        {
            popupBank.GoBackToMain();
        }
    }
}