using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int OrbCount;
    public int coinCount;
    GameObject[] normalOrbs;
    GameObject[] specialOrbs;
    GameObject[] specialChildOrbs;
    [SerializeField] bool win = false;
    public bool dead = false;

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

    // Update is called once per frame
    void Update()
    {
        if(OrbCount <= 0)
        {
            // OrbCount = 0;
            win = true;
        }
    }
}
