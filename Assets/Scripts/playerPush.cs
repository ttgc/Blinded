using UnityEngine;
using System.Collections;

public class playerPush : MonoBehaviour
{

    public float distance = 1f;
    //public LayerMask boxMask;

    GameObject box;
    

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);//, boxMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
        //Forced to create 2 because as we have no animation, the player never really turn back
        
        if (!GetComponent<simpleMovement>().isJumping)
        {
            if (hit1.collider != null && hit1.collider.gameObject.tag == "Box" && Input.GetKeyDown(KeyCode.Space))
            {
                box = hit1.collider.gameObject;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<boxpull>().beingPushed = true;
            }
            else if (hit2.collider != null && hit2.collider.gameObject.tag == "Box" && Input.GetKeyDown(KeyCode.Space))
            {
                box = hit2.collider.gameObject;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<boxpull>().beingPushed = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                box.GetComponent<boxpull>().beingPushed = false;
            }
        }
        
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine((Vector2)transform.position + Vector2.left * transform.localScale.x * distance, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}