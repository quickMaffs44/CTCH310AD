using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed;
    Vector3 position;
    public int viewRange = 30;
    public float mouseSensitivity = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        if (Input.GetKey(KeyCode.Space))
        {
            ResetCamera();
        }

        // make calculations/update game state
        Move();
        Rotate();

        // update visuals/render game state

    }

    void Move()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //// Fly
            //position += this.transform.forward * speed;
            //this.transform.position = position;

            position.z += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.z -= speed;
            this.transform.position = position;
        }
    }
    
    void Rotate()
    {
        
        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        float x = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Y Rotation
        transform.Rotate(0, y, 0);

        float zCorrection = -transform.eulerAngles.z;
        // Cancel out z rotation
        transform.Rotate(0, 0, zCorrection);

        
        float xRotation = transform.eulerAngles.x;
        float yRotation = transform.eulerAngles.y;
        bool facingUp = false;

        // Determine if rotation is looking at top or bottom half
        if (xRotation <= 360 && xRotation >= 270)
        {
            facingUp = true;
        }

        // X Rotation and Boundaries
        if (xRotation >= (90 - viewRange) && !facingUp)
        {
            this.transform.localRotation = Quaternion.Euler((90 - viewRange), yRotation, 0);
        }
        else if (xRotation <= (360 - viewRange) && facingUp)
        {
            this.transform.localRotation = Quaternion.Euler((360 - viewRange), yRotation, 0);
        }
        else
        {
            transform.Rotate(-x, 0, 0);
        }
    }

    void ResetCamera()
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

