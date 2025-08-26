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
                popupBank.ShowPopupError("현금이 부족합니다.");
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
                popupBank.ShowPopupError("잔고가 부족합니다.");
            }
        }
    }

    public void OnSendMoney(string targetID, int amount)
    {
        UserData myData = GameManager.Instance.userData;
        if (myData.balance < amount)
        {
            popupBank.ShowPopupError("잔고가 부족합니다.");
            return;
        }

        if (myData.id == targetID)
        {
            popupBank.ShowPopupError("자신에게는 송금할 수 없습니다.");
            return;
        }

        UserData targetData = GameManager.Instance.GetUserData(targetID);
        if (targetData == null)
        {
            popupBank.ShowPopupError("존재하지 않는 사용자 ID입니다.");
            return;
        }

        myData.balance -= amount;
        targetData.balance += amount;

        GameManager.Instance.SaveUserData();
        GameManager.Instance.SaveUserData(targetData.id, targetData);

        Refresh();

        Debug.Log($"송금 완료! {targetID}에게 {amount}원을 보냈습니다.");

        if (popupBank != null)
        {
            popupBank.GoBackToMain();
        }
    }
}