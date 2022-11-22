using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawn_this;
    public Transform spawnerda;
    public GameObject canvas;
    GameObject instantiated;
    float countup;
    float delay = 5;
    public float maxx;
    public float minx;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countup += Time.deltaTime;
        if(countup>=delay)
        {
            x = Random.Range(minx, maxx);
          instantiated=  Instantiate(spawn_this, new Vector2(x, spawnerda.position.y), spawnerda.rotation);
            instantiated.transform.SetParent(canvas.transform);
            instantiated.SetActive(true);
            countup = 0;
        }
    }
}
