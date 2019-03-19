using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEFolder : FileSysElement
{
    public GameObject window;

    public void OpenFolder()
    {
        window.GetComponent<FileManager>().EnterFolder((this.GetComponentInChildren(typeof(Text)) as Text).text);
    }
}
