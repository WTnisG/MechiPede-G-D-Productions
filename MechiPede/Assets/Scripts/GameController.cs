using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //This obejct is about the WorldState and level switches, never have more than one.

    public float masterSpeed;                   //Gives Speed to Pede
    public Scene checkScene;                    //Checks Scene

    [SerializeField] public int maxLevel = 10;    //Max amount of levels



    private void Awake()
    {
        //Controller stays available and is not killed
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        checkScene = SceneManager.GetActiveScene();
        Speedos();
    }

    //Changes Speed of the Pede in different Levels
    public void Speedos()
    {

        string scnName = checkScene.name;

        if (scnName == "Level1")
        {
            masterSpeed = 3f;
        }

        if (scnName == "Level2")
        {
            masterSpeed = 5f;
        }

        if (scnName == "Level3")
        {
            masterSpeed = 7f;
        }

        if (scnName == "Level4")
        {
            masterSpeed = 10f;
        }

        if (scnName == "Level5")
        {
            masterSpeed = 12f;
        }

        if (scnName == "Level6")
        {
            masterSpeed = 14f;
        }

        if (scnName == "Level7")
        {
            masterSpeed = 16f;
        }

        if (scnName == "Level8")
        {
            masterSpeed = 18f;
        }

        if (scnName == "Level9")
        {
            masterSpeed = 20f;
        }

        if (scnName == "Level10")
        {
            masterSpeed = 25f;
        }
    }
}
