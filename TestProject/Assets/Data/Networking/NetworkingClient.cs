using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Assets.Data.Ultitity;
using System;

public class NetworkingClient : SocketIOComponent
{
    [Header("Network Client")]
    [SerializeField]
    private Transform networkContainer;
    [SerializeField]
    private GameObject playerFrefab;

    public static string ClientID { get; private set; }

    private Dictionary<string, NetworkIdentity> serverObjects;


    public override void Start()
    {
        base.Start();
        initialize();
        setupEvents();
    }

    public override void Update()
    {
        base.Update();
    }
    private void initialize()
	{
        serverObjects = new Dictionary<string, NetworkIdentity>();
	}


    private void setupEvents()
    {
        On("open", (E) =>
        {
            Debug.Log("Connection made to the server");
        });

        On("register", (E) =>
        {
            ClientID = E.data["id"].ToString().RemoveQuotes();

            Debug.LogFormat("Our Client's ID ({0})", ClientID);
        });

        On("spawn", (E) =>
        {
            //Handling all spawning all players
            //Passed Data
            string id = E.data["id"].ToString().RemoveQuotes();

            GameObject go = Instantiate(playerFrefab, networkContainer);
            go.name = string.Format("Player ({0})", id);
            NetworkIdentity ni = go.GetComponent<NetworkIdentity>();
            ni.SetControllerID(id);
            ni.SetSocketPreference(this);
   
            serverObjects.Add(id, ni);
        });


        On("disconnected", (E) => {
            disconnected(E);
        });

        On("updatePosition", (E) =>
        {
            string id = E.data["id"].ToString().RemoveQuotes();
            float x = E.data["position"]["x"].f;
            float y = E.data["position"]["y"].f;

            NetworkIdentity ni = serverObjects[id];
            ni.transform.position = new Vector3(x, y, 0);


        });
    }

    private void disconnected(SocketIOEvent E)
	{
        string id = E.data["id"].ToString().RemoveQuotes();

        GameObject go = serverObjects[id].gameObject;
        Destroy(go);
        serverObjects.Remove(id);
    }
    

 //   enum Funtions
	//{
 //       open,

	//}

    
}
[Serializable]
public class PLAYER2
{
    public string id;
    public Position position;
}
[Serializable]
public class Position
{
    public float x;
    public float y;
}
