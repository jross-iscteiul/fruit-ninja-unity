using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{   [Header("Speed Variables")]
    public float minXspeed, maxXspeed, minYspeed, maxYspeed;
    [Header("Game Variables")]
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        //Throw move obj upwards
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (
            Random.Range(minXspeed,maxXspeed),
            Random.Range(minYspeed,maxYspeed)
        );
        Destroy(gameObject, lifetime);
    }

   
}
