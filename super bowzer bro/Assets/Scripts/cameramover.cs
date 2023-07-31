using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramover : MonoBehaviour
{
    public float speed = 5f;
    public float mover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * mover * Time.deltaTime);
    }
}
