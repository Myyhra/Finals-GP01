using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]GameManager manager;
    
    void OnTriggerEnter(Collider other)
    {
        manager.coinCount++;
        Destroy(gameObject);
    }
}
