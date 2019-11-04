using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySense : MonoBehaviour
{
    public int Test = 10;
    private Transform tf;
    public GameObject pf;

    public GameObject Player;

    public float speed;


    public GameObject test;

    Text notice;

    public int numBullets;

    public float volume;

    private float dist;

    private AudioSource Shoot;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        pf = GameObject.Find("Bullet");
        Player = GameObject.Find("Player");
        test = GameObject.Find("EnemyNotice");
        notice = test.GetComponent<Text>();
        Shoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanHear(Player))
        {
            //Changes the enemy's idle state to a looking state
            notice.text = "?";
            Vector3 directionToLook = Player.transform.position - tf.position;
            tf.up = directionToLook;

            if (CanSee(Player))
            {
                Shooting();
            }

        }

        if (CanSee(Player))
        {
            Shooting();
        }


    }

    public bool CanHear(GameObject target)
    {
        // Get the target's NoiseMaker
        volume = target.GetComponent<NoiseMaker>().volume;

        dist = Vector3.Distance(Player.GetComponent<Transform>().position, tf.position);
        // Adjust the volume based on distance 

        if (dist <= 300)
        {
            volume *= 2;
        }

        if (dist <= 200)
        {
            volume *= 4;
        }


        // If the volume, after adjustment, is loud enough for us to hear

        if (volume >= 20)
        {
            // we heard it, return true
            return true;
        }

        // Otherwise
        
        // we did not hear it, return false
        return false;
        

    }
    public bool CanSee(GameObject target)
    {
        // We use the location of our target in a number of calculations - store it in a variable for easy access.
        Transform targetTf = target.GetComponent<Transform>();
        Vector3 targetPosition = targetTf.position;

        // Find the vector from the agent to the target
        // We do this by subtracting "destination minus origin", so that "origin plus vector equals destination."
        Vector3 agentToTargetVector = targetPosition - transform.position;

        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
        float angleToTarget = Vector3.Angle(agentToTargetVector, transform.forward);

        // if that angle is less than our field of view
        //if (angleToTarget < 45f)
        {
            // Raycast
            Debug.DrawRay(transform.position, tf.up, Color.green);
            RaycastHit2D hitInfo = Physics2D.Raycast(tf.position + new Vector3(20, 0, 0), agentToTargetVector, 400);

            // If the first object we hit is our target 
            if (hitInfo.collider.gameObject == target)
            {
                // return true 
                //    -- note that this will exit out of the function, so anything after this functions like an else
                print("Hit");
                return true;

            }
        }
        //   -- note that because we returned true when we determined we could see the target, 
        //      this will only run if we hit nothing or if we hit something that is not our target.
        print("Miss");
        return false;
    }

    void Shooting()
    {
        //Changes the enemy's idle state to an alert state
        notice.text = "!";

        //PLays a sound
        Shoot.Play();

        //Shoots a bullet
        GameObject newObject = Instantiate(pf, tf.position, tf.rotation) as GameObject;
        Destroy(newObject, 1f);
    }
    


}

