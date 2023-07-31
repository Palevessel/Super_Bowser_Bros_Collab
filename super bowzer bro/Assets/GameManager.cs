using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject tower;
    public grid[] tiles;
    public float money = 200f;
    public TMP_Text Money;
    public TMP_Text Wave;
    public Transform[] spawnpoints;
    public Transform[] warningpoints;
    public bool waveactive;
    public float enemiestospawn;
    public float enemyspawntimer;
    public float realenemyspawntimer;
    public GameObject[] enemies;
    public int enemytospawn;
    public int selectedspawnlocation;
    public GameObject[] enemys;
    public float wave;
    public Transform warner;
    public GameObject goombawithpistol;
    public GameObject goombawithsniper;
    public GameObject koopashelllauncher;
    public GameObject automaticturret;
    public SpriteRenderer cursorsr;
    public Sprite goomba;
    public Sprite koopa;
    public Sprite auto;
    public Sprite square;
    public GameObject shop;
    public float health = 10f;
    public Slider healthbar;
    public GameObject losescreen;
    public float koopalauncherprice = 250f;
    // Start is called before the first frame update
    void Start()
    {
        selectedspawnlocation = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        Wave.text = "Start Wave: " + wave.ToString("0");
        if(health <= 0f)
        {
            losescreen.SetActive(true);
        }
        healthbar.value = health;
        warner.position = warningpoints[selectedspawnlocation].position;
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        enemytospawn = Random.Range(0, 3);
        Money.text = "= $" + money.ToString("0");
        if(Input.GetMouseButtonDown(0) && tower != null)
        {
            grid nearesttile = null;
            float nearestDistance = float.MaxValue;
            foreach(grid tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(dist < nearestDistance)
                {
                    nearestDistance= dist;
                    nearesttile = tile;
                }
            }
            if(nearesttile.isoccupied == false)
            {
                Instantiate(tower, nearesttile.transform.position, Quaternion.identity);
                tower = null;
                nearesttile.isoccupied = true;
                cursorsr.sprite = square;
            }
        }

        if(enemyspawntimer <= 0f && waveactive && enemiestospawn > 0f)
        {
            Instantiate(enemies[enemytospawn], spawnpoints[selectedspawnlocation].position, Quaternion.identity);
            enemyspawntimer = realenemyspawntimer;
            enemiestospawn -= 1f;
        }
        
        if(enemyspawntimer > 0f)
        {
            enemyspawntimer -= Time.deltaTime;
        }
        if (enemys.Length <= 0 && enemiestospawn <= 0f && waveactive == true && realenemyspawntimer >= 0.2f)
        {
            realenemyspawntimer -= 0.2f;
        }
        if (enemys.Length <= 0 && enemiestospawn <= 0f && waveactive == true)
        {
            money += 100f;
            selectedspawnlocation = Random.Range(0, 6);
            wave += 1f;
            enemiestospawn = wave * 4;
            waveactive = false;
        }

    }

    public void startwave()
    {
        waveactive = true;
    }

    public void Snipergoomba()
    {
        if(money >= 400)
        {
            money -= 400;
            tower = goombawithsniper;
            cursorsr.sprite = goomba;
            closeshop();
        }
    }
    
    public void Pistolgoomba()
    {
        if (money >= 300)
        {
            money -= 300;
            tower = goombawithpistol;
            cursorsr.sprite = goomba;
            closeshop();
        }
    }
    
    public void Koopalauncher()
    {
        if (money >= 1000)
        {
            money -= 1000;
            tower = koopashelllauncher;
            cursorsr.sprite = koopa;
            closeshop();
        }
    } 
    
    public void Autoturret()
    {
        if (money >= 100)
        {
            money -= 100;
            tower = automaticturret;
            cursorsr.sprite = auto;
            closeshop();
        }
    }

    public void closeshop()
    {
        shop.SetActive(false);
    }
}
