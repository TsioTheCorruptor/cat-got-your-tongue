using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmenager : MonoBehaviour
{
    public Camera camera;
  public   Vector2 mousepos;
    public GameObject handgun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = camera.ScreenToWorldPoint(Input.mousePosition);
        handgun.transform.position = new Vector2(mousepos.x, handgun.transform.position.y);
    }
}
