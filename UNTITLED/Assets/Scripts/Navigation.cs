using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void GoToTheaDesktop()
    {
        SceneManager.LoadScene("TheaDesktop");
    }

    public void GoToFileExplorer()
    {
        SceneManager.LoadScene("FileExplorer");
    }
}
