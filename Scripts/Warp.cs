using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject target;
    public GameObject Player;

    bool start = false;
    bool isFadein = false;
    float alpha = 0;
    float fadetime = 1.5f;
   
    IEnumerator  OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject .tag == "Player")
        {
            Fadein();
            yield return new WaitForSeconds(fadetime);

            StartCoroutine(Teleport());
           
            Fadeout();
        }
    }

    IEnumerator Teleport()
    {
       

        yield return new WaitForSeconds(0);
        Player.transform.position = target.transform.GetChild(0).transform.position;

        

       
    }

    void OnGUI()
    {
        if (!start)
            return;


        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadein)
        {
            alpha = Mathf.Lerp(alpha, 1.1f, fadetime * Time.deltaTime);
        }

        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadetime * Time.deltaTime);
        }

        if (alpha < 0) start = false;
       
      
    }

    void Fadein()
    {
        start = true;
        isFadein = true;
    }

    void Fadeout()
    {
        isFadein = false;
    }
}
