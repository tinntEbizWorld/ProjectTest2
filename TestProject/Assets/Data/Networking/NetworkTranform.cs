using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Data.Ultitity;
using System;

[RequireComponent(typeof(NetworkIdentity))]
public class NetworkTranform : MonoBehaviour
{
    [SerializeField]
    [GreyOut]
    private Vector3 oldPosition;

    private NetworkIdentity networkIdentity;
    private PLAYER2 player;

    private float stillCounter = 0;
    public void Start()
	{
        networkIdentity = GetComponent<NetworkIdentity>();
        oldPosition = transform.position;
        player = new PLAYER2();
        player.position = new Position();
        player.position.x = 0;
        player.position.y = 0;

		if (!networkIdentity.IsControlling())
		{
            enabled = false;
		}

	}

    // Update is called once per frame
    public void Update()
    {
		if (networkIdentity.IsControlling())
		{
            if(oldPosition != transform.position)
			{
                oldPosition = transform.position;
                stillCounter = 0;
                sendData();
			}
            else
			{
                stillCounter += Time.deltaTime;
                
                if(stillCounter >= 1)
				{
                    stillCounter = 0;
                    sendData();
				}
			}
		} 
    }

	private void sendData()
	{
        //Update player infomation
        player.position.x = Mathf.Round(transform.position.x * 100.0f) / 100.0f;
        player.position.y = Mathf.Round(transform.position.y * 100.0f) / 100.0f;

        networkIdentity.GetSocket().Emit("updatePosition",new JSONObject(JsonUtility.ToJson(player)));
	}
}
