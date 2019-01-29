using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed;
    Vector3 position;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
