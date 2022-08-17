using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraMover : MonoBehaviour
{
    [SerializeField]
    private float mouseSpeed = 100;
    public Vector2 tempMouse;
    private float xRotation;
    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        FPSCameraMove();
    }

    private void FPSCameraMove()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        tempMouse = new Vector2(mouseHorizontal, mouseVertical);

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -70, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerTransform.Rotate(Vector3.up * mouseHorizontal);
    }

    public void CameraReset()
    {
        xRotation = 0;
    }
}
