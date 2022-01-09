using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkIdentity : MonoBehaviour
{
    [Header("Helpful Values")]
    [SerializeField]
    [GreyOut]
    private string id;
    [SerializeField]
    [GreyOut]
    private bool isControlling;

    private SocketIOComponent socket;

	private void Awake()
	{
        isControlling = false;
	}

    public void SetControllerID(string ID)
	{
        id = ID;
        isControlling = (NetworkingClient.ClientID == ID) ? true : false;
	}

    public void SetSocketPreference(SocketIOComponent Socket)
	{
        socket = Socket;
	}
    public string GetID()
	{
        return id;
	}
    public bool IsControlling()
	{
        return isControlling;
	}

    public SocketIOComponent GetSocket()
	{
        return socket;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
