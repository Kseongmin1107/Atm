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
            errorText.text = "빈칸을 모두 채워주세요.";
            return;
        }

        if (inputPassword != inputPasswordConfirm)
        {
            errorText.text = "비밀번호가 일치하지 않습니다.";
            return;
        }

        if (PlayerPrefs.HasKey("ID_" + inputID))
        {
            errorText.text = "이미 존재하는 ID입니다.";
            return;
        }

        GameManager.Instance.userData.id = inputID;
        GameManager.Instance.userData.userName = inputName;
        GameManager.Instance.userData.password = inputPassword;

        GameManager.Instance.SaveUserData();

        Debug.Log("회원가입 성공!");
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