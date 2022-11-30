using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gunmenager : MonoBehaviour
{
    public AudioSource aus;
    public List<AudioClip> sounds = new List<AudioClip>();
    public TextMeshProUGUI ammo;
    public GameObject handgun_collider;
    public GameObject shotgun_collider;
    public Transform cursor;
    public Animator handgun_animator;
    public Animator shotgun_animator;
    public Camera camera__;
  public   Vector2 mousepos;
    public GameObject handgun;
    public GameObject shotgun;
    float delaytime;
    // Start is called before the first frame update
    void Start()
    {
        if(static_script.guntype==0)
        {
            handgun.SetActive(true);
            static_script.maxbullets = 15;
        }
        if (static_script.guntype == 1)
        {
            shotgun.SetActive(true);
            static_script.maxbullets = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(static_script.maxbullets<0)
        {
            static_script.maxbullets = 0;
        }
        switch(static_script.guntype)
        {
            case 0:
                if(static_script.maxbullets>15)
                {
                    static_script.maxbullets = 16;
                }
                break;
            case 1:
                if(static_script.maxbullets>7)
                {
                    static_script.maxbullets = 7;
                }
                break;
        }
        ammo.text = static_script.maxbullets.ToString();
        delaytime += Time.deltaTime;
        mousepos = camera__.ScreenToWorldPoint(Input.mousePosition);
        cursor.position = mousepos;
        if(static_script.guntype==0)
        {
handgun_();
        }
     if(static_script.guntype==1)
        {
 shotgun_();
        }
       
        
    }
    void handgun_()
    {
 handgun.transform.position = new Vector2(mousepos.x, handgun.transform.position.y);
    if (Input.GetMouseButton(0) && delaytime >= 0.5f*static_script.gundelay_multiplier)
    {
            aus.PlayOneShot(sounds[0]);
            Invoke("minusbullet", 0.05f);
            Instantiate(handgun_collider, mousepos, handgun_collider.transform.rotation);
        handgun_animator.SetBool("shoot", true);
            delaytime = 0;
            }
    }
    void shotgun_()
    {
       
        shotgun.transform.position = new Vector2(mousepos.x,shotgun.transform.position.y);
        if (Input.GetMouseButton(0) && delaytime >= 1f*static_script.gundelay_multiplier)
        {
            aus.PlayOneShot(sounds[1]);
            Invoke("minusbullet", 0.05f);
            Instantiate(shotgun_collider, mousepos, handgun_collider.transform.rotation);
            shotgun_animator.SetBool("shoot", true);
            delaytime = 0;
        }
    }
    void minusbullet()
    {
 static_script.maxbullets--;
    }
}
