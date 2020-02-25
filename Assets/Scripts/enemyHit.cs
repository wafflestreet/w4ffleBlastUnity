using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public Transform boomObj;

    //ForEnemyCounter
    public GameObject warp;
    public player countSystem;
    // Start is called before the first frame update
    void Start()
    {
        countSystem = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("bullet") || col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("bullet2"))
        {
            //countSystem.enemyCounter++;
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);

        }
    }
}
