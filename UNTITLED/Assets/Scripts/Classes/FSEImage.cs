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

        /*string imagePath = path.Replace("Assets/Resources/", "");
        int idx = imagePath.LastIndexOf(".");
        if (idx > 0)
        {
            imagePath = imagePath.Substring(0, idx);
        }*/


        Debug.Log("Setting Image from: " + path);

        imagePanel.GetComponent<ImagePanel>().SetImage(path);
        imagePanel.SetActive(true);
    }
}
