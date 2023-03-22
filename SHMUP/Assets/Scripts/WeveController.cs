using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeveController : MonoBehaviour
{

    public static WeveController instance;


    uint numEnemies = 0;

    bool startNewWave = false;
    float nextWaveTimer = 3;
    string[] weves = { "Menu", "Option", "Weve1", "Weve2", "Weve3", "Weve4", "GameOver" };
    public int currentWave;





    int score = 0;
    TMP_Text scoreText;

    TMP_Text congratulation;
    TMP_Text scoreTextEndGame;
    TMP_Text scoreTextName;
    Button exit;
    int health = 3;
    Slider HealthBar;



    private void Awake()
    {

        if (instance == null)
        {
            if (currentWave == 6)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                congratulation = GameObject.Find("Congrat").GetComponent<TMP_Text>();
                scoreTextName = GameObject.Find("Score").GetComponent<TMP_Text>();
                scoreTextEndGame = GameObject.Find("PointsEndGame").GetComponent<TMP_Text>();
                exit = GameObject.Find("Exit").GetComponent<Button>();
            }
            else 
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                scoreText = GameObject.Find("Points").GetComponent<TMP_Text>();
                HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
            }
            

        }
        else
        {
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startNewWave)
        {
            if (nextWaveTimer <= 0)
            {
                currentWave++;
                if (currentWave <= weves.Length)
                {
                    string sceneName = weves[currentWave];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    SceneManager.LoadSceneAsync("GameOver");
                    Debug.Log("Game Over");
                }
                nextWaveTimer = 3;
                startNewWave = false;
            }
            else
            {
                nextWaveTimer -= Time.deltaTime;
            }
        }
    }
    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        scoreText.SetText(score.ToString());
       // scoreTextEndGame.SetText(score.ToString());

    }

    public void AddEnemy()
    {
        numEnemies++;
    }

    public void MinusHealth()
    {
        HealthBar.value--;
    }

    public void PlusHealth()
    {
        if (health <= 3)
        {
            HealthBar.value++;
        }
    }

    public void RemoveEnemy()
    {
        numEnemies--;

        if (numEnemies == 0)
        {
            startNewWave = true;
        }

    }

}
