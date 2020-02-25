using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;



public class RewiredMovement : MonoBehaviour
{
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;


    public int lifeCounter;
    Vector2 i_movement;
    public BoxCollider2D bc;
    public LayerMask platformLm;
    public lifeManager lifeSystem;
   Vector3 originalPos1;
  
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
    public float nextFire = 0f;
    public float fireRate2 = .3f;
    public float nextFire2 = 0f;
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

    public Vector2 move;
    public float moveSpeed = 10f;
    public bool held;
    public bool heldLeft;
    public Transform WG;
    public GameObject myAvatar;
    public GameObject wB;


    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        originalPos1 = wB.transform.position;
    }

    void Awake()
    {


        lifeSystem = FindObjectOfType<lifeManager>();
        rb = transform.GetComponent<Rigidbody2D>();

        bc = transform.GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (player.GetButton("jump") && IsGrounded())
        {
            float jumpVelocity = 6.5f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        if (player.GetButton("shoot"))
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
        if (transform.position.y < threshold)
        {
            lifeSystem.TakeLife();
            wB.transform.position = originalPos1;
            Instantiate(reSpawn, originalPos1, reSpawn.rotation);
        }


    }
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformLm);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    public void Flip()
    {
        transform.localScale = new Vector2(-.5f, transform.localScale.y);
    }
    public void FlipR()
    {
        transform.localScale = new Vector2(.5f, transform.localScale.y);
    }
    private void Move()
    {
        float moveHorizontal = player.GetAxis("move");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (moveHorizontal > 0)
        {
            FlipR();
            facingRight = true;
            facingLeft = false;
        }
        if (moveHorizontal < 0)
        {
            Flip();
            facingRight = false;
            facingLeft = true;
        }
        }
    public void reSpawning()
    {
        wB.transform.position = originalPos1;
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
               
                this.gameObject.GetComponent<SpriteRenderer>().sprite = gun;
                Instantiate(reSpawn, originalPos1, reSpawn.rotation);
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
          
            Destroy(col.gameObject);
        }



    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("movingPlatform"))
            this.transform.parent = null;
    }
}
