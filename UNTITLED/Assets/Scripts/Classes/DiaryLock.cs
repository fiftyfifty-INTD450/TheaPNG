using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryLock : MonoBehaviour
{
    private string pass1 = "songbird";
    private string pass2 = "marion";
    private string pass3 = "seattle";

    public InputField Pass1Input;
    public InputField Pass2Input;
    public InputField Pass3Input;

    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;

    public GameObject lockWindow;
    public GameObject GameManager;

    public GameObject lockIcon;

    public void Start()
    {
        // Ensure lock visibility is correct when returning to TheaDesktop
        if (GetProgressionLevel() == 3)
        {
            lockIcon.SetActive(false);
        }
        CheckPasswords();
    }

    public int GetProgressionLevel()
    {
        int prog = 0;
        if (ApplicationModel.Path1Complete) ++prog;
        if (ApplicationModel.Path2Complete) ++prog;
        if (ApplicationModel.Path3Complete) ++prog;

        return prog;
    }

    public void Update()
    {
        if ((Pass1Input.text != "" || Pass2Input.text != "" || Pass3Input.text != "") && Input.GetKey(KeyCode.Return))
        {
            CheckPasswords();
        }
    }

    public void TryOpenDiary()
    {
        if (GetProgressionLevel() == 3)
        {
            GameManager.GetComponent<Navigation>().GoToDiary();
        }
        else
        {
            GameManager.GetComponent<Navigation>().ShowDiaryLockWindow();
        }
    }

    public void CheckPasswords()
    {
        if (Pass1Input.text.ToLower() == pass1 || ApplicationModel.Path1Complete == true)
        {
            if (!ApplicationModel.Path1Complete)
            {
                ApplicationModel.Path1Complete = true;
                GameManager.GetComponent<SFXManager>().PlayPasswordAffirm();
            }
            Pass1Input.text = pass1;
            Pass1Input.interactable = false;
            Pass1Input.GetComponent<Image>().sprite = null;
            Pass1Input.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
            hint1.SetActive(false);
        }
        if (Pass2Input.text.ToLower() == pass2 || ApplicationModel.Path2Complete == true)
        {
            if (!ApplicationModel.Path2Complete)
            {
                ApplicationModel.Path2Complete = true;
                GameManager.GetComponent<SFXManager>().PlayPasswordAffirm();
            }
            Pass2Input.text = pass2;
            Pass2Input.interactable = false;
            Pass2Input.GetComponent<Image>().sprite = null;
            Pass2Input.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
            hint2.SetActive(false);
        }
        if (Pass3Input.text.ToLower() == pass3 || ApplicationModel.Path3Complete == true)
        {
            if (!ApplicationModel.Path3Complete)
            {
                ApplicationModel.Path3Complete = true;
                GameManager.GetComponent<SFXManager>().PlayPasswordAffirm();
            }
            Pass3Input.text = pass3;
            Pass3Input.interactable = false;
            Pass3Input.GetComponent<Image>().sprite = null;
            Pass3Input.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
            hint3.SetActive(false);
        }

        Clear();

        if (GetProgressionLevel() == 3)
        {
            lockIcon.SetActive(false);
            GameManager.GetComponent<Navigation>().HideDiaryLockWindow();
        }
        if(GetProgressionLevel() >= 2 && !ApplicationModel.callDone)
        {
            ApplicationModel.callDone = true;
            GameManager.GetComponent<Navigation>().HideDiaryLockWindow();
            GameManager.GetComponent<ReceiveCall>().DoPhoneCall();
        }
    }

    private void Clear()
    {
        if (!ApplicationModel.Path1Complete) Pass1Input.text = "";
        if (!ApplicationModel.Path2Complete) Pass2Input.text = "";
        if (!ApplicationModel.Path3Complete) Pass3Input.text = "";
    }
}
