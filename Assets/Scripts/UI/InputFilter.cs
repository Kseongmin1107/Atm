using UnityEngine;
using TMPro;

public class InputFilter : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onValidateInput = ValidateInputChar;
    }

    private char ValidateInputChar(string text, int charIndex, char addedChar)
    {
        // 입력된 문자가 숫자인지 확인
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }

        // 숫자가 아니면 입력을 막기
        return '\0';
    }
}