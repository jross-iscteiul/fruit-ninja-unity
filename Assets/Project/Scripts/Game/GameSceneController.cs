using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSceneController : MonoBehaviour
{
    public int numberOfLives;
    public ObjectSpawner fruitSpawner;
    public ObjectSpawner bombSpawner;

    [Header("Interface")]
    public Text scoreText;
    public LifeCounter lifeCounter;
    public GameObject gameOverGroup;

    private int score=0;
        public int Score{
        get {return score;}
        set {
            score = value;
            scoreText.text = " Score: "+score;
        }
    }
    void Start()
    {
        gameOverGroup.SetActive(false);
        lifeCounter.SetLives(numberOfLives);
        fruitSpawner.OnObjectSpawned += OnObjectSpawned;
        bombSpawner.OnObjectSpawned += OnObjectSpawned;

        Score =0;
    }

    // Update is called once per frame
    void Update()
    {if(numberOfLives <=0 && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Title");
        }
        
    }
    private void OnObjectSpawned (CuttableObject obj){
        obj.OnDestroyed += OnObjectDestroyed;

    }

    
    private void OnObjectDestroyed (bool harmful){
        if(!harmful)
        Score+=10;
        else LoseLife();
    }
    public void LoseLife(){

        numberOfLives--;
        lifeCounter.LoseLife();
        if(numberOfLives<=0){
            scoreText.gameObject.SetActive(false);
            gameOverGroup.SetActive(true);

            Text gameOverText = gameOverGroup.GetComponentsInChildren<Text>()[0];
            gameOverText.text = string.Format(gameOverText.text, score );
        }
    }
}
