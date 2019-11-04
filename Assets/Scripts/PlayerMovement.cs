using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Transform tf;

    public float speed;

    public float Hearts = 10;

    public int moveCheck = 0;

    public GameObject pf;

    public GameObject GameOver;

    public float volume;

    private AudioSource Steps;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        pf = GameObject.Find("PlayerBullet");
        volume = GetComponent<NoiseMaker>().volume;
        Steps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is out of health
        if (Hearts <= 0)
        {
            //End the game
            Hearts = 0;
            moveCheck = 0;
            //Show Game Over screen
            GameOver = GameObject.Find("GameOver");
            GameOver.GetComponent<CanvasScaler>().scaleFactor = 1;
            GameOver.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        //If the player can move
        if (moveCheck == 1)
        {
            //Right, left, up, and down controls
            if (Input.GetKey(KeyCode.RightArrow))
            {
                tf.rotation = Quaternion.Euler(0, 0, 270);
                tf.position += tf.up * speed;
                //PLays a sound with every step
                Steps.Play();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                tf.rotation = Quaternion.Euler(0, 0, 0);
                tf.position += tf.up * speed;
                Steps.Play();
            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                tf.rotation = Quaternion.Euler(0, 0, 90);
                tf.position += tf.up * speed;
                Steps.Play();
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
                tf.rotation = Quaternion.Euler(0, 0, 180);
                tf.position += tf.up * speed;
                Steps.Play();
            }

            //Shoots a bullet if the player presses space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newObject = Instantiate(pf, tf.position, tf.rotation) as GameObject;
                Destroy(newObject, 2f);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If the player gets hit
        if (other.gameObject.tag == "Bullet")
        {
            //Lose a little bit of health
            Hearts -= .1f;
        }
    }

}
