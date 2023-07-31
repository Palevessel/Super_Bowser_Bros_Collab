using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    public Transform cameramover;
    public Vector3 newposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newposition = new Vector3(cameramover.position.x, 0f, -10f);
            transform.position = newposition;
    }
}
