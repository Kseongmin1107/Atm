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
            Debug.Log("�α��� ����!");
            loginUI.SetActive(false);
            mainUI.SetActive(true);
        }
        else
        {
            Debug.Log("�α��� ����: ���̵� �Ǵ� ��й�ȣ�� �ùٸ��� �ʽ��ϴ�.");
        }
    }

    public void OnSignUpButtonClicked()
    {
        signUpUI.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("ȸ������ ��ư Ŭ����");
    }
}