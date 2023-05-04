using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerShoot shoot;

    
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        shoot = GetComponent<PlayerShoot>();

        
        //When jump method is performed, call back context to jump method. Performed can be replaced with a few other commands likes cancelled
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Shoot.performed += ctx => shoot.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tell the playermotor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        // Tell the playermotor to move using the value from our movement action
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

        
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
