using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEAudio : FileSysElement
{
    public GameObject audioPanel;

    public override void Open()
    {
        if (locked)
        {
            // Enable password prompt
            passwordWindow.SetActive(true);
            passwordWindow.GetComponent<PasswordPrompt>().SetFile(this);
        }
        else
        {
            audioPanel.SetActive(true);
            audioPanel.GetComponent<AudioPanel>().PlayStreamingClip(path);
        }
    }
}
