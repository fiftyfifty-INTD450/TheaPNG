using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEVideo : FileSysElement
{
    public GameObject videoPanel;

    public void OpenVideo()
    {
        videoPanel.SetActive(true);
        videoPanel.GetComponent<VideoPanel>().PlayStreamingClip(path);
    }
}
