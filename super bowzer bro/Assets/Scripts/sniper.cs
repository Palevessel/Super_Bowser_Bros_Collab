using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : MonoBehaviour
{
    public float targetingrange = 5;
    public Transform target;
    public LayerMask enemymask;
    public Transform[] enemies;
    public float shoottimer = 5f;
    public float firetimer = 0.2f;
    public GameObject bullet;
    public Transform shotpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reload();
        if (target == null)
        {
            findtarget();
            return;
        }
        if (target == null)
        {
            firetimer = 0.2f;
        }
        if (target != null)
        {
            firetimer -= Time.deltaTime;
        }
        if(target != null && shoottimer <= 0f && firetimer <= 0f)
        {
            Instantiate(bullet, shotpos.position, transform.rotation);
            shoottimer = 5f;
            firetimer = 0.2f;
        }

        rotatetowardstarget();
        if (!checkiftargetisinrange())
        {
            target = null;
            firetimer = 0.2f;
        } 
    }

    void reload()
    {
        if (shoottimer >= 0f)
        {
            shoottimer -= Time.deltaTime;
        }
    }

    private bool checkiftargetisinrange()
    {
       return Vector2.Distance(transform.position, target.position) <= targetingrange;
    }

    private void rotatetowardstarget()
    {
        float anglez = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg + 180;
        Quaternion targetrotation = Quaternion.Euler(new Vector3(0f, 0f, anglez));
        transform.rotation = targetrotation;
    }

    void findtarget() { 
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)transform.position, 0f, enemymask);
        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingrange);
    }
}
