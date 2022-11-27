using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class hit_effects : MonoBehaviour
{
    public Sprite brkn_ink;
    public Sprite brkn_nip;
    public BoxCollider2D target;
    public TextMeshProUGUI health;
    //int health_count;
    public GameObject ink;
    public GameObject bomb;
    public GameObject dizzy_cat;
    public GameObject nip_text;
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
                static_script.maxbullets += 3;
            }
            if (collision.tag == "shotgun_bull")
            {
                ink.SetActive(true);
                target.enabled = false;
                target.gameObject.GetComponent<Image>().sprite = brkn_ink;
                static_script.maxbullets += 2;
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
                if(static_script.cats_available>0)
                { 
                Invoke("activate_dizzy", 2);
                }
                else
                {
                    Invoke("activate_dizzy", 4.5f);
                }
            }
        }
        if (gameObject.tag == "nip")
        {
            if (collision.tag == "handgun_bull")
            {
                target.gameObject.GetComponent<Image>().sprite = brkn_nip;
                StartCoroutine(change_catdelay(5, 0.1f));
                StartCoroutine(upg_texts(5, nip_text));
                StartCoroutine(change_appear_delay_catnip(5,0.6f));
                StartCoroutine(change_gundelay_catnip(5,0.6f));
            }
            if (collision.tag == "shotgun_bull")
            {
                target.gameObject.GetComponent<Image>().sprite = brkn_nip;
                StartCoroutine(change_catdelay(5, 0.1f));
                StartCoroutine(upg_texts(5, nip_text));
                Debug.Log("ok");
                StartCoroutine(change_appear_delay_catnip(5,0.6f));
                StartCoroutine(change_gundelay_catnip(5,0.6f));
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
    IEnumerator change_appear_delay_catnip(float time2,float delay)
    {
        static_script.catnip_enabled = false;
        static_script.stay_up_for_multiplier = delay;
        
        yield return new WaitForSeconds(time2);
        static_script.catnip_enabled = true;
        static_script.stay_up_for_multiplier = 1f;
       
    }
    IEnumerator change_gundelay_catnip(float time3,float delay2)
    {
        static_script.gundelay_multiplier =delay2;

        yield return new WaitForSeconds(time3);
        static_script.gundelay_multiplier = 1f;

    }
    IEnumerator change_catdelay(float time3, float delay3)
    {
        static_script.cat_spawn_delay_multiplier = delay3;
        yield return new WaitForSeconds(time3);
        static_script.cat_spawn_delay_multiplier = 1f;
    }
    IEnumerator upg_texts(float time3,GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(time3);
        text.SetActive(false);
    }
}
