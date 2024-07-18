using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]GameManager manager;
    public AudioSource audioSource;
    public AudioClip coinsound;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(delay());
        manager.coinCount++;
            
        }
    }
    IEnumerator delay()
    {
        audioSource.PlayOneShot(coinsound);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
