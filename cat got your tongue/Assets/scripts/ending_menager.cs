using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class ending_menager : MonoBehaviour
{
    int endtype=-1;
    public GameObject fadescreen;
    public GameObject b_ending;
    public TextMeshProUGUI time;
   double gametime;
    public GameObject g_ending;
    public List<GameObject> tongues = new List<GameObject>();
    bool once=false;
    // Start is called before the first frame update
    void Start()
    {
        static_script.time = 0;
         static_script. health = 150;
   static_script. cats_available = 1;
   static_script. stop_appearences = false;
    static_script. stay_up_for_multiplier = 1f;
   static_script. gundelay_multiplier = 1f;
    static_script. cat_spawn_delay_multiplier = 1;
   static_script. catnip_enabled = true;

}

    // Update is called once per frame
    void Update()
    {
        static_script.time += Time.deltaTime;
        gametime = static_script.time;
        if(endtype==-1)
        {
time.text = gametime.ToString("#.#");  
        }
        

        if(Input.GetKeyDown(KeyCode.R))
        {
            Invoke("end_", 0);
        }
        if(endtype==-1)
        {
            if(static_script.health<=0)
            {
                endtype = 0;
            }
            if (static_script.maxbullets <= 0)
            {
                endtype = 1;
            }
        }
        switch(endtype)
        {
            case 0:
                StartCoroutine(ending(1.5f, g_ending, 2));
                break;
            case 1:
                StartCoroutine(ending(1.5f, b_ending, 2));
                break;
            case -1:

                break;
        }

        
    }
    IEnumerator ending(float time,GameObject uitoenable,float time2)
    {
        fadescreen.SetActive(true);
        yield return new WaitForSeconds(time);
        uitoenable.SetActive(true);
        yield return new WaitForSeconds(time2);
        if(once==false)
        {
 if(gametime<=115&&endtype==0)
        {
            tongues[0].SetActive(true);
        }
        if (gametime > 115&&gametime<=140 && endtype == 0)
        {
            tongues[1].SetActive(true);
        }
        if (gametime > 140&&  endtype == 0)
        {
            tongues[2].SetActive(true);
        }
            once = true;
        }
      
    }
    void end_()
    {
        SceneManager.LoadScene(1);
    }
}
