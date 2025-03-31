using UnityEngine;
using SocketIOClient;

public class SocketListener : MonoBehaviour
{
    private void Start()
    {
        // Kiểm tra nếu socket đã khởi tạo
        if (SocketInstance.Instance != null && SocketInstance.Instance.socket.Connected)
        {
            // Đăng ký lắng nghe sự kiện từ server
            SocketInstance.Instance.OnEvent("pong", OnServerMessage);
        }
        else
        {
            Debug.LogWarning("⚠️ Socket.IO is not connected!");
        }
    }

    // Xử lý khi nhận dữ liệu từ server
    private void OnServerMessage(SocketIOResponse response)
    {
        string message = response.GetValue<string>(); // Lấy dữ liệu từ server
        Debug.Log($"📩 Received from server: {message}");
    }
}
