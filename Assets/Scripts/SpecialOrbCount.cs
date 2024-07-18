using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrbCount : MonoBehaviour
{
    [SerializeField] SimpleMove player;
    [SerializeField] GameManager gameManager;
    SpecialOrb mainOrb;
    public GameObject coin;
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    public bool isRed = false;
    [SerializeField] float turnRedDelay = 1.0f;
    MeshRenderer meshRenderer;
    SphereCollider collider;
    public bool destroy = false;

    AudioSource audioSource;
    public AudioClip orbsound;
    void Awake()
    {
        sphereRenderer = GetComponent<Renderer>();
        mainOrb = GetComponentInParent<SpecialOrb>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(orbsound);
            
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
