using UnityEngine;
using System.Threading.Tasks;
using SocketIOClient;

public class SocketEmitter : MonoBehaviour
{
    public static SocketEmitter Instance { get; private set; }

    public async Task EmitMessage(string eventName, object data)
    {
        if (SocketInstance.Instance != null && SocketInstance.Instance.socket.Connected)
        {
            await SocketInstance.Instance.socket.EmitAsync(eventName, data);
            Debug.Log($"📤 Sent event: {eventName} with data: {data}");
        }
        else
        {
            Debug.LogWarning("⚠️ Socket.IO is not connected!");
        }
    }
}
