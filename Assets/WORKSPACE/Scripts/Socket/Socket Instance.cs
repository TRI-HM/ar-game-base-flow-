using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient; // Thư viện Socket.IO
using System; // Để sử dụng Action và các delegate khác

public class SocketInstance : MonoBehaviour
{
    public static SocketInstance Instance { get; private set; } // Singleton instance
    public SocketIOClient.SocketIO socket { get; private set; } // Socket.IO client
    public string serverUrl = "http://localhost:3000"; // Đổi thành URL server của bạn

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không bị hủy khi đổi Scene
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializeSocket();
    }

    private async void InitializeSocket()
    {
        socket = new SocketIOClient.SocketIO(serverUrl, new SocketIOOptions
        {
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });

        // Lắng nghe sự kiện kết nối
        socket.OnConnected += (sender, e) =>
        {
            Debug.Log("Socket.IO Connected!");
        };

        // Lắng nghe sự kiện ngắt kết nối
        socket.OnDisconnected += (sender, e) =>
        {
            Debug.Log("Socket.IO Disconnected!");
        };

        await socket.ConnectAsync(); // Kết nối đến server
    }

    // Phương thức đăng ký lắng nghe sự kiện từ server
    public void OnEvent(string eventName, Action<SocketIOResponse> callback)
    {
        if (string.IsNullOrEmpty(eventName))
        {
            if (socket.Connected)
            {
                socket.On(eventName, callback);
            }
            else
            {
                Debug.LogWarning($"Socket is not connected. Cannot listen for event: {eventName}");
            }
            return;
        }

        if (callback == null)
        {
            Debug.Log($"Listening for event: {eventName}");
            return;
        }

        if (socket != null)
        {
            socket.On(eventName, callback);
            Debug.Log($"👂 Listening for event: {eventName}");
        }
    }

    // Hàm ngắt kết nối khi game đóng
    private async void OnApplicationQuit()
    {
        if (socket != null)
        {
            await socket.DisconnectAsync();
        }
    }
}
