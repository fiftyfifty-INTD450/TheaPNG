using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEImage : FileSysElement
{
    public GameObject imagePanel;

    public void OpenImage()
    {
        Debug.Log("Opening Image: "+(this.GetComponentInChildren(typeof(Text)) as Text).text);

        Debug.Log("Setting Image from: " + path);

        imagePanel.GetComponent<ImagePanel>().SetImage(path);
        imagePanel.SetActive(true);
    }
}
