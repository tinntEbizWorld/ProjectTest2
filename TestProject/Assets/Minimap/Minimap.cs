using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject[] players;
    public GameObject Player;
    //public GameObject PlayerContainer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            if (player.GetComponent<NetworkIdentity>().IsControlling())
            {
                Player = player;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = Player.transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation=Quaternion.Euler(Player.transform.eulerAngles.x, Player.transform.eulerAngles.y, 0f);
    }


}
