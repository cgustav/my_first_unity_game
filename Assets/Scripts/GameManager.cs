using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool isDead = false; // Useful to use with obstacle collision, the game is over
    public float speed = 2; // Movement speed reference

    public GameObject mainMenu;
    public GameObject gameOverMenu;

    public GameObject columnPrefab; // Column that composes the stage ground
    public GameObject rock1Prefab; // Rock 1 obstacle prefab
    public GameObject rock2Prefab; // Rock 2 obstacle prefab

    public Renderer background; // Background renderer, it repeats forever

    public List<GameObject> columns = new List<GameObject>(); // Holds all the stage ground columns
    public List<GameObject> obstacles = new List<GameObject>(); // Holds all the stage obstacles

    // Start is called before the first frame update
    void Start()
    {
        // Create map
        for (int i = 0; i < 21; i++)
        {
            columns.Add(Instantiate(columnPrefab, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // Create rock obstacles - Automization
        // for (int i = 0; i < 10; i++)
        // {
        //     int random = Random.Range(0, 2);
        //     if (random == 0)
        //     {
        //         Instantiate(rock1Prefab, new Vector2(-10 + i, -2), Quaternion.identity);
        //     }
        //     else
        //     {
        //         Instantiate(rock2Prefab, new Vector2(-10 + i, -2), Quaternion.identity);
        //     }
        // }

        // Create rock obstacles - Manual Mode
        obstacles.Add(Instantiate(rock1Prefab, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(rock2Prefab, new Vector2(18, -2), Quaternion.identity));



    }

    // Update is called once per frame
    void Update()
    {

        if(gameStarted == false){
            if(Input.GetKeyDown(KeyCode.X)){
                gameStarted = true;
            }
        }

        if(gameStarted == true && isDead == true){
            gameOverMenu.SetActive(true);
            if(Input.GetKeyDown(KeyCode.X)){
                // Restart the game
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }


        if(gameStarted == true && isDead == false)
        {
            mainMenu.SetActive(false);
            background.material.mainTextureOffset += new Vector2(0.02f, 0) * Time.deltaTime;

            //Move map
            for (int i = 0; i < columns.Count; i++)
            {
                if(columns[i].transform.position.x <= -10)
                {
                    columns[i].transform.position = new Vector3(10, -3, 0);
                }

                columns[i].transform.position += new Vector3(-1,0,0) * Time.deltaTime * speed;
            }

            //Move obstacles
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.x <= -10)
                {
                    // obstacles[i].transform.position = new Vector3(10, -2, 0);
                    obstacles[i].transform.position = new Vector3(Random.Range(11, 18), -2, 0);
                }

                obstacles[i].transform.position += new Vector3(-1,0,0) * Time.deltaTime * speed;
            }
        }
    }
}
