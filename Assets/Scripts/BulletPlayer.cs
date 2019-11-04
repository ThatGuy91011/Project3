using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private Transform tf;

    public float speed;

    public int numBullets;

    private AudioSource Shoot;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        Shoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves at a constant pace
        tf.position += tf.up * speed;

        Shoot.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Only destroys the object if it is an enemy
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
