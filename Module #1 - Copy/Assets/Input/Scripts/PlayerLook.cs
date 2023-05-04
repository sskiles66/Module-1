using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public Transform bulletSpawn;

    public float xSensitivity = 30f;
    private float ySenstivity = 30f;
    // Start is called before the first frame update

    
    public void ProcessLook(Vector2 input)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        float mouseX = input.x;
        float mouseY = input.y;
        //Calculates camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySenstivity;

        //Range of looking up and down
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //Apply to camera's transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //bulletSpawn.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        //Rotate player to look left and right

        //Change gamepad sensitivity
        float lookSensitivity = 120f; //Change this value to adjust gamepad sensitivity
        
       
        if (UnityEngine.InputSystem.Gamepad.current != null)
        {
            transform.Rotate(Vector3.up * (input.x * Time.deltaTime) * lookSensitivity);
            xRotation -= (mouseY * Time.deltaTime) * lookSensitivity;
            //Debug.Log("Gamepad");
        }
        else
        {
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
            //Debug.Log("Mouse");
        }
        
    }
}
