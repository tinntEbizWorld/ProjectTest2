using Assets.Data.Ultitity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NetworkIdentity))]
public class NetworkingRotation : MonoBehaviour
{
    [Header("Referenced Values")]
    [SerializeField]
    [GreyOut]
    private float oldTankRotation;

    [SerializeField]
    [GreyOut]
    private float oldBarrelRotation;

    [Header("Class References")]
    [SerializeField]
    private PlayerManager playerManager;

    private NetworkIdentity networkIdentity;
    private PlayerRotation playerRotation;
    private float stillCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        networkIdentity = GetComponent<NetworkIdentity>();

        playerRotation = new PlayerRotation();
        playerRotation.tankRotation = 0;
        playerRotation.barrelRotation = 0;

		if (!networkIdentity.IsControlling())
		{
            enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (networkIdentity.IsControlling())
		{
            if (oldTankRotation != transform.localEulerAngles.z || oldBarrelRotation != playerManager.GetLastRotation())
			{
                oldTankRotation = transform.localEulerAngles.z;
                oldBarrelRotation = playerManager.GetLastRotation();
                stillCounter = 0;
                sendData();
			}else
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
        playerRotation.tankRotation = transform.localEulerAngles.z.TwoDecimals();
        playerRotation.barrelRotation = playerManager.GetLastRotation().TwoDecimals();

        networkIdentity.GetSocket().Emit("updateRotation", new JSONObject(JsonUtility.ToJson(playerRotation)));
	}
}
