using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CuttableObject : MonoBehaviour
{
    public delegate void ObjectDestroyedHandler(bool harmful);
    public event ObjectDestroyedHandler OnDestroyed;
    public bool harmful;
   void OnCollisionEnter2D( Collision2D collision) {
       if(collision.gameObject.tag == "Cut"){
           if(OnDestroyed !=null){
               OnDestroyed(harmful);
           }
           Destroy(gameObject);

          
       }
   }
}
