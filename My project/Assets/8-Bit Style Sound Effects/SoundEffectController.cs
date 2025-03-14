using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip enemyDeathSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemyDeathSound);
    }
}
