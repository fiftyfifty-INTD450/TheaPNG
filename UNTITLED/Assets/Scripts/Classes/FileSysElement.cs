using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FileSysElement : MonoBehaviour
{
    private string path;

    public void SetIcon(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

    public void SetName(string name)
    {
        (this.GetComponentInChildren(typeof(Text)) as Text).text = name;
    }

    public void SetPath(string p)
    {
        path = p;
    }

    public string getPath()
    {
        return path;
    }
}
