using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audio;
    public AudioClip hitSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip playSound;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayHitSound(AudioClip sound)
    {
        audio.PlayOneShot(sound, 1f);
    }
}
