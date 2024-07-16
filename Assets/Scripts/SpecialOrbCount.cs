using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrbCount : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    SpecialOrb mainOrb;
    public GameObject coin;
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    bool isRed = false;
    [SerializeField] float turnRedDelay = 1.0f;
    MeshRenderer meshRenderer;
    SphereCollider collider;
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
            mainOrb.SpecialOrbsCountdown--;
            gameManager.OrbCount--;
            StartCoroutine("TurnRedDelay");
            if(isRed)
            {
               gameManager.dead = true;
            }
            Debug.Log("Collision");
            }
    }
    IEnumerator TurnRedDelay()
    {
        sphereRenderer.material.color = turnRed;
        yield return new WaitForSeconds(turnRedDelay);
        isRed = true;
    }

}
