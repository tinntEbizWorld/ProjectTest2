using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public CharacterController controller;

	public float Velocity;
	public float Speed;

	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;

	public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

	public Camera cam;

	protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
		cam = Camera.main;
		blockRotationPlayer = false;

	}
 //   private void Update()
 //   {
	//	int x = Player.instance.playerInput.NormInputX;
	//	int z = Player.instance.playerInput.NormInputY;
	//	PlayerMoveAndRotation(x, z);

	//}
 //   private void FixedUpdate()
 //   {
	//	RotateToCamera(cam.transform);
	//}
    public void PlayerMoveAndRotation(int x, int z)
	{
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize();
		right.Normalize();

		desiredMoveDirection = forward * z + right * x;

		if (blockRotationPlayer == false)
		{
			//Player.instance.transform.rotation = Quaternion.Slerp(Player.instance.transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
			controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
		}
	}
	public void setVelocity(float value)
    {
		Velocity = value;
    }
	public void RotateToCamera(Camera cam)
	{
		desiredMoveDirection = cam.transform.forward;

		cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
	}


}
