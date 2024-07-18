using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SimpleMove player;
    [SerializeField] Transform playerLocation;
    public int OrbCount;
    public int coinCount;
    GameObject[] normalOrbs;
    GameObject[] specialOrbs;
    GameObject[] specialChildOrbs;
    public bool win = false;
    public bool dead = false;
    [SerializeField] GameObject emerald;
    [SerializeField] int emeraldDistance;

    void Awake()
    {
        Application.targetFrameRate = 60;
        normalOrbs = GameObject.FindGameObjectsWithTag("Orbs");
        specialOrbs = GameObject.FindGameObjectsWithTag("SpecialOrbs");
        specialChildOrbs = GameObject.FindGameObjectsWithTag("SpecialChildOrbs");
    }
    void Start()
    {
        OrbCount = normalOrbs.Length + specialOrbs.Length + specialChildOrbs.Length;
    }

    bool emeraldSpawn = false;
    void Update()
    {
        if(OrbCount <= 0)
        {
            win = true;
        }
        if(win && !emeraldSpawn )
        {
            Win();
        }
        if(dead)
        {
            player.speed = 0;
        }
        
    }

    void Win()
    { 
        Vector3 spawnPos = playerLocation.position + playerLocation.forward * 6 + playerLocation.up;
        Quaternion spawnRotation = playerLocation.rotation;
        player.speed = 2;
        Instantiate(emerald, spawnPos,spawnRotation);
        emeraldSpawn = true;
        foreach(GameObject orbs in normalOrbs)
        {
            orbs.SetActive(false);
        }
        foreach(GameObject orbs in specialOrbs)
        {
            orbs.SetActive(false);
        }
        foreach(GameObject orbs in specialChildOrbs)
        {
            orbs.SetActive(false);
        }
    }
   
}
