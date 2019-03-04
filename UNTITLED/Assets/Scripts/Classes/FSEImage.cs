using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEImage : FileSysElement
{
    public void OpenImage()
    {
        // TODO
        Debug.Log("Opening Image: "+(this.GetComponentInChildren(typeof(Text)) as Text).text);
    }
}
