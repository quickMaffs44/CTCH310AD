using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private float offsetx;
    private float offsety;
    private float offsetz;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        //offsetx = transform.position.x - player.transform.position.x;
        //offsety = transform.position.z - player.transform.position.z;
        //position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    position.x--;
        //    this.transform.position = position;
        //}

    }

    // called after Update every frame
    private void LateUpdate() 
    {
        transform.position = player.transform.position + offset;

        //position = new Vector3(player.transform.position.x - offsetx,
        //                       transform.position.y - offsety,
        //                       player.transform.position.z - offsetz);
        //this.transform.position = position;
    }
}
