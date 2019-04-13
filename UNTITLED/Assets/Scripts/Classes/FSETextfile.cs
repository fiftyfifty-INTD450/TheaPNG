using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSETextfile : FileSysElement
{
    public GameObject textfilePanel;
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
            textfilePanel.GetComponent<TextfilePanel>().SetText(path);
            textfilePanel.SetActive(true);
        }
    }
}
