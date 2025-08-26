using UnityEngine;
using TMPro;

public class BankSystem : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;

    public GameObject popupErrorUI;

    private void Start()
    {
        gameObject.SetActive(false);
        Refresh();
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
            ShowPopupError();
        }
    }
    public void DepositByInput()
    {
        if (string.IsNullOrEmpty(depositInputField.text))
        {
            return;
        }

        int amount = int.Parse(depositInputField.text);

        Deposit(amount);

        depositInputField.text = "";
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
            ShowPopupError();
        }
    }
    public void WithdrawByInput()
    {
        if (string.IsNullOrEmpty(withdrawInputField.text))
        {
            return;
        }

        int amount = int.Parse(withdrawInputField.text);
        Withdraw(amount);

        withdrawInputField.text = "";
    }

    public void ShowPopupError()
    {
        if (popupErrorUI != null)
        {
            popupErrorUI.SetActive(true);
        }
    }

    public void ClosePopupError()
    {
        if (popupErrorUI != null)
        {
            popupErrorUI.SetActive(false);
        }
    }
}