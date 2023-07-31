using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class the_destination : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            gm.health -= 1f;
            Destroy(other.gameObject);
        }
    }
}
