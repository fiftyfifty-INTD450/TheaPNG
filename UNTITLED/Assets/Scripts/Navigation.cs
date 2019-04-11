using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject QuitConfirm;

	public void GoToInitialVideo()
	{
		SceneManager.LoadScene("InitialVideo");
	}

	public void GoToLoginScreen()
	{
		SceneManager.LoadScene("LoginScreen");
	}

	public void GoToTheaDesktop()
    {
        SceneManager.LoadScene("TheaDesktop");
    }

    public void GoToFileExplorer()
    {
        ApplicationModel.SetFileSysHead("Documents");
        SceneManager.LoadScene("FileExplorer");
    }

    public void GoToDiary()
    {
        ApplicationModel.SetFileSysHead("Diary");
        SceneManager.LoadScene("FileExplorer");
    }

	public void GoToEmail()
	{
		SceneManager.LoadScene("AppEmail");
	}

	public void GoToMessaging()
	{
		SceneManager.LoadScene("AppMessaging");
	}

    public void ToggleStartMenu()
    {
        if (StartMenu.activeSelf)
        {
            StartMenu.SetActive(false);
        }
        else
        {
            StartMenu.SetActive(true);
        }
    }

    public void ShowQuitConfirm()
    {
        QuitConfirm.SetActive(true);
    }

    public void HideQuitConfirm()
    {
        QuitConfirm.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
