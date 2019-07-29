using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Obj : MonoBehaviour
{
    public string destroyState;
    public float timeforDisable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            yield return new WaitForSeconds(timeforDisable);

            foreach(Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }

            Destroy(gameObject);
        }
    }
}
