using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEAudio : FileSysElement
{
    public GameObject audioPanel;

    public void OpenAudio()
    {
        Debug.Log("Opening Audio: " + (this.GetComponentInChildren(typeof(Text)) as Text).text);
        Debug.Log("Setting Audio from: " + path);

        audioPanel.SetActive(true);
        audioPanel.GetComponent<AudioPanel>().PlayStreamingClip(path);
    }
}
