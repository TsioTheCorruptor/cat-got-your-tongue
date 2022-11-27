using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,2));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="handgun_bull")
        {
            static_script.maxbullets += 7;
            destroy_box();
        }
        if (collision.tag == "shotgun_bull")
        {
            static_script.maxbullets += 4;
            destroy_box();
        }
        if(collision.tag=="destroy")
        {
            Destroy(gameObject, 0);
        }
    }
    private void destroy_box()
    {
        Destroy(gameObject, 0);
    }
}
