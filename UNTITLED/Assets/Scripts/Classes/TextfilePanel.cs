using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextfilePanel : MonoBehaviour
{
    public void SetTitle(string title)
    {

    }

    public void SetText(string path)
    {
        transform.GetChild(1).GetComponent<Text>().text = ReadTextFile(path);
    }

    private string ReadTextFile(string p)
    {
        StreamReader reader = new StreamReader(p);
        string text = reader.ReadToEnd();
        reader.Close();
        return text;
    }
}
