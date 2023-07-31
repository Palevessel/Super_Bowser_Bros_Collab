using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    public Vector3 mouseposition;
    public GameObject[] areastoplace;
    public float targetingrange = 2;
    public Transform target;
    public LayerMask placementmask;
    public bool stayonmousepos = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stayonmousepos == true)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseposition.x, mouseposition.y, 0f);
        }

        if(target != null)
        {
            stayonmousepos = false;
        }

        if(target == null)
        {
            stayonmousepos = true;
        }
    }

    private bool checkiftargetisinrange()
    {
        return Vector2.Distance(transform.position, target.position) <= targetingrange;

    }

    void findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), targetingrange, (Vector2)transform.position, 0f, placementmask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "canplaceher")
        {
            stayonmousepos = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), targetingrange);
    }
}
