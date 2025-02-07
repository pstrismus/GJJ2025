using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(50, 500)]
    [SerializeField] float sens;

    [SerializeField] Transform body;

    float xRot = 0f;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        xRot = Mathf.Clamp(xRot, -7.3f, 28.678f);
        body.Rotate(Vector3.up * rotX);
    }

}
