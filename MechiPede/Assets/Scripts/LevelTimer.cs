using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelTimer : MonoBehaviour
{
    public float gameLength = 150f;   //timer to switch level
    [SerializeField]
    private string levelName;
    private Text levelTxt;

    private void Start()
    {
        levelTxt = GameObject.Find("levelTxt").GetComponent<Text>();  //Find the Gameobject
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameLength -= Time.fixedDeltaTime;

        levelTxt.text = ((int)gameLength).ToString();
        GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");

        if (MechiPede.Length <= 0 || gameLength <= 0)  //switches Level
        {
            SceneManager.LoadScene(levelName);
        }

    }
}
