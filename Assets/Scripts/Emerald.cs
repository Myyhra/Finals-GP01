using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    [SerializeField] SimpleMove player;
    public AudioSource audioSource;
    public AudioClip clip;
   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    {
        audioSource.PlayOneShot(clip);
        gameUI.playSound = true;
        player.speed = 0;
    }
   }
}
