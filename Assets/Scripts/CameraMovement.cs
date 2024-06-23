using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
        }
    }
}
