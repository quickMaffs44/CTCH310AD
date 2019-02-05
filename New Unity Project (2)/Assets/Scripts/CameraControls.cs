using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get user input

        // make calculations/update game state
        Move();

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
            position.z += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.z -= speed;
            this.transform.position = position;
        }

        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");

        transform.Rotate(-x, y, 0);

        // cancel out z rotation
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);

        // x rotation boundaries


    }
}
