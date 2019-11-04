using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float volume;

    void Update()
    {
        //These give the volumes for walking and shooting, shooting being much louder
        if (volume < 0)
        {
            volume = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            volume += 5f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            volume += 5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            volume += 5f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            volume += 5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            volume += 10;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            volume -= 5f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            volume -= 5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            volume -= 5f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            volume -= 5f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            volume -= 10;
        }


    }

}
