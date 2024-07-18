using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINSOUND : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
