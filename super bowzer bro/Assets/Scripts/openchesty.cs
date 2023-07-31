using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openchesty : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        print("mouseover");
        anim.Play("open");
    }

    void OnMouseExit()
    {
        anim.Play("New Animation");
    }
}
