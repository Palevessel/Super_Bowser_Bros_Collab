using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode_stuff : MonoBehaviour
{
    public float fieldofimpact;
    public LayerMask enemymask;
    public float force;
    public float damage;
    public enemy_walk ew;
    // Start is called before the first frame update
    void Start()
    {
        explode();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofimpact, enemymask);

        foreach(Collider2D obj in objects)
        {
            obj.GetComponent<enemy_walk>().health -= 5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofimpact);
    }
}
