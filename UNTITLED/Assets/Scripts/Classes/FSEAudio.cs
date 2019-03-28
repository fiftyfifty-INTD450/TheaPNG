using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEAudio : FileSysElement
{
    public GameObject audioPanel;

    public void OpenAudio()
    {
        audioPanel.SetActive(true);
        audioPanel.GetComponent<AudioPanel>().PlayStreamingClip(path);
    }
}
