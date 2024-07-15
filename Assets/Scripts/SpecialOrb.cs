using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrb : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    Transform[] specialOrbTransform;
    [SerializeField]SpecialOrbCount[] specialOrbCount;
    public int SpecialOrbsCountdown;

    Transform[] specialChildOrbTransform;
    SpecialChildOrbs[] specialChildOrbs;

    public GameObject coin;
    public bool turntoCoin = false;
    bool orbtoCoin = false;
    //Render
    Renderer sphereRenderer;
    [SerializeField] Color turnRed;
    bool isRed = false;
    [SerializeField] float turnRedDelay = 1.0f;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();

        specialOrbCount = GetComponentsInChildren<SpecialOrbCount>();
        specialOrbTransform = GetComponentsInChildren<Transform>();

        specialChildOrbs = GetComponentsInChildren<SpecialChildOrbs>();
        specialChildOrbTransform = GetComponentsInChildren<Transform>();
        
        SpecialOrbsCountdown = specialOrbCount.Length;
    }

    void Update()
    {
        if(SpecialOrbsCountdown <=0 && orbtoCoin == false)
        {
            TurntoCoin();

            Debug.Log("TURN TO COINS");
        }
    }
    void TurntoCoin()
    {
         foreach(Transform orbs in specialOrbTransform)
         {
            foreach(Transform childOrbs in specialChildOrbTransform)
            {
                Instantiate(coin, orbs);
                Instantiate(coin,childOrbs);
            }
         }
         orbtoCoin = true;
    }

    
    void OnTriggerEnter(Collider collider)
    {
        // specialOrbCount--;
        gameManager.OrbCount--;
        StartCoroutine("TurnRedDelay");
        if(isRed)
        {
            gameManager.dead = true;
        }
        Debug.Log("Collision");
    }

    IEnumerator TurnRedDelay()
    {
        sphereRenderer.material.color = turnRed;
        yield return new WaitForSeconds(turnRedDelay);
        isRed = true;
    }

}
