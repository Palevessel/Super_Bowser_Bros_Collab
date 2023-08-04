using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour
{
    public Transform parent;
    public float speed = 6f;
    public Transform originalposition;
    public GameObject explosion;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = parent;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       Instantiate(explosion, transform.position, Quaternion.identity);
       transform.position = originalposition.position;
       transform.parent = originalposition;
    }
}
