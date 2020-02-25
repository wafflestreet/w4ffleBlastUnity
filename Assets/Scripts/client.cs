using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class client : MonoBehaviour
{
    //Const
    private const int MAX_CONNECTIONS = 100;
    private string SERVER_IP = "127.0.0.1";
    private const int SERVER_PORT = 8999;
    private const int SERVER_WEB_PORT = 8998;
    private const int BUFFER_SIZE = 1024;

    //Channels
    private int reliableChannelId;    //Needs to go through
    private int unreliableChannelId;  //Updating movement of other Players

    // Host 
    private int hostId;
    private int connectionId;

    //Logic
    private byte[] buffer = new byte[BUFFER_SIZE];
    private bool isConnected;
    private byte error;

    private void Start()
    {
        GlobalConfig config = new GlobalConfig();

        NetworkTransport.Init(config);

        //Host Topology
        ConnectionConfig cc = new ConnectionConfig();
        reliableChannelId = cc.AddChannel(QosType.Reliable);
        unreliableChannelId = cc.AddChannel(QosType.Unreliable);
        HostTopology topo = new HostTopology(cc, MAX_CONNECTIONS);

        // Connecting to hosts
        hostId = NetworkTransport.AddHost(topo, 0);

#if UNITY_WEBGL
        // WebGL client
        connectionId = NetworkTransport.Connect(hostId, SERVER_IP, SERVER_PORT, 0, out error);
#else
        
        //Standalone Client 

        connectionId = NetworkTransport.Connect(hostId, SERVER_IP, SERVER_PORT, 0, out error);
#endif

    }

}
