using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_menager : MonoBehaviour
{
    public int uptype;
    public float stay_up_for;
    public float appearspeed;
    float upvalue=0;
    bool startup;
    bool startdown;
    bool stopup;
    float randomdelay;
    float delay_countup;
    // Start is called before the first frame update
    void Start()
    {
       randomdelay = Random.Range(3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        delay_countup += Time.deltaTime;
        if(delay_countup>=randomdelay)
        {
            ;
        if(Input.GetKeyDown(KeyCode.Space)==true||startup==true)
        {
                
            startup = true;
            if(upvalue<1&&stopup==false)
            {
                    StartCoroutine(goup(0,uptype));
            }
            else
            { 
            StartCoroutine(godown_hide(1,uptype));
           }
            }
           


                   
        }
    }
    IEnumerator goup(float time2,int type)
    {
        yield return new WaitForSeconds(time2);
upvalue += appearspeed * Time.deltaTime;
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
 if(upvalue>=1f||startdown==true)
            {
                startdown = true;
                stopup = true;
                upvalue -= appearspeed * Time.deltaTime;
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
                    startup = false;
                    stopup = false;
                    startdown = false;
                delay_countup = 0;
            }
            }
    }

}
