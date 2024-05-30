using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBladeXR : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip bladeSound;
    public AudioSource audioSource;
    void Awake(){

    }

    // Update is called once per frame
    public void PlayBladeSound()
    {
        audioSource.PlayOneShot(bladeSound);
    }
}