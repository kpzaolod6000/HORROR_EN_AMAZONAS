using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerPlayer : MonoBehaviour
{
    //Variable Singleton
    private static InputManagerPlayer _instance;

    public static InputManagerPlayer Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerControls playerControls;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        playerControls = new PlayerControls();

        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public bool GetIsPlayerMovement()
    {
        return playerControls.Player.Movement.IsPressed();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerEnableFlashLight(){
        return playerControls.Player.FlashLight.triggered;
    }
    public bool PlayerTake()
    {
        return playerControls.Player.Cojer.IsPressed();
    }

    public bool PlayerLeave()
    {
        return playerControls.Player.Escape.triggered;
    }
}
