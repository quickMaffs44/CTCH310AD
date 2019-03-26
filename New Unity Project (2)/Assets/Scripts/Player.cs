using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip shootClip;
    private AudioSource audioSource;
    public float volMin = .5f;
    public float volMax = 1.0f;

    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float fallSpeed;
    public float bulletLifetime;


    public float rotateSpeed;
    public float moveSpeed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // another way to move the player ______________
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //________________

        if(Input.GetKey(KeyCode.Space))
        {
            Shoot();
            ShootSFX();
        }
        this.transform.TransformDirection(Vector3.down * 9.8f);
    }

    void Shoot()
    {
        // Create bullet from the prefab
        // at the spawn point position and rotation
        var newBullet = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        // add velocity to bullet
        var bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = newBullet.transform.forward * bulletSpeed;

        // Destroy bullet after 2 seconds
        Destroy(newBullet, bulletLifetime);


    }

    void ShootSFX()
    {
        float vol = Random.Range(volMin, volMax);
        audioSource.PlayOneShot(shootClip, vol);
    }
}
