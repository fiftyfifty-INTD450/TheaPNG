using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    public GameObject fseFolder;
    public GameObject fseImage;
    public GameObject fseTextfile;
    public GameObject fseVideo;

    public GameObject imagePanel;
    public GameObject videoPanel;
    public GameObject textfilePanel;

    public AudioClip audioMouseClick;
    public AudioSource audioSource;

    private readonly string basePath = Application.streamingAssetsPath + "/Data/FileSys/Documents";
    private string appendedPath;

    void Start()
    {
        audioSource.clip = audioMouseClick;
        appendedPath = "";
        RefreshWindow();
    }

    public void EnterFolder(string dirname)
    {
        appendedPath += "/" + dirname;
        RefreshWindow();
    }

    public void PathBack()
    {
        if (appendedPath == "") return;

        appendedPath = appendedPath.Substring(0, appendedPath.LastIndexOf('/'));

        RefreshWindow();
    }

    private void RefreshFolders(DirectoryInfo d)
    {
        DirectoryInfo[] dirs = d.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            GameObject element = Instantiate(fseFolder) as GameObject;
            element.SetActive(true);

            element.GetComponent<FSEFolder>().SetName(dir.Name);

            element.transform.SetParent(fseFolder.transform.parent, false);
        }
    }

    private void RefreshFiles(DirectoryInfo d)
    {
        FileInfo[] files = d.GetFiles();
        foreach (FileInfo file in files)
        {
            if (file.Name.EndsWith(".png") || file.Name.EndsWith(".jpg"))
            {
                GameObject element = Instantiate(fseImage) as GameObject;
                element.SetActive(true);

                element.GetComponent<FSEImage>().SetName(file.Name);
                element.GetComponent<FSEImage>().SetPath(basePath+appendedPath+"/"+file.Name);

                element.transform.SetParent(fseImage.transform.parent, false);
            }
            else if (file.Name.EndsWith(".txt"))
            {
                GameObject element = Instantiate(fseTextfile) as GameObject;
                element.SetActive(true);

                element.GetComponent<FSETextfile>().SetName(file.Name);
                element.GetComponent<FSETextfile>().SetPath(basePath + appendedPath + "/" + file.Name);

                element.transform.SetParent(fseTextfile.transform.parent, false);
            }
            else if (file.Name.EndsWith(".mp4"))
            {
                GameObject element = Instantiate(fseVideo) as GameObject;
                element.SetActive(true);

                element.GetComponent<FSEVideo>().SetName(file.Name);
                element.GetComponent<FSEVideo>().SetPath(basePath + appendedPath + "/" + file.Name);

                element.transform.SetParent(fseVideo.transform.parent, false);
            }
            else
            {
                //Debug.Log("File System Manager - Ignoring File: "+file.Name+" (Unhandled Filetype)");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            imagePanel.SetActive(false);
            videoPanel.SetActive(false);
            textfilePanel.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }

    private void ClearElements()
    {
        foreach(Transform child in transform.GetChild(0).GetChild(0))
        {
            if(child.name.EndsWith("(Clone)")) Destroy(child.gameObject);
        }
    }

    private void RefreshWindow()
    {
        ClearElements();

        //Debug.Log("Streaming Assets Path: "+Application.streamingAssetsPath);

        DirectoryInfo d = new DirectoryInfo(basePath + appendedPath);

        RefreshFolders(d);
        RefreshFiles(d);
    }
}
