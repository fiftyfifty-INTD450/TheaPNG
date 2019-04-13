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

    public GameObject lockIcon;
    public GameObject gameManager;
    public GameObject passwordWindow;

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
        if (ApplicationModel.HasBeenUnlocked(path)) return; // File was unlocked previously

        locked = true;
        lockIcon.SetActive(true);
    }

    public void Unlock()
    {
        locked = false;
        lockIcon.SetActive(false);
        ApplicationModel.RegisterUnlockedFile(path);
        gameManager.GetComponent<SFXManager>().PlayPasswordAffirm();
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
