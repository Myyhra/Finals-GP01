using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialChildOrbs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    SphereCollider collider;
    SpecialOrb mainOrb;



    //Render
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    bool isRed = false;
    [SerializeField] float turnRedDelay = 1.0f;
    [SerializeField] GameObject Coin;
    // public bool turntoCoin = false;
   void Awake()
    {
        sphereRenderer = GetComponent<Renderer>();
        mainOrb = GetComponentInParent<SpecialOrb>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            gameManager.OrbCount--;
            StartCoroutine("TurnRedDelay");
            if(isRed)
            {
               gameManager.dead = true;
            }
            Debug.Log("Collision");
            }
    }
    public void spawnCoin()
    {
        Instantiate(Coin,gameObject.transform);
    }
    IEnumerator TurnRedDelay()
    {
        sphereRenderer.material.color = turnRed;
        yield return new WaitForSeconds(turnRedDelay);
        isRed = true;
    }

}
