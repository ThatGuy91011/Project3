using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Use the UI code

public class HealthBarTest : MonoBehaviour
{
    public float max;// Public variable for max
    private float current;// Public variable for current
    public Image imageComponent;// Public variable for our image component


    // Use this for initialization
    void Start()
    {
        // Make sure the image component is set to filled
        imageComponent.type = Image.Type.Filled;


    }

    // Update is called once per frame
    void Update()
    {
        //Finds the current health of the player
        current = GameObject.Find("Player").GetComponent<PlayerMovement>().Hearts;
        // Find what percentage of max our current value is
        float percentOfMax = current / max;
        // Set our image percentage to that same percent
        imageComponent.fillAmount = percentOfMax;
    }
}
