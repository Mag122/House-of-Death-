using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform Player;
    public float sensitivity = 75f;
    private float xRotation;
    public FixedJoystick joystick;

    void Update()
    {
        float mouseX = joystick.Horizontal * sensitivity * Time.deltaTime;
        float mouseY = joystick.Vertical * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(Vector3.up * mouseX);
    }
}
