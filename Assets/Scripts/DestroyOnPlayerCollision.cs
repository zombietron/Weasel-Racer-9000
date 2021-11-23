using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerCollision : MonoBehaviour
{
    Enemy enem;
    bool collidedWithPlayer = false;
    private void Awake()
    {
        enem = GetComponent<Enemy>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I collided with player I am a: " + collision);
            
            if (!collidedWithPlayer)
            {
                collidedWithPlayer = true;
                enem.IDied();
                Destroy(gameObject);
            }
        }

    }
}
