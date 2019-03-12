using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSETextfile : FileSysElement
{
    public void OpenTextfile()
    {
        // TODO
        Debug.Log("Opening Textfile: " + (this.GetComponentInChildren(typeof(Text)) as Text).text);
    }
}
