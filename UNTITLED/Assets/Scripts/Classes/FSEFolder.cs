using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEFolder : FileSysElement
{
    public GameObject window;

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
            window.GetComponent<FileManager>().EnterFolder((this.GetComponentInChildren(typeof(Text)) as Text).text);
        }
    }
}
