using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public float startingEnemies = 3;
    public float enemyCounter;
    public GameObject warp;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter == startingEnemies)
        {
            warp.SetActive(true);
        }

    
    }
    public void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "enemy")
        {
            enemyCounter++;
        }
        if (collider.gameObject.tag == "Platform" || collider.gameObject.tag == "movingPlatform")
            Destroy(gameObject);
    }

}
