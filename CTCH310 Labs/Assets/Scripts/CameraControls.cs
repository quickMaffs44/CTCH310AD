using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed;
    Vector3 position;
    public float viewRange = 50f;
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

        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        float x = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, y, 0);

        // cancel out z rotation
        float zCorrection = -transform.eulerAngles.z;
        transform.Rotate(0, 0, zCorrection);

        // x rotation boundaries
        x = Mathf.Clamp(x, -viewRange, viewRange);
        print(x + "\n");
        transform.localRotation *= Quaternion.Euler(-x, 0, 0);

        //float xCorrection = -transform.eulerAngles.x;
        //if (this.transform.eulerAngles.x >= 10) {
        //    transform.Rotate(xCorrection + 10, 0, 0);
        //}
        //if (this.transform.eulerAngles.x <= -50)
        //{
        //    transform.Rotate(-xCorrection, 0, 0);
        //}
    }
}
