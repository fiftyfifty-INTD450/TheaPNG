using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class AudioPanel : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayStreamingClip(string path)
    {
        StartCoroutine(PlayAudio(path));
    }

    private IEnumerator PlayAudio(string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
                while (audioSource.clip.loadState != AudioDataLoadState.Loaded)
                    yield return null;

                audioSource.Play();

                while (audioSource.isPlaying)
                    yield return null;
            }
        }
    }


    /*
    IEnumerator LoadAudio(string path)
    {
        UnityWebRequestMultimedia www = new UnityWebRequestMultimedia(path);

        clip = www.GetAudioClip(false);
    }*/
}
