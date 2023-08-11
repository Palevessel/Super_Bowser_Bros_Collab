using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_starting_location : MonoBehaviour
{
    public go_to_locater gtl;
    public Transform me;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gtl.startinglocation = me; 
    }
}
