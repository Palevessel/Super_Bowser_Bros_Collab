using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findenemies : MonoBehaviour
{
    public LayerMask enemymask;
    public Transform target;
    public float targetingrange = 5f;
    public float cooldown = 10f;
    public float realcooldown = 10f;
    public float enemydebugger;
    public bool shouldkaboom;
    public GameObject angel;
    public go_to_locater gtl;
    // Start is called before the first frame update
    void Start()
    {
        angel.transform.parent = null;
        angel.transform.position = gtl.startpos;
    }

    // Update is called once per frame
    void Update()
    {
        findtarget();

        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }
    void findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)transform.position, 0f, enemymask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
        if(hits.Length >= 5 && cooldown <= 0f)
        {
            boom();
            cooldown = realcooldown;
        }
        enemydebugger = hits.Length;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingrange);
    }

    public void boom()
    {
      if(!angel.activeInHierarchy)
        {
            angel.SetActive(true);
        }
    }
}
