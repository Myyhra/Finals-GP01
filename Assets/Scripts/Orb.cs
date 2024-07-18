using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orb : MonoBehaviour
{
    [SerializeField] SimpleMove player;

    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    [SerializeField] GameManager gameManager;
    [SerializeField] float turnRedDelay = 1.0f;
    AudioSource audioSource;
    public AudioClip orbsound;
    public bool isRed = false;
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        sphereRenderer = GetComponent<Renderer>();
    }
    
    void Update()
    {
        if(isRed)
        {
        sphereRenderer.material.color = turnRed;
        }
    }
    void OnTriggerEnter(Collider collided)
    {
        if (collided.CompareTag("Player"))
        {
            player.speedRatio += 0.01;
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
        yield return new WaitForSeconds(turnRedDelay);
        isRed = true;
    }
}
