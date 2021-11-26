using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class highscoreSafer : MonoBehaviour
{
    /*
    public PlayerMoves pL;        //player script gets fetched
    public int scoreSafe;        //score is gicen into this script
    public Text highscoreData;  //shows the highscore after GameOver
    public Scene scene;

    //gets called when game starts
    private void Start()
    {
        pL = GameObject.Find("Player").GetComponent<PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(transform.gameObject);
        GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");
        scoreSafe = pL.score;

        if (pL.pLive < 0 || (MechiPede.Length < 0 && scene.name == "Level15"))
        {
            highscoreData.text = scoreSafe.ToString();
        }
    }
    */
}
