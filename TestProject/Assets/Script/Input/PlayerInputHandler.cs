using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{


    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputZ { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool RunInput { get; private set; }



    private float jumpInputStartTime;



    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        // Debug.Log(RawMovementInput);
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputZ = Mathf.RoundToInt(RawMovementInput.y);

    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }
    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RunInput = true;

        }

        if (context.canceled)
        {
            RunInput = false;
        }
    }

}
