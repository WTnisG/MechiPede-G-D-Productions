using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    // Grid
    public int numGrid = 30;        // Grid dimension
    public GameObject cam;      //Main cam

    // Mushroom generation
    public int maxMushroom = 30;                // Max number of mushrooms
    public GameObject tShroom;            // Mushroom prefab to spawn

    public int length = 15;            // Number of the centipede length
    public GameObject MechiPede;          // Centipede prefab

    // Start is called before the first frame update
    void Start()
    {
        // Change the position of the camera and background by the grid dimension
        float newPos = numGrid / 2f - 0.5f;
        Vector2 verticalOffset = new Vector2(newPos + 1, 0);
        Vector2 verticalSize = new Vector2(1, numGrid + 2);
        Vector2 horizontalOffset = new Vector2(0, newPos + 1);
        Vector2 horizontalSize = new Vector2(numGrid + 2, 1);

        CameraSettings(newPos);
        MushroomGen();
        CentipedeGen();
    }

    // Translate the camera according to the dimension of grid
    void CameraSettings(float newPos)
    {
        transform.position = new Vector3(newPos, newPos, 1);
        cam.transform.position = new Vector3(newPos, newPos, -10);
        // Resize the background by the grid dimension
        transform.localScale = new Vector3(numGrid / 10f, numGrid / 10f, numGrid / 10f);
        // Resize the camera by the grid dimension with padding 1 unit each size
        Camera camComponent = cam.GetComponent<Camera>();
        camComponent.orthographicSize = numGrid / 2f;
    }

    // Generate the mushrooms in random positions
    void MushroomGen()
    {
        int count = 0;
        while (count < maxMushroom)
        {
            int x = Random.Range(0, numGrid - 1);
            // Leave 2 bottom rows for space to shoot
            int y = Random.Range(2, numGrid -1);
            Instantiate(tShroom, new Vector3(x, y, 0), Quaternion.identity);
            count++;
        }
    }

    // Generate the centipede on grid
    void CentipedeGen()
    {
        for (int i = 0; i < length; i++)
        {
            Vector3 nextPos = new Vector3(i, numGrid - 1, 0);
            GameObject nextCent = Instantiate(MechiPede, nextPos, Quaternion.identity);
            nextCent.GetComponent<PedeMoves>().order = i;
            nextCent.name = "MechiPede" + i;
        }
    }
}
