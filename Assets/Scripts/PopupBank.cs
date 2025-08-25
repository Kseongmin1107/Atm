using UnityEngine;

public class PopUpBank : MonoBehaviour
{
    public GameObject mainBankUI;
    public GameObject depositUI;
    public GameObject withdrawUI;

    public GameObject buttonsParent;

    private void Start()
    {
        mainBankUI.SetActive(true);
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
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
    }
}