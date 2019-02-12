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

        this.transform.Rotate(-x, y, 0);
        //transform.localRotation *= Quaternion.Euler(-x, y, 0);

        // cancel out z rotation
        float zCorrection = -transform.eulerAngles.z;
        this.transform.Rotate(0, 0, zCorrection);

        // x rotation boundaries
        float xCorrection = -transform.eulerAngles.x;

        if (this.transform.localEulerAngles.x > viewRange)
        {
            this.transform.localEulerAngles = new Vector3(viewRange, 0, 0);
        }
        else if (this.transform.localEulerAngles.x < -viewRange)
        {
            this.transform.localEulerAngles = new Vector3(-viewRange, 0, 0);
        }


        //print(x + "\n");

        //if (transform.rotation.x > viewRange || transform.rotation.x < -viewRange)
        //this.transform.localEulerAngles = new Vector3(Mathf.Clamp(Camera.main.transform.localEulerAngles.x, -viewRange, viewRange), 0, 0);

        //if (transform.localRotation.x > viewRange || transform.localRotation.x < -viewRange)
        //transform.localRotation *= Quaternion.Euler(-x, 0, 0);



        //Mathf.Clamp(x, -viewRange, viewRange)

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
