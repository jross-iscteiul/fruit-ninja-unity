using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public delegate void ObjectSpawnedHandler(CuttableObject obj);
    public event ObjectSpawnedHandler OnObjectSpawned;

    [Header("Target")]
    public GameObject prefab;
    [Header("Gameplay")]
    public float interval;
    public float minX;
    public float maxX;
    public float y;

    [Header("Visuals")]
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
        
    }

    private void Spawn(){
        //Instantiate and position obj
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            Random.Range(minX,maxX),
            y
        );
        instance.transform.SetParent(transform);
        if(OnObjectSpawned != null){
            OnObjectSpawned(instance.GetComponent<CuttableObject>());
        }
        //Select a sprite
        Sprite randomSprite = sprites[Random.Range(0,sprites.Length)];
        if(randomSprite.name.Equals("fruit01a"))
            instance.transform.localScale = new Vector3(1.30f,1.30f,1.30f);
        if(randomSprite.name.Equals("fruit26a"))
            instance.transform.localScale = new Vector3(1.8f,1.80f,1.80f);
        if(randomSprite.name.Equals("fruit14a") || randomSprite.name.Equals("fruit23a") || randomSprite.name.Equals("fruit13a") || randomSprite.name.Equals("fruit48a") || randomSprite.name.Equals("fruit09a"))
            instance.transform.localScale = new Vector2(2.4f,2.4f);
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
