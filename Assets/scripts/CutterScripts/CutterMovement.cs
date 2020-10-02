using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutterMovement : MonoBehaviour
{

    private void FixedUpdate()
    {
        movement();
    }


    void movement()
    {
        float h = Input.GetAxis("horizontal");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), 
            transform.position.y, transform.position.z); // movement bounded

        transform.position += new Vector3(h,0,0)*0.1f;


    }

}
