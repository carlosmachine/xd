using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_plat : MonoBehaviour
{
    public float falldelay = 1f;
    public float respawndelay = 3f;
    private Vector3 start;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("fall", falldelay);
            Invoke("respawn", falldelay + respawndelay);
        }
    }

    void fall()
    {
        rb.isKinematic = false;
        bc.isTrigger = true;
    }

    void respawn()
    {
        transform.position = start;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        bc.isTrigger = false;
    }
}
