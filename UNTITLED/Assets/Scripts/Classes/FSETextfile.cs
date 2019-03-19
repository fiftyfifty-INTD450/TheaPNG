using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSETextfile : FileSysElement
{
    public GameObject textfilePanel;
    public void OpenTextfile()
    {
        textfilePanel.GetComponent<TextfilePanel>().SetText(path);
        textfilePanel.SetActive(true);
    }
}
