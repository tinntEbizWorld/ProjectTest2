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


    [Header("Minimap")]
    //public GameObject[] players;
    public static GameObject Player;
    [SerializeField]
    private Camera cameramini;

    public GameObject makerPrefab;
    //public GameObject playerObject;
    public RectTransform makerParentRectTransform;
    private List<(ObjectivePosition objectivePosition, RectTransform makerRectTransform)> currentObjectives;

    //public Camera minimapCamera;
    public static string ClientID { get; private set; }

    private Dictionary<string, NetworkIdentity> serverObjects;


    public override void Start()
    {
        base.Start();
        currentObjectives = new List<(ObjectivePosition objectivePosition, RectTransform makerRectTransform)>();

        initialize();
        setupEvents();
        
    }

    public override void Update()
    {
        base.Update();
        foreach ((ObjectivePosition objectivePosition, RectTransform makerRectTransform) maker in currentObjectives)
        {
            Vector3 offset = Vector3.ClampMagnitude(maker.objectivePosition.transform.position = Player.transform.position, cameramini.orthographicSize);
            offset = offset / cameramini.orthographicSize * (makerParentRectTransform.rect.width / 2f);
            Debug.Log(offset);
            maker.makerRectTransform.anchoredPosition = new Vector2(offset.x, offset.z);
        }
    }
    public override void LateUpdate()
    {
        if (Player)
        {
            Vector3 newPosition = Player.transform.position;
            if (cameramini)
            {
                 newPosition.z = cameramini.gameObject.transform.position.z;

                cameramini.gameObject.transform.position = newPosition;
                cameramini.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Player.transform.eulerAngles.z-180f);

            }

        }

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
            if(ni.IsControlling())
                Player = go;
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
        On("updateRotation", (E) =>
        {
            string id = E.data["id"].ToString().RemoveQuotes();
            float tankRotation = E.data["tankRotation"].f;
            float barrelRotation = E.data["barrelRotation"].f;

            NetworkIdentity ni = serverObjects[id];
            ni.transform.localEulerAngles = new Vector3(0, 0, tankRotation);
            ni.GetComponent<PlayerManager>().SetRotation(barrelRotation);
        });

        //players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in players)
        //{
        //    if (!player.GetComponent<NetworkIdentity>().IsControlling())
        //    {
        //        Player = player;
        //    }
        //}
    }

    private void disconnected(SocketIOEvent E)
	{
        string id = E.data["id"].ToString().RemoveQuotes();

        GameObject go = serverObjects[id].gameObject;
        Destroy(go);
        serverObjects.Remove(id);
    }
    public void AddObjectiveMaker(ObjectivePosition sender)
    {
        RectTransform rectTransform = Instantiate(makerPrefab, makerParentRectTransform).GetComponent<RectTransform>();
        currentObjectives.Add((sender, rectTransform));
    }

    public void RemoveObjectiveMaker(ObjectivePosition sender)
    {
        if (!currentObjectives.Exists(objective => objective.objectivePosition == sender))
            return;
        (ObjectivePosition pos, RectTransform rectTrans) foundObj = currentObjectives.Find(objective => objective.objectivePosition == sender);
        Destroy(foundObj.rectTrans.gameObject);
        currentObjectives.Remove(foundObj);
    }

    //   enum Funtions
    //{
    //       open,

    //}


}
[Serializable]
public class Player
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
public class PlayerRotation
{
    public float tankRotation;
    public float barrelRotation;
}
