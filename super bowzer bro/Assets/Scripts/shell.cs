using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public bool isonground = false;
    public float health = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isonground)
        {
            transform.Translate(Vector3.right * -8f * Time.deltaTime);
        }

        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "platform" && isonground == false)
        {
            isonground = true;
        }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("hitenemy");
            health -= 1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("hitenemy");
        }
    }
}
