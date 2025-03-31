using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPingToServer : MonoBehaviour
{
    public async void SendMessageToServer()
    {
        if (SocketEmitter.Instance != null)
        {
            await SocketEmitter.Instance.EmitMessage("ping", "Hello from Unity!");
            Debug.Log("📩 Sent to server: ping");
        }
    }
    public void asdf()
    {
        Debug.Log("asdfsadf");
    }


}
