using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public AudioClip largeExplosion;
    public AudioClip smallExplosion;
    public AudioClip impactRock;
    public AudioClip levelUp;
    public AudioClip ammoUp;
    public AudioClip backgroundMusic;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;

    void Start()
    {
        audioSource1.clip = largeExplosion;
        audioSource2.clip = smallExplosion;
        audioSource3.clip = impactRock;
        audioSource4.clip = levelUp;
        audioSource5.clip = ammoUp;
        audioSource6.clip = backgroundMusic;
        audioSource6.Play();
    }
    public void LargeExplosion()
    {
        audioSource1.Play();
    }

    public void SmallExplosion()
    {
        audioSource2.Play();
    }

    public void ImpactRock()
    {
        audioSource3.Play();
    }
    public void LevelUp()
    {
        audioSource4.Play();
    }
    public void AmmoUp()
    {
        audioSource5.Play();
    }
}
