using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraftsLock : MonoBehaviour
{
    private string password = "Pianist";
    private string hint = "Dream Job";

    public GameObject lockWindow;

    public GameObject inputField;
    public GameObject hintText;
    public GameObject lockIcon;
    public GameObject scripts;

    public void Close()
    {
        Clear();
        lockWindow.SetActive(false);
    }

    public void Start()
    {
        if (ApplicationModel.draftsUnlocked)
        {
            lockIcon.SetActive(false);
        }
        DisplayHint();
    }

    public void TryOpenDrafts()
    {
        if (ApplicationModel.draftsUnlocked)
        {
            scripts.GetComponent<WebApp>().ShowDraft();
        }
        else
        {
            lockWindow.SetActive(true);
        }
    }

    public void CompareInput()
    {
        if (inputField.GetComponent<InputField>().text.ToLower() == password.ToLower())
        {
            Clear();
            Close();
            ApplicationModel.draftsUnlocked = true;
            scripts.GetComponent<SFXManager>().PlayPasswordAffirm();
            lockIcon.SetActive(false);
        }
        Clear();
    }

    public void Update()
    {
        if (inputField.GetComponent<InputField>().text != "" && Input.GetKey(KeyCode.Return))
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
        hintText.GetComponent<Text>().text = "Hint: " + hint + "\n(" + password.Length + " characters long)";
    }
}
