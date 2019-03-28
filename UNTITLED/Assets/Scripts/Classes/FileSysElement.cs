using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class FileSysElement : MonoBehaviour
{
    protected string path;
    protected FSPasswordInfo password;
    protected bool locked = false;

    public abstract void Open();

    public void SetIcon(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

    public bool HasPassword()
    {
        return password != null;
    }

    public void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }

    public void SetName(string name)
    {
        (this.GetComponentInChildren(typeof(Text)) as Text).text = name;
    }

    public void SetPath(string path)
    {
        this.path = path;
    }

    public void SetPasswordInfo(FSPasswordInfo password)
    {
        this.password = password;
    }

    public string GetPath()
    {
        return path;
    }

    public FSPasswordInfo GetPasswordInfo()
    {
        return password;
    }
}
