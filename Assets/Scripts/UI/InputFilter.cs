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
        // �Էµ� ���ڰ� �������� Ȯ��
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }

        // ���ڰ� �ƴϸ� �Է��� ����
        return '\0';
    }
}