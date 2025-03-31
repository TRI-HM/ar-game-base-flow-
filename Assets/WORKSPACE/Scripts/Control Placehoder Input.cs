using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPlacehoderInput : MonoBehaviour
{
    private TMP_InputField inputFieldName;

    void Start()
    {
        // Lấy TMP_InputField từ GameObject hiện tại
        inputFieldName = GetComponent<TMP_InputField>();

        if (inputFieldName == null)
        {
            Debug.LogError("TMP_InputField component not found on this GameObject.");
            return;
        }

        Debug.Log("TMP_InputField component found: " + inputFieldName.name);

        SetupInputField(inputFieldName);
    }

    void SetupInputField(TMP_InputField inputField)
    {
        // Ẩn placeholder khi tap vào
        inputField.onSelect.AddListener((string text) =>
        {
            if (inputField.placeholder != null)
            {
                inputField.placeholder.gameObject.SetActive(false);
            }
        });

        // Hiện lại placeholder khi mất focus và không có dữ liệu
        inputField.onDeselect.AddListener((string text) =>
        {
            if (inputField.placeholder != null && string.IsNullOrEmpty(inputField.text))
            {
                inputField.placeholder.gameObject.SetActive(true);
            }
        });

        // Khi nhập dữ liệu, đảm bảo placeholder không hiện lại
        inputField.onValueChanged.AddListener((string text) =>
        {
            if (inputField.placeholder != null)
            {
                inputField.placeholder.gameObject.SetActive(string.IsNullOrEmpty(text));
            }
        });
    }
}
