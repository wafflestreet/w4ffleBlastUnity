using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour

{
    //randomizes spawned GameObject
    public int whichpowerup;
    public Transform extraLife;
    public int whichcolor;
    public Transform gun2;
    public Transform gun3;
    public Transform gun4;
    public Transform bubble;
    public Transform addEnemy2;
    public bool canDrop;
    public float time = 5f;
    public float remainingTime = 5f;
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

        if (timerIsUp == true )
        {
           
            
           // waitForIt();
            
            //SpawnExtra();
            randomPower();
            remainingTime = time;
          

        }
        if(timerIsRunning == true)
        { timerIsUp = false; }

    

        if(remainingTime <= 0)
        {
            timerIsUp = true;
        
        }
        
        if(remainingTime == time)
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

                    Instantiate(extraLife, transform.position, extraLife.rotation);
                }
                if (whichpowerup == 2)
                {

                    Instantiate(gun2, transform.position, gun2.rotation);
                }

                if (whichpowerup == 3)
                {

                    Instantiate(gun3, transform.position, gun3.rotation);
                }
                if (whichpowerup == 4)
                {

                    Instantiate(bubble, transform.position, bubble.rotation);
                }

                if (whichpowerup == 5)
                {

                    Instantiate(addEnemy2, transform.position, addEnemy2.rotation);
                }
                if (whichpowerup == 6)
                {
                    Instantiate(gun4, transform.position, gun4.rotation);

                }



            
        }
        


    }
    }





