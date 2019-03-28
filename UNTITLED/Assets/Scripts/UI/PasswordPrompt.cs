using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPrompt : MonoBehaviour
{
    private FileSysElement file;

    public void Close()
    {
        Clear();
        gameObject.SetActive(false);
    }

    public void SetFile(FileSysElement file)
    {
        this.file = file;

        // Set title
        transform.GetChild(0).GetComponent<Text>().text = (file.GetComponentInChildren(typeof(Text)) as Text).text;
    }

    public void CompareInput(string text)
    {
        Clear();
        if (text == file.GetPasswordInfo().GetPassword())
        {
            file.Unlock();
            Close();
            file.Open();
        }
        else
        {
            DisplayHint();
        }
    }

    public void Update()
    {
        if(transform.GetChild(1).GetComponent<InputField>().text != "" && Input.GetKey(KeyCode.Return)) // transform.GetChild(1).GetComponent<InputField>().isFocused
        {
            CompareInput(transform.GetChild(1).GetComponent<InputField>().text);
        }
    }

    private void Clear()
    {
        transform.GetChild(1).GetComponent<InputField>().text = "";
        transform.GetChild(2).GetComponent<Text>().text = "";
    }

    public void DisplayHint()
    {
        string hint = file.GetPasswordInfo().GetHint();
        transform.GetChild(2).GetComponent<Text>().text = "Hint: " + hint + "\n(" + file.GetPasswordInfo().GetPassword().Length + " characters long)";
    }
}
