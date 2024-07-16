using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialChildOrbs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    SpecialOrb mainOrb;



    //Render
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    bool isRed = false;
    [SerializeField] float turnRedDelay = 1.0f;
    [SerializeField] GameObject Coin;
    MeshRenderer meshRenderer;
    SphereCollider collider;
    // public bool turntoCoin = false;
    public bool taken = false;
    public bool destroy = false;
   void Awake()
    {
        sphereRenderer = GetComponent<Renderer>();
        mainOrb = GetComponentInParent<SpecialOrb>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        if (destroy)
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            taken = true;
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
