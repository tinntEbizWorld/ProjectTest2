using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
	public Transform cam;

	public float Speed;

	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;

	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;

	public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;


	protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {

		blockRotationPlayer = false;

	}

    public void PlayerMoveAndRotation(int x, int z, float speed)
	{
		Vector3 direction = new Vector3(x, 0f, z).normalized;


		if (blockRotationPlayer == false && direction.magnitude >= 0.1f) 
		{
			float targetAgle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(Player.instance.transform.eulerAngles.y, targetAgle, ref turnSmoothVelocity, turnSmoothTime);
			Player.instance.transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDirection = Quaternion.Euler(0f, targetAgle, 0f) * Vector3.forward;
			Vector3 playerMove = moveDirection.normalized * Time.deltaTime * speed;
			Player.instance.controller.Move(moveDirection.normalized * Time.deltaTime * speed);
			
		}
	}


}
