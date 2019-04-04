using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEVideo : FileSysElement
{
    public GameObject videoPanel;

    public override void Open()
    {
        if (locked)
        {
            // Enable password prompt
            GameObject pp = transform.parent.parent.parent.parent.GetChild(8).gameObject;
            pp.SetActive(true);
            pp.GetComponent<PasswordPrompt>().SetFile(this);
        }
        else
        {
            videoPanel.SetActive(true);
            videoPanel.GetComponent<VideoPanel>().PlayStreamingClip(path);
        }
    }
}
