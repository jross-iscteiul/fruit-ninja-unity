using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LifeCounter : MonoBehaviour
{
    [Header("Gameplay")]
   
    [Header("Visuals")]
    
    public GameObject prefab;
  

    private List<GameObject> lives;
    // Start is called before the first frame update
    public void SetLives(int amount)
    {  
        lives = new List<GameObject>();
        for(int i=0; i < amount; i++) {
            GameObject lifeInstance = Instantiate (prefab, transform);
            lives.Add (lifeInstance);
        }
        
    }
    public void LoseLife() {
    
        GameObject lastLife = lives[lives.Count -1];
        lives.Remove (lastLife);

        Destroy(lastLife);

     
    }

    // Update is called once per frame
    
}
