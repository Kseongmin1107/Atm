using UnityEngine;
using TMPro;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField passwordInputField;

    public GameObject loginUI;
    public GameObject mainUI;
    public GameObject signUpUI;

    public void OnLoginButtonClicked()
    {
        string inputID = idInputField.text;
        string inputPassword = passwordInputField.text;

        GameManager.Instance.LoadUserData();

        UserData savedData = GameManager.Instance.userData;

        if (inputID == savedData.id && inputPassword == savedData.password)
        {
            Debug.Log("로그인 성공!");
            loginUI.SetActive(false);
            mainUI.SetActive(true);
        }
        else
        {
            Debug.Log("로그인 실패: 아이디 또는 비밀번호가 올바르지 않습니다.");
        }
    }

    public void OnSignUpButtonClicked()
    {
        signUpUI.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("회원가입 버튼 클릭됨");
    }
}