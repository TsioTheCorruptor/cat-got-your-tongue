using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmenager : MonoBehaviour
{
    public GameObject handgun_collider;
    public Transform cursor;
    public Animator handgun_animator;
    public Animator shotgun_animator;
    public Camera camera;
  public   Vector2 mousepos;
    public GameObject handgun;
    public GameObject shotgun;
    float delaytime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delaytime += Time.deltaTime;
        mousepos = camera.ScreenToWorldPoint(Input.mousePosition);
        cursor.position = mousepos;
        handgun_();
        //shotgun_();
        
    }
    void handgun_()
    {
 handgun.transform.position = new Vector2(mousepos.x, handgun.transform.position.y);
    if (Input.GetMouseButton(0) && delaytime >= 0.6f)
    {
        Instantiate(handgun_collider, mousepos, handgun_collider.transform.rotation);
        handgun_animator.SetBool("shoot", true);
            delaytime = 0;
            }
    }
    void shotgun_()
    {
        shotgun.transform.position = new Vector2(mousepos.x,shotgun.transform.position.y);
        if (Input.GetMouseButton(0) && delaytime >= 1f)
        {
            Instantiate(handgun_collider, mousepos, handgun_collider.transform.rotation);
            shotgun_animator.SetBool("shoot", true);
            delaytime = 0;
        }
    }
}
