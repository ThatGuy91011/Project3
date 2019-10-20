using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform tf;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.rotation = Quaternion.Euler(0, 0, 270);
            tf.position += tf.up * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.rotation = Quaternion.Euler(0, 0, 0);
            tf.position += tf.up * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.rotation = Quaternion.Euler(0, 0, 90);
            tf.position += tf.up * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.rotation = Quaternion.Euler(0, 0, 180);
            tf.position += tf.up * speed;
        }
    }
}
