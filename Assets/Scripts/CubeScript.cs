using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Rigidbody rb;
    bool doForce;
    bool doFlip;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        doForce = true;
        doFlip = true;
    }

    // Update is called once per frame
    void Update()
    {
        AddForce();

        if (doFlip)
        {
            transform.Rotate(40 * Time.deltaTime, 0, 0);
        }
        if (transform.rotation.x >= 0.25f)
        {
            doFlip = false;
        }

    }
    void AddForce()
    {
        if (doForce)
        {
            rb.AddForce(new Vector3(0, 200, 750));
            doForce = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "White")
        {
            print("White");
            Destroy(gameObject,1);
            GameManager.isDestroyed = true;
            GameManager.score++;
        }
        if (collision.gameObject.tag == "Green")
        {
            print("Red");
            Destroy(gameObject,1);
            GameManager.isDestroyed = true;
            GameManager.score += 5;

        }
        if (collision.gameObject.tag == "Yellow")
        {
            print("Red");
            Destroy(gameObject, 1);
            GameManager.isDestroyed = true;
            GameManager.score += 10;

        }
        if (collision.gameObject.tag == "Red")
        {
            print("Red");
            Destroy(gameObject, 1);
            GameManager.isDestroyed = true;
            GameManager.score += 50;

        }
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 1);
        }
    }

}
