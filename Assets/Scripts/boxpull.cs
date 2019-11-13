using UnityEngine;
using System.Collections;

public class boxpull : MonoBehaviour
{
    public bool beingPushed;
    float xPos;
     
    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (beingPushed == false)
        {
            transform.position = new Vector3(xPos, transform.position.y);
        }
        else
        {
            xPos = transform.position.x;
        }
                       
    }
}