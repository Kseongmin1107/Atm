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

        UserData existingData = GameManager.Instance.GetUserData(inputID);
        if (existingData != null)
        {
            errorText.text = "�̹� �����ϴ� ID�Դϴ�.";
            return;
        }

        UserData newUserData = new UserData
        {
            id = inputID,
            userName = inputName,
            password = inputPassword,
            cash = 0,
            balance = 1000000
        };

        GameManager.Instance.SaveUserData(newUserData.id, newUserData);
        ResetInputFields();

        Debug.Log("ȸ������ ����!");
        signUpUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void OnCancelButtonClicked()
    {
        ResetInputFields();

        errorText.text = "";
        signUpUI.SetActive(false);
        loginUI.SetActive(true);
    }

    private void ResetInputFields()
    {
        if (idInputField != null) idInputField.text = "";
        if (nameInputField != null) nameInputField.text = "";
        if (passwordInputField != null) passwordInputField.text = "";
        if (passwordConfirmInputField != null) passwordConfirmInputField.text = "";
    }
}