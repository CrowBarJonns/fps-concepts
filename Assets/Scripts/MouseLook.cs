using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivity = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float verticalRot = 0f;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }


    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        } else if (axes == RotationAxes.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivity;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivity;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float horizontalRot = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
