using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walk : MonoBehaviour
{
    public float speed = 5f;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "auto bullet")
        {
            health -= 0.15f;
        }        
        if(other.gameObject.tag == "bullet")
        {
            health -= 0.5f;
        }        
        if(other.gameObject.tag == "sniper bullet")
        {
            health -= 1f;
        }
    }  
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "auto bullet")
        {
            health -= 0.20f;
        }        
        if(other.gameObject.tag == "bullet")
        {
            health -= 0.5f;
        }        
        if(other.gameObject.tag == "sniper bullet")
        {
            health -= 1f;
        }
    }
}
