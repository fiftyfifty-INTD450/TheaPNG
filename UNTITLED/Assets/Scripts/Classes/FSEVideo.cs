using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEVideo : FileSysElement
{
    public void OpenVideo()
    {
        // TODO
        Debug.Log("Opening Video: " + (this.GetComponentInChildren(typeof(Text)) as Text).text);
    }
}
