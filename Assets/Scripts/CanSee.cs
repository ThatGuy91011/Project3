using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Shoot the player

        //This code is just a placeholder for demonstration purposes
        Destroy(other.gameObject);

    }
}

