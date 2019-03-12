using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesktopIconHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Scene Transitions */
    /* 
     * The rationale behind the use of separate scenes for each application as
     * opposed to the more intuitive windows approach is as follows:
     *   Merging .scene files in Unity is a a nightmare. Using separate scenes
     *   makes it easy to delagate tasks and avoid scene merge conflicts. If
     *   only one person is working on a scene at any one time, these conflicts
     *   are impossible
     */
    public void openInternet()
    {
		SceneManager.LoadScene("WebApp");
    }

    public void openNotepad()
    {

    }

    public void openDiary()
    {

    }

    public void openFileExplorer()
    {

    }

    public void openMessaging(bool reboot = false)
    {
        SceneManager.LoadScene("ChatApp");
    }
}
