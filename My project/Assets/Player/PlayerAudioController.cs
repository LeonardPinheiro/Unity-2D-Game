using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip GetItemSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayGetItem()
    {
        audioSource.PlayOneShot(GetItemSound);    
    }
}
