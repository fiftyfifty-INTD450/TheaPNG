using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEVideo : FileSysElement
{
    public GameObject videoPanel;

    public void OpenVideo()
    {
        // TODO
        Debug.Log("Opening Video: " + (this.GetComponentInChildren(typeof(Text)) as Text).text);

        Debug.Log("Setting Video from: " + path);

        videoPanel.SetActive(true);
        videoPanel.GetComponent<VideoPanel>().PlayStreamingClip(path);
        //videoPanel.SetActive(true);
    }
}
