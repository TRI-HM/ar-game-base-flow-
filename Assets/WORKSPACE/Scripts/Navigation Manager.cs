using UnityEngine;
using TMPro;
using System.IO;

public class NavigationManager : MonoBehaviour
{
    public TMP_Text welcomeText; // Thành phần UI để hiển thị thông tin

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerPhone;
        public string playerMail;
    }

    void Start()
    {
        LoadAndDisplayPlayerData();
    }

    void LoadAndDisplayPlayerData()
    {
        string filePath = Application.persistentDataPath + "/playerData.json";

        // Kiểm tra xem file JSON có tồn tại không
        if (File.Exists(filePath))
        {
            // Đọc nội dung file JSON
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            // Hiển thị dữ liệu lên TMP_Text
            welcomeText.text = "Welcome, " + playerData.playerName + playerData.playerPhone + playerData.playerMail;

            Debug.Log("Đã tải và hiển thị dữ liệu: " + json);
        }
        else
        {
            // Nếu không tìm thấy file, hiển thị thông báo mặc định
            welcomeText.text = "Welcome, Guest!\nData not found.";
            Debug.LogWarning("Không tìm thấy file playerData.json tại: " + filePath);
        }
    }
}