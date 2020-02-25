using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class xBox2 : MonoBehaviour
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

    PlayerControls controls;
    public player controlSystem;
    public Vector2 move;
    public float moveSpeed = 6f;
    public bool held;
    public bool heldLeft;

    private void Start()
    {
        originalPos = wG.transform.position;
        //Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        cantHurt = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        rb = transform.GetComponent<Rigidbody2D>();
        controls.Gameplay.jump.performed += ctx => jump();
        bc = transform.GetComponent<BoxCollider2D>();
        // controls.Gameplay.move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.moveLeft.performed += ctx => movedL();
        controls.Gameplay.moveRight.performed += ctx => movedR();
        controls.Gameplay.moveRight.canceled += ctx => stopMove();
        controls.Gameplay.moveLeft.canceled += ctx => stopMove();
        controls.Gameplay.shoot.performed += ctx => shoot();
    }

    void shoot()
    {
        if (iShoot == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            touchShoot();
        }

        if (iShoot2 == true && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            touchShoot();
        }

        if (iShoot3 == true && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate;
            touchShoot();
        }
    }
    void movedL()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        Flip();
        facingRight = false;
        facingLeft = true;
        heldLeft = true;
    }
    void movedR()
    {
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        stayRight();
        facingRight = true;
        facingLeft = false;
        held = true;
    }
    public void Flip()
    {
        transform.localScale = new Vector2(-.5f, transform.localScale.y);
    }
    public void stayRight()
    {

        transform.localScale = new Vector2(.5f, transform.localScale.y);

    }
    public void stopMove()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        heldLeft = false;
        held = false;
    }
    void jump()
    {
        if (IsGrounded())
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
        }

    }

    void heldRight()
    {
        held = true;
    }
    void heldLeft1()
    {
        heldLeft = true;
    }
    void Update()
    {
        if (held == true)
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }
        if (heldLeft == true)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            // Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
            //transform.Translate(m, Space.World);
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformLm);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
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
    public void reSpawning()
    {
        wG.transform.position = originalPos;
    }
    public void touchShoot()

    {


        bulletPos = transform.position;
        if (facingRight)
        {

            if (iShoot == true || iShoot2 == true)
            {
                bulletPos += new Vector2(.5f, -.3f);
                Instantiate(bulletToRight, bulletPos, Quaternion.identity);
                Instantiate(smallMuzzleFlash, bulletPos, smallMuzzleFlash.rotation);
            }

            if (iShoot3 == true)
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

