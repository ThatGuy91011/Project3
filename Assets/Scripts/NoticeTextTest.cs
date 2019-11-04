using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeTextTest : MonoBehaviour
{
    private Transform tf;

    private Transform etf;

    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        etf = GameObject.Find("Enemy 1").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Positions the Notice text so that it is always near the enemy
        x = etf.position.x + 70;
        y = etf.position.y + 45;
        z = etf.position.z;
        tf.position = new Vector3(x, y, z);
    }
}
