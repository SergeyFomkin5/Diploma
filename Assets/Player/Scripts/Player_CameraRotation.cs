using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CameraRotation : MonoBehaviour
{
    public float SensX = 500f;
    public float SensY = 500f;

    public Transform CameraAxis;

    float RotationY;
    float RotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        RotationY += MouseX;
        RotationX -= MouseY;
        RotationX = Mathf.Clamp(RotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(RotationX, RotationY, 0);
        CameraAxis.rotation = Quaternion.Euler(0, RotationY, 0);
    }
}
