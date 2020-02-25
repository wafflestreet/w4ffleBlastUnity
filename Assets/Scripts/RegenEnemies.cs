using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenEnemies : MonoBehaviour

{
    //randomizes spawned GameObject
    public int whichpowerup;
    public Transform enemy6;
    public int whichcolor;
    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;
    public Transform enemy4;
    public Transform enemy5;
    public bool canDrop;
    public float time = 10f;
    public float remainingTime = 10f;
    public bool timerIsRunning = true;
    public bool timerIsUp = false;



    //Timer that spawns GameObject

    int i; //i = 0






    void Start()
    {
        //StartCoroutine(waitForIt());
        //waitForIt();

        timerIsRunning = true;
    }

    // IEnumerator waitForIt()
    // {
    //yield return new WaitForSeconds(6);
    // }
    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (timerIsUp == true)
        {


            // waitForIt();

            //SpawnExtra();
            randomPower();
            remainingTime = time;


        }
        if (timerIsRunning == true)
        { timerIsUp = false; }



        if (remainingTime <= 0)
        {
            timerIsUp = true;

        }

        if (remainingTime == time)
        {
            timerIsRunning = true;
        }




        // void SpawnExtra()

        //{
        // GameObject extraLifeClone;

        //extraLifeClone = Instantiate(extraLife, this.transform.position, this.transform.rotation) as GameObject;


        // }

        void randomPower()
        {




            whichpowerup = Random.Range(0, 7);
            //scoreSystem.UpdateScore(10);
            if (whichpowerup == 1)
            {

                Instantiate(enemy1, transform.position, enemy1.rotation);
            }
            if (whichpowerup == 2)
            {

                Instantiate(enemy2, transform.position, enemy2.rotation);
            }

            if (whichpowerup == 3)
            {

                Instantiate(enemy3, transform.position, enemy3.rotation);
            }
            if (whichpowerup == 4)
            {

                Instantiate(enemy4, transform.position, enemy4.rotation);
            }

            if (whichpowerup == 5)
            {

                Instantiate(enemy5, transform.position, enemy5.rotation);
            }
            if (whichpowerup == 6)
            {
                Instantiate(enemy6, transform.position, enemy6.rotation);

            }




        }



    }
}






