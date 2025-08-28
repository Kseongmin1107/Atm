using TMPro;
using UnityEngine;

public class PopUpBank : MonoBehaviour
{
    public GameObject mainBankUI;
    public GameObject depositUI;
    public GameObject withdrawUI;
    public GameObject sendMoneyUI;

    public GameObject buttonsParent;

    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;
    public TMP_InputField targetIDInputField;
    public TMP_InputField amountInputField;

    public GameObject popupErrorUI;
    public TextMeshProUGUI errorText;

    private void Start()
    {
        mainBankUI.SetActive(true);
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        sendMoneyUI.SetActive(false);
    }

    public void OpenDepositUI()
    {
        buttonsParent.SetActive(false);
        depositUI.SetActive(true);
    }

    public void OpenWithdrawUI()
    {
        buttonsParent.SetActive(false);
        withdrawUI.SetActive(true);
    }

    public void OpenSendMoneyUI()
    {
        buttonsParent.SetActive(false);
        sendMoneyUI.SetActive(true);
    }

    public void DepositByInput()
    {
        if (string.IsNullOrEmpty(depositInputField.text))
        {
            ShowPopupError("�Է¶��� ����ֽ��ϴ�.");
            return;
        }

        if (!int.TryParse(depositInputField.text, out int amount) || amount <= 0)
        {
            ShowPopupError("���ڸ� �Է����ּ���.");
            return;
        }

        BankSystem bankSystem = FindObjectOfType<BankSystem>();
        if (bankSystem != null)
        {
            bankSystem.Deposit(amount);
        }

        depositInputField.text = "";
        GoBackToMain();
    }

    public void WithdrawByInput()
    {
        if (string.IsNullOrEmpty(withdrawInputField.text))
        {
            ShowPopupError("�Է¶��� ����ֽ��ϴ�.");
            return;
        }

        if (!int.TryParse(withdrawInputField.text, out int amount) || amount <= 0)
        {
            ShowPopupError("���ڸ� �Է����ּ���.");
            return;
        }

        BankSystem bankSystem = FindObjectOfType<BankSystem>();
        if (bankSystem != null)
        {
            bankSystem.Withdraw(amount);
        }

        withdrawInputField.text = "";
        GoBackToMain();
    }

    public void OnSendMoneyButtonClicked()
    {
        string targetID = targetIDInputField.text;
        int amount = 0;

        if (string.IsNullOrEmpty(targetID) || string.IsNullOrEmpty(amountInputField.text))
        {
            ShowPopupError("�۱� ��� ID�� �ݾ��� ��� �Է����ּ���.");
            return;
        }

        if (!int.TryParse(amountInputField.text, out amount) || amount <= 0)
        {
            ShowPopupError("��ȿ���� ���� �ݾ��Դϴ�.");
            return;
        }

        BankSystem bankSystem = FindObjectOfType<BankSystem>();
        if (bankSystem != null)
        {
            bankSystem.OnSendMoney(targetID, amount);
        }

        targetIDInputField.text = "";
        amountInputField.text = "";
    }

    public void ShowPopupError(string message)
    {
        if (popupErrorUI != null)
        {
            errorText.text = message;
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

    public void GoBackToMain()
    {
        buttonsParent.SetActive(true);

        if (depositUI.activeSelf)
        {
            depositUI.SetActive(false);
        }
        else if (withdrawUI.activeSelf)
        {
            withdrawUI.SetActive(false);
        }
        else if (sendMoneyUI.activeSelf)
        {
            sendMoneyUI.SetActive(false);
        }
    }
}