using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EnemyShip"))
        {
            Debug.Log("Collision enemy");
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger Something");
    }
}
