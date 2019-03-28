using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
	public void GoToInitialVideo()
	{
		SceneManager.LoadScene("InitialVideo");
	}

	public void GoToTheaDesktop()
    {
        SceneManager.LoadScene("TheaDesktop");
    }

    public void GoToFileExplorer()
    {
        SceneManager.LoadScene("FileExplorer");
    }

	public void GoToInternet()
	{
		SceneManager.LoadScene("WebApp");
	}

	public void GoToMessaging()
	{
		SceneManager.LoadScene("ChatApp");
	}
}
