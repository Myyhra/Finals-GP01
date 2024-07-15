using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orb : MonoBehaviour
{
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    [SerializeField] GameManager gameManager;
    [SerializeField] float turnRedDelay = 1.0f;
    bool isRed = false;
    void Start ()
    {
        sphereRenderer = GetComponent<Renderer>();
    }
    
    void OnTriggerEnter(Collider collided)
    {
        if (collided.CompareTag("Player"))
        {
            gameManager.OrbCount--;
            sphereRenderer.material.color = turnRed;
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
