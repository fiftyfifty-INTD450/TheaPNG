using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioClip audioMouseClick;
    public AudioClip passwordJingle;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = audioMouseClick;
            audioSource.Play();
        }
    }

    public void PlayPasswordAffirm()
    {
        audioSource.clip = passwordJingle;
        audioSource.Play();
    }
}
