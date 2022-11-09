using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class methods : MonoBehaviour
{
    public bool change_scene_on_awake;
    public int scene_index;
    // Start is called before the first frame update
    void Start()
    {
        if(change_scene_on_awake==true)
        {
            changescene(scene_index);
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
}
