using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailLock : MonoBehaviour
{
    private string password = "Cool beanz";
    private string hint = "Coffee?? XD";

    public GameObject lockWindow;

    public GameObject inputField;
    public GameObject hintText;
    public GameObject lockIcon;
    public GameObject gameManager;

    public void Close()
    {
        Clear();
        lockWindow.SetActive(false);
    }

    public void Start()
    {
        if (ApplicationModel.emailUnlocked)
        {
            lockIcon.SetActive(false);
        }
        DisplayHint();
    }

    public void TryOpenEmail()
    {
        if (ApplicationModel.emailUnlocked)
        {
            gameManager.GetComponent<Navigation>().GoToEmail();
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
            ApplicationModel.emailUnlocked = true;
            lockIcon.SetActive(false);
            //TryOpenEmail();
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
