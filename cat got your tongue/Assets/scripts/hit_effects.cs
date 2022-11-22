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
    public GameObject bomb;
    public GameObject dizzy_cat;
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
           static_script.health -= 5;
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
                target.gameObject.GetComponent<Image>().sprite = brkn_ink;
            }
        }
        if (gameObject.tag == "bomb")
        {
            if (collision.tag == "handgun_bull")
            {
                static_script.stop_appearences = true;
                StartCoroutine(resume(6));
                bomb.transform.position = transform.position;
                bomb.SetActive(false);
                bomb.SetActive(true);
                target.enabled = false;
                target.gameObject.GetComponent<Image>().sprite = brkn_ink;
                Invoke("activate_dizzy", 2);
            }
            if (collision.tag == "shotgun_bull")
            {
                static_script.stop_appearences = true;
                StartCoroutine(resume(6));
                bomb.transform.position = transform.position;
                bomb.SetActive(false);
                bomb.SetActive(true);
               
                target.enabled = false;
                Invoke("activate_dizzy", 2);
            }
        }
    }
    IEnumerator resume(float time)
    {
        yield return new WaitForSeconds(time);
        static_script.stop_appearences = false;
    }
    void activate_dizzy()
    {
 dizzy_cat.SetActive(true);
    }
}
