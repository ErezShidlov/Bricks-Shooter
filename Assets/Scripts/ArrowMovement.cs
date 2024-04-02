using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    float yAxis;
    public float speed;
    float arrowX;

    void Start()
    {
        speed = 50;
    }

    void Update()
    {
        GreenArrowMovement();

    }
    void GreenArrowMovement()
    {
        yAxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        arrowX -= yAxis;
        arrowX = Mathf.Clamp(arrowX, -35, 20);
        transform.localRotation = Quaternion.Euler(arrowX, 0, 0);
    }
}
