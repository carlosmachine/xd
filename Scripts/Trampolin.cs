using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    bool Ontop;
    Animator anim;
    GameObject bouncer;
    
    
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Ontop == true)
        {
            anim.SetBool("isStepped", true);
            bouncer = other.gameObject;
        }
    }

    void OnTriggerEnter2D()
    {
        Ontop = true;
    }

    void OnTriggerExit2D()
    {
        Ontop = false;
        anim.SetBool("isStepped", false);
    }

    void jump()
    {
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
