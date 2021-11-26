using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public string lName;

    //starts the game and go back to the menu
    public void onClick1()
    {
        SceneManager.LoadScene(lName);
    }

    //ends the game
    public void Exit()
    {
        Application.Quit();
    }
}
