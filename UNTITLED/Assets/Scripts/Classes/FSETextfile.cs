using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSETextfile : FileSysElement
{
    public GameObject textfilePanel;
    public void OpenTextfile()
    {
        Debug.Log("Opening Textfile: " + (this.GetComponentInChildren(typeof(Text)) as Text).text);

        Debug.Log("Setting Textfile from: " + path);

        textfilePanel.GetComponent<TextfilePanel>().SetText(path);
        textfilePanel.SetActive(true);
    }
}
