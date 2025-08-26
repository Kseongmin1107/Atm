using UnityEngine;
using TMPro;

public class PopupSignUp : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField nameInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField passwordConfirmInputField;

    public GameObject signUpUI;
    public GameObject loginUI;

    public TextMeshProUGUI errorText;

    public void OnSignUpButtonClicked()
    {
        errorText.text = "";

        string inputID = idInputField.text;
        string inputName = nameInputField.text;
        string inputPassword = passwordInputField.text;
        string inputPasswordConfirm = passwordConfirmInputField.text;

        if (string.IsNullOrEmpty(inputID) || string.IsNullOrEmpty(inputName) ||
            string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(inputPasswordConfirm))
        {
            errorText.text = "��ĭ�� ��� ä���ּ���.";
            return;
        }

        if (inputPassword != inputPasswordConfirm)
        {
            errorText.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            return;
        }

        if (PlayerPrefs.HasKey("ID_" + inputID))
        {
            errorText.text = "�̹� �����ϴ� ID�Դϴ�.";
            return;
        }

        GameManager.Instance.userData.id = inputID;
        GameManager.Instance.userData.userName = inputName;
        GameManager.Instance.userData.password = inputPassword;

        GameManager.Instance.SaveUserData();

        Debug.Log("ȸ������ ����!");
        signUpUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void OnCancelButtonClicked()
    {
        errorText.text = "";
        signUpUI.SetActive(false);
        loginUI.SetActive(true);
    }
}