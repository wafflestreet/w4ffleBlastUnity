﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    
    public int lifeCounter;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public LayerMask platformLm;
    public lifeManager lifeSystem;
    public Vector3 originalPos;
    public GameObject wG;
    public float threshold;
    public GameObject blaster;
    public bool hasGun;
    public Sprite idle;
    public Sprite gun;
    public Sprite gun2;
    public bool facingRight;
    public bool facingLeft;
    public GameObject bullet;
    public bool iShoot;
    public Transform blastPoint;
    public Transform boomObj;
    public float thrust;
    public GameObject origin;
    //Shooting
    public GameObject bulletToRight;
    public GameObject bulletToLeft;
    public GameObject bigBulletToLeft;
    public GameObject bigBulletToRight;
    Vector2 bulletPos;
    public bool iShoot2;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    public float fireRate2 = .3f;
    float nextFire2 = 0f;
    //CountSystem
    public float startingEnemies = 3;
    public float enemyCounter;
    public GameObject warp;
    public bool iShoot3;
    public Sprite gun3;
    public Transform smallMuzzleFlash;
    public Transform bigMuzzleFlash;
    public GameObject bubble;
    public bool cantHurt;
  
    public Transform reSpawn;
    public GameObject rain;
    public GameObject fireFly;







    private void Start()
    {
        originalPos = wG.transform.position;
        //Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        cantHurt = true;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        lifeSystem = FindObjectOfType<lifeManager>();
    }
    public void onEnable()
    {
       
    }

    public void onDisable()
    {
   
    }

    // Update is called once per frame
    public void Update()
    {
        //JUMPING
        bgControl();
        jump();
        HandleMovement();
        //FallingDeath
        if (transform.position.y < threshold)
        {
            lifeSystem.TakeLife();
            wG.transform.position = originalPos;
            Instantiate(reSpawn, originalPos, reSpawn.rotation);
        }
        //Shooting
        if (iShoot == true && Input.GetKey(KeyCode.S) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            touchShoot();
        }

        if (iShoot2 == true && Input.GetKey(KeyCode.S) && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            touchShoot();
        }

        if (iShoot3 == true && Input.GetKey(KeyCode.S) && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate;
            touchShoot();
        }
        //CountSystem
        if (enemyCounter == startingEnemies)
        {
            warp.SetActive(true);
        }


    }
    public void jump()
    {
        if (IsGrounded() )
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformLm);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    public void HandleMovement()
    {
        float moveSpeed = 6f;
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            Flip();
            facingRight = false;
            facingLeft = true;

        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
                stayRight();
                facingRight = true;
                facingLeft = false;

            }
            else
            {
                //NO KEYS PRESSED
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("movingPlatform"))
        {
            this.transform.parent = col.transform;
        }

        if (col.gameObject.tag.Equals("nextLevel"))
        {
            lifeSystem.AddScene();
        }

        if (col.gameObject.tag == "blaster")
        {
            iShoot = true;
            iShoot2 = false;
            iShoot3 = false;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun;

        }
        if (col.gameObject.tag == "blaster2")
        {
            iShoot = false;
            iShoot2 = true;
            iShoot3 = false;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun2;

        }
        if (col.gameObject.tag == "blaster3")
        {
            iShoot = false;
            iShoot2 = false;
            iShoot3 = true;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun3;

        }
        if (col.gameObject.tag == "bubble")
        {
            cantHurt = true;
            Destroy(col.gameObject);

        }

        if (cantHurt == true)
        {
            bubble.SetActive(true);
        }




        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "bullet2")
        {
            if (cantHurt == false)
            {
                Destroy(col.gameObject);
                //If you want to count enemies its back on the enemy hit
                iShoot = true;
                iShoot2 = false;
                iShoot3 = false;
                Instantiate(boomObj, transform.position, boomObj.rotation);
                lifeSystem.TakeLife();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = gun;
                Instantiate(reSpawn, originalPos, reSpawn.rotation);
                reSpawning();
            }

            if (cantHurt == true)
            {
                Destroy(col.gameObject);
                bubble.SetActive(false);
                cantHurt = false;
            }

        }

        //if (cantHurt == true && col.gameObject.tag == "enemy" || col.gameObject.tag == "bullet2"  )
        //{
        //Destroy(col.gameObject);
        // bubble.SetActive(false);
        //cantHurt = false;



        //}
        if (col.gameObject.tag == "extraLife")
        {
            lifeSystem.GiveLife();
            Destroy(col.gameObject);
        }



    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("movingPlatform"))
            this.transform.parent = null;
    }
    public void Flip()
    {
        transform.localScale = new Vector2(-.5f, transform.localScale.y);
    }

    public void stayRight()
    {

        transform.localScale = new Vector2(.5f, transform.localScale.y);

    }
    public void reSpawning()
    {
        wG.transform.position = originalPos;
    }
    public void bgControl()
    {
    
            if (Input.GetKey(KeyCode.R))
        {
            rain.SetActive(true);
            fireFly.SetActive(false);
        }

        if (Input.GetKey(KeyCode.F))
        {
            rain.SetActive(false);
            fireFly.SetActive(true);
        }


    }

    public void touchShoot()

    {


        bulletPos = transform.position;
        if(facingRight)
        {
           
            if (iShoot == true || iShoot2 == true)
            {
                bulletPos += new Vector2(.5f, -.3f);
                Instantiate(bulletToRight, bulletPos, Quaternion.identity);
                Instantiate(smallMuzzleFlash, bulletPos, smallMuzzleFlash.rotation);
            }

            if(iShoot3 == true)
            {
                bulletPos += new Vector2(.5f, -.3f);
                Instantiate(bigMuzzleFlash, bulletPos, bigMuzzleFlash.rotation);
                Instantiate(bigBulletToRight, bulletPos, Quaternion.identity);
            }   
        }
        else
        {
            
            if (iShoot == true || iShoot2 == true)
            {
                bulletPos += new Vector2(-.5f, -.3f);
                Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
                Instantiate(smallMuzzleFlash, bulletPos, smallMuzzleFlash.rotation);
            }
            if (iShoot3 == true)
            {
                bulletPos += new Vector2(-.5f, -.3f);
                Instantiate(bigMuzzleFlash, bulletPos, bigMuzzleFlash.rotation);
                Instantiate(bigBulletToLeft, bulletPos, Quaternion.identity);
            }
        }



    }
    

   



}
