using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    private float speed = 4;

    [Header("Class Refenrences")]
    [SerializeField]
    private NetworkIdentity networkIdentity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (networkIdentity.IsControlling())
		{
            checkMovement();
		}
    }

	private void checkMovement()
	{
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
	}
}
