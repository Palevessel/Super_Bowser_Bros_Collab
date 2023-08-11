using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_locater : MonoBehaviour
{
    public GameObject missile;
    public GameObject missile2;
    public Transform locator;
    public Transform startinglocation;
    public bool isgoingtolocater = true;
    public float speed = 5f;
    public Vector3 mypos;
    public float difference;
    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        transform.position = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        if(missile.transform.position.x != locator.position.x)
        {
            if (isgoingtolocater)
            {
                transform.position = Vector3.MoveTowards(transform.position, mypos, speed * Time.deltaTime);
            }
        }
        mypos = new Vector3(locator.position.x, transform.position.y, 0);


        if(transform.position.x == locator.position.x)
        {
            Debug.Log("above!");
            missile.transform.parent = null;
            isgoingtolocater = false;
        }

        if (!isgoingtolocater)
        {
            transform.position = Vector3.MoveTowards(transform.position, startpos, speed * Time.deltaTime);
        }

        difference = transform.position.x - startpos.x;


        
        if(transform.position == startpos && missile.transform.parent != null)
        {
            isgoingtolocater = true;
            gameObject.SetActive(false);
        }
    }
}
