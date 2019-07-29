using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Ground : MonoBehaviour
{
    private Player_controller player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player_controller>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
            player.transform.parent = col.transform;
        }

        if (col.gameObject.tag == "Platform")
        {
            
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
                        
        }

        if (col.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
