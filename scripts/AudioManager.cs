using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip finalTransitionClip;
    [SerializeField] private AudioClip whooshTransitionClip;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void FinalTransition()
    {
        audioSource.clip = finalTransitionClip;
        audioSource.Play();
    }

    public void WhooshTransition()
    {
        audioSource.clip = whooshTransitionClip;
        audioSource.Play();
    }
}
