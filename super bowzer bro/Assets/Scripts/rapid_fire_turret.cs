using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapid_fire_turret : MonoBehaviour
{
    public float targetingrange = 2;
    public Transform target;
    public LayerMask enemymask;
    public SpriteRenderer sr;
    public Transform[] enemies;
    public float shoottimer = 0f;
    public float reloadtimer = 2f;
    public float ammo = 40f;
    public GameObject bullet;
    public Transform shotpos;
    public Animator anim;
    public float realshoottimer;
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
            anim.Play("idles");
            findtarget();
            return;
        }
        if (target != null && shoottimer <= 0f && ammo > 0f)
        {
            Instantiate(bullet, shotpos.position, transform.rotation);
            shoottimer = realshoottimer;
            ammo -= 1f;
        }
        else
        {
            shoottimer -= Time.deltaTime;
        }

        if(target != null && ammo > 0f)
        {
        anim.Play("shoot");
        }

        if (ammo == 0f)
        {
            anim.Play("idles");
            reloadtimer -= Time.deltaTime;
        }

        if (reloadtimer <= 0f)
        {
            ammo = 40f;
            reloadtimer = 2f;
        }

        rotatetowardstarget();
        if (!checkiftargetisinrange())
        {
            target = null;
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

    void reload()
    {
        if (ammo <= 0f)
        {
            reloadtimer -= Time.deltaTime;
        }
    }

    void findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)transform.position, 0f, enemymask);
        if (hits.Length > 0)
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
