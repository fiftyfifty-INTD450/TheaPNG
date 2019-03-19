using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSEImage : FileSysElement
{
    public GameObject imagePanel;

    public void OpenImage()
    {
        imagePanel.GetComponent<ImagePanel>().SetImage(path);
        imagePanel.SetActive(true);
    }
}
