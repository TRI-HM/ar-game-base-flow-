using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerPhone;
        public string playerMail;
        public PlayerData(string name, string phone, string mail)
        {
            playerName = name;
            playerPhone = phone;
            playerMail = mail;
        }
    }
    public TMP_InputField playerName;
    public TMP_InputField playerPhone;
    public TMP_InputField playerMail;
    public Button confirmButton;

    void Start()
    {
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }
    void OnConfirmButtonClick()
    {
        if (playerName == null || playerPhone == null || playerMail == null)
        {
            Debug.Log("Please enter complete information.");
            return;
        }
        string name = playerName.text;
        string phone = playerPhone.text;
        string mail = playerMail.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(mail))
        {
            Debug.Log("Please enter complete information.");
            return;
        }

        PlayerData playerData = new PlayerData(name, phone, mail);

        // Convert player data to JSON string
        string json = JsonUtility.ToJson(playerData);
        string filePath = Application.persistentDataPath + "/playerData.json";

        // Emit data to server 
        SocketInstance.Instance.RegisterEmitSocketEvent("userRegister", json);

        File.WriteAllText(filePath, json);
        Debug.Log("Player data saved to: " + filePath);

        confirmButton.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        playerPhone.gameObject.SetActive(false);
        playerMail.gameObject.SetActive(false);

        SceneManager.LoadScene("Navigation");

    }
}
