using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class methods : MonoBehaviour
{
    public bool change_scene_on_awake;
    public int scene_index;
    public bool gun_type_debug;
    // Start is called before the first frame update
    void Start()
    {
        if(change_scene_on_awake==true)
        {
            changescene(scene_index);
        }
    }
    private void Update()
    {
        if(gun_type_debug==true)
        {
            Debug.Log(static_script.guntype);
        }
    }

    // Update is called once per frame

    void changescene(int index)
    {
        SceneManager.LoadScene(index);
    }
    void changesceneto1()
    {
        SceneManager.LoadScene(1);
    }
   public void setguntype_1()
    {
        static_script.guntype = 1;
    }
   public  void setguntype_2()
    {
        static_script.guntype = 2;
    }
   public void setguntype_3()
    {
        static_script.guntype = 3;
    }
}
