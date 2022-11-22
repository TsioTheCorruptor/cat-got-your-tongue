using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ui_menager : MonoBehaviour
{
    Vector2 startpos;
    int appeartype;
    int appeartype2;
    public Image sr;
    public Sprite ink;
    public Sprite cat;
    public Sprite bomb;
    int movetype;
    public GameObject child;
    public BoxCollider2D targetcollider;
    public int uptype;
    public float stay_up_for;
    public float appearspeed;
    public float move_sum;
    float upvalue=0;
    bool startup;
    bool startup2;
    bool startup3;
    bool startdown;
    bool stopup;
    bool do_once=false;
    bool do_once2 = false;
    bool do_once3 = false;
    float randomdelay;
    float delay_countup;
    float delay_countup2;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(static_script.cats_available);
 randomdelay = Random.Range(3.0f, 5.0f);
        if(static_script.stop_appearences==false)
        {
delay_countup += Time.deltaTime;
        delay_countup2 += Time.deltaTime;
        }
        
        if(delay_countup2>=1&&startup!=true&&startup2!=true&&startup3!=true)
        {
            appeartype = Random.Range(0, 200);
            appeartype2 = Random.Range(0, 100);
            delay_countup2 = 0;
        }
        if(delay_countup>=randomdelay)
        {
            ;
        if(appeartype>=180||startup==true)
        {
                movetype = 1;
                if(movetype==1&&static_script.cats_available>0||startup==true)
                {
                    if(do_once==false)
                    { 
                    static_script.cats_available--;
                        do_once = true;
                    }
                    sr.sprite = cat;
                child.tag = "cat";
                
            startup = true;
            if(upvalue<move_sum&&stopup==false)
            {
                    StartCoroutine(goup(0,uptype));
            }
            else
            { 
            StartCoroutine(godown_hide(stay_up_for,uptype));
           }
            }
            }

            if ((appeartype>5&&appeartype<89) || startup2 == true)
            {
                movetype = 2;
                if(movetype==2)
                {
                    if(do_once2==false)
                    { 
                   sr.sprite = ink;
                        do_once2 = true;
                    }
                child.tag = "ink";
                startup2 = true;
                if (upvalue < move_sum && stopup == false)
                {
                    StartCoroutine(goup(0, uptype));
                }
                else
                {
                    StartCoroutine(godown_hide(stay_up_for, uptype));
                }
                }
            }
            if (appeartype <= 6 || startup3 == true)
            {
                movetype = 3;
                if (movetype == 3)
                {
                    if (do_once3 == false)
                    {
                        sr.sprite =bomb;
                        do_once3 = true;
                    }
                    child.tag = "bomb";
                    startup3 = true;
                    if (upvalue < move_sum && stopup == false)
                    {
                        StartCoroutine(goup(0, uptype));
                    }
                    else
                    {
                        StartCoroutine(godown_hide(stay_up_for, uptype));
                    }
                }
            }




        }
    }
    IEnumerator goup(float time2,int type)
    {
        yield return new WaitForSeconds(time2);
        targetcollider.enabled = true;
upvalue += appearspeed * Time.deltaTime;
        if(upvalue>move_sum)
        {
            upvalue = move_sum;
        }
        switch(type)
        {
            case 0:
 transform.position = new Vector2(transform.position.x,transform.position.y+(appearspeed*Time.deltaTime));
                break;
 case 1:
 transform.position = new Vector2(transform.position.x, transform.position.y - (appearspeed * Time.deltaTime));
        break;
            case 2:
                transform.position = new Vector2(transform.position.x + (appearspeed * Time.deltaTime), transform.position.y );
                break;
            case 3:
                transform.position = new Vector2(transform.position.x - (appearspeed * Time.deltaTime), transform.position.y);
                break;

        }
    }
        
    




    
    IEnumerator godown_hide(float time,int type2)
    {
        yield return new WaitForSeconds(time);
 if(upvalue>=move_sum||startdown==true)
            {
                startdown = true;
                stopup = true;
                upvalue -= appearspeed * Time.deltaTime;
            if(upvalue<0)
            {
                upvalue = 0;
            }
            switch(type2)
            {
                case 0:
transform.position=new Vector2(transform.position.x,transform.position.y-(appearspeed*Time.deltaTime));
                    break;
                case 1:
                    transform.position = new Vector2(transform.position.x, transform.position.y + (appearspeed * Time.deltaTime));
                    break;
                case 2:
                    transform.position = new Vector2(transform.position.x- (appearspeed * Time.deltaTime) , transform.position.y );
                    break;
                case 3:
                    transform.position = new Vector2(transform.position.x + (appearspeed * Time.deltaTime), transform.position.y);
                    break;
            }
                
                if(upvalue<=0)
                {
                transform.position = startpos;
                if(child.tag=="cat")
                {
                    static_script.cats_available++;
                }
                targetcollider.enabled = false;
                    startup = false;
                startup2 = false;
                    stopup = false;
                    startdown = false;
                delay_countup = 0;
                movetype = 0;
                appeartype = 0;
                do_once = false;
                do_once2 = false;
                do_once3 = false;
                startup3 = false;

            }
            }
    }

}
