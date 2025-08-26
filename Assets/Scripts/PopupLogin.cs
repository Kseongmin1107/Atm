using UnityEngine;
using TMPro;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField passwordInputField;

    public GameObject loginUI;
    public GameObject mainUI;
    public GameObject signUpUI;

    public GameObject errorPopupUI;
    public TextMeshProUGUI errorText;

    public void OnLoginButtonClicked()
    {
        string inputID = idInputField.text;
        string inputPassword = passwordInputField.text;

        GameManager.Instance.LoadUserData();

        UserData savedData = GameManager.Instance.userData;

        if (string.IsNullOrEmpty(inputID) || string.IsNullOrEmpty(inputPassword))
        {
            ShowErrorPopup("���̵�� ��й�ȣ�� �Է����ּ���.");
            return;
        }

        if (inputID == savedData.id && inputPassword == savedData.password)
        {
            Debug.Log("�α��� ����!");
            loginUI.SetActive(false);
            mainUI.SetActive(true);
        }
        else
        {
            ShowErrorPopup("���̵� �Ǵ� ��й�ȣ�� �ùٸ��� �ʽ��ϴ�.");
        }
    }

    public void OnSignUpButtonClicked()
    {
        signUpUI.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("ȸ������ ��ư Ŭ����");
    }
    private void ShowErrorPopup(string message)
    {
        if (errorPopupUI != null)
        {
            errorText.text = message;
            errorPopupUI.SetActive(true);
        }
    }
    public void CloseErrorPopup()
    {
        if (errorPopupUI != null)
        {
            errorPopupUI.SetActive(false);
        }
    }
}
