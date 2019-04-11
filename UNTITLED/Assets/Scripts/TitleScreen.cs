using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
	public GameObject mainContent;
	public GameObject extraHelpInfo;
	public GameObject creditContent;

	public void PlayGame()
	{
		SceneManager.LoadScene("InitialVideo");
	}

	public void ShowHelpInfo()
	{
		mainContent.SetActive(false);
		extraHelpInfo.SetActive(true);
	}

	public void HideHelpInfo()
	{
		extraHelpInfo.SetActive(false);
		mainContent.SetActive(true);
	}

	public void ShowCredits()
	{
		mainContent.SetActive(false);
		creditContent.SetActive(true);
	}

	public void HideCredits()
	{
		creditContent.SetActive(false);
		mainContent.SetActive(true);
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
