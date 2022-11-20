using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class hit_effects : MonoBehaviour
{
    public Sprite brkn_ink;
    public BoxCollider2D target;
    public TextMeshProUGUI health;
    //int health_count;
    public GameObject ink;
    // Start is called before the first frame update
    void Start()
    {
       
        health.text = static_script.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag=="cat")
        { 
        if(collision.tag=="handgun_bull")
        {
            static_script.health -= 2;
            health.text = static_script.health.ToString();
        }
        if (collision.tag == "shotgun_bull")
        {
           static_script.health -= 4;
            health.text = static_script.health.ToString();
        }
        }
        if (gameObject.tag == "ink")
        {
            if (collision.tag == "handgun_bull")
            {
                ink.SetActive(true);
                target.enabled = false;
                target.gameObject.GetComponent<Image>().sprite = brkn_ink;
            }
            if (collision.tag == "shotgun_bull")
            {
                ink.SetActive(true);
                target.enabled = false;
            }
        }
    }
}
