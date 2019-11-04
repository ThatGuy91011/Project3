using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    private Transform tf;

    public float speed;

    public int numBullets;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves at a constant pace
        tf.position += tf.up * speed;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Only destroys the object if it is an player
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}