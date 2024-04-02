using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float cameraX;
    float lookSpeed;
    public Transform cameraTransform;
    void Start()
    {
        lookSpeed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        transform.Rotate(0,mouseX,0);

        mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        //cameraTransform.Rotate(mouseY,0,0);
        cameraX -= mouseY;
        cameraX = Mathf.Clamp(cameraX, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(cameraX, 0, 0);

    }
}
