using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lifeManager : MonoBehaviour
{
    //public int startingLives;
    public int lifeCounter;



    public Text theText;
    public GameObject GameOverScreen;
    public GameObject GameOverProtect;

    public string mainMenu;
    public float waitAfterGameOver = 4;
    public float gameOver;
    public GameObject waffle;
    public GameObject movingGameOver;
    public GameObject WaffleBoyWin;



    // Start is called before the first frame update
    void Start()
    {

        
        theText = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");


    }

    // Update is called once per frame
    void Update()
    {


        theText.text = "x " + lifeCounter;
        {
            if (lifeCounter <= 0)

            //GameOverScreen.SetActive(true);

            WaffleBoyWin.SetActive(true);
            // ScoreManager.Instance.CheckForNewHighScore();


        }
        if (WaffleBoyWin.activeSelf == true)
        {
            
           waitAfterGameOver -= Time.deltaTime;
            
        }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 1)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 2)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 3)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 4)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 5)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 6)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6); }
        if (waitAfterGameOver < 0 && SceneManager.GetActiveScene().buildIndex == 7)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7); }



    }
    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);

    }
    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void AddScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

