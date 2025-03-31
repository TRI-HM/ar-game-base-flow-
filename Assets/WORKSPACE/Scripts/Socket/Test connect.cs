using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Testconnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SocketInstance.Instance.RegisterEmitSocketEvent("ping", "Hello from Unity!");
        SocketInstance.Instance.RegisterOnSocketEvent("pong", (response) =>
        {
            Debug.Log("Received ping event: " + response.GetValue<string>());
        });
    }

}
