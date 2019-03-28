using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEImage : FileSysElement
{
    public GameObject imagePanel;

    public override void Open()
    {
        if (locked)
        {
            // Enable password prompt
            GameObject pp = transform.parent.parent.parent.parent.GetChild(7).gameObject;
            pp.SetActive(true);
            pp.GetComponent<PasswordPrompt>().SetFile(this);
        }
        else
        {
            imagePanel.GetComponent<ImagePanel>().SetImage(path);
            imagePanel.SetActive(true);
        }
    }
}
