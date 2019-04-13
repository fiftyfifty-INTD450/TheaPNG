using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPrompt : MonoBehaviour
{
    private FileSysElement file;

    public GameObject inputField;
    public GameObject hintText;

    public void Close()
    {
        Clear();
        gameObject.SetActive(false);
    }

    public void SetFile(FileSysElement file)
    {
        this.file = file;
        DisplayHint();
    }

    public void CompareInput()
    {
        if (inputField.GetComponent<InputField>().text.ToLower() == file.GetPasswordInfo().GetPassword().ToLower())
        {
            file.Unlock();
            Clear();
            Close();
            file.Open();
        }
        Clear();
    }

    public void Update()
    {
        if(inputField.GetComponent<InputField>().text != "" && Input.GetKey(KeyCode.Return))
        {
            CompareInput();
        }
    }

    private void Clear(bool clearHint = false)
    {
        inputField.GetComponent<InputField>().text = "";
        if (clearHint) hintText.GetComponent<Text>().text = "";
    }

    public void DisplayHint()
    {
        string hint = file.GetPasswordInfo().GetHint();
        hintText.GetComponent<Text>().text = "Hint: " + hint + "\n(" + file.GetPasswordInfo().GetPassword().Length + " characters long)";
    }
}
