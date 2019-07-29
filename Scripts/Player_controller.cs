using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 2f;
    public float max_speed = 5f;
    public float dash_speed = 100f;
    private float dash_time ;
    public float start_dashtime;
    private int direction;
    public bool grounded;
   
    public float cooldown = 1;
    public float cooldownTimer;



    private bool jump;
    public float  jumpforce = 6.5f;
    private Rigidbody2D rb;
    private Animator anim;
    CircleCollider2D   attackcollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackcollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackcollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", grounded);

        

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;

        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q ) && cooldownTimer == 0)
            {

                direction = 1;
                anim.SetTrigger("Attack");
                rb.gravityScale = 0;
                cooldownTimer = cooldown;
                attackcollider.enabled = true;
                

            }

            else if (Input.GetKeyDown(KeyCode.E) && cooldownTimer == 0)
            {

                direction = 2;
                anim.SetTrigger("Attack");
                rb.gravityScale = 0;
                cooldownTimer = cooldown;
                attackcollider.enabled = true;

            }
        }

        
           
        

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        

        rb.AddForce(Vector2.right * speed * h);


        float limitSpeed = Mathf.Clamp(rb.velocity.x, -max_speed, max_speed);
        rb.velocity = new Vector2(limitSpeed, rb.velocity.y);


        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump == true)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            jump = false;
        }

        if (dash_time <= 0  )
        {
            direction = 0;
            dash_time = start_dashtime;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 10;
            attackcollider.enabled = false;

        }

        if (direction == 1 )
        {
            rb.AddForce(Vector2.left * max_speed * dash_speed);
            rb.velocity = Vector2.left * max_speed * dash_speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            dash_time -= Time.deltaTime;
            


        }

        else if (direction == 2 )
        {
            rb.AddForce(Vector2.right * max_speed * dash_speed);
            rb.velocity = Vector2.right * max_speed * dash_speed;
            transform.localScale = new Vector3(1f, 1f, 1f);

            dash_time -= Time.deltaTime;
            
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
        }


       





    }
}
