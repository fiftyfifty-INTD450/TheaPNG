using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialCutscene : MonoBehaviour
{
	public GameObject startMenu;

	private void Start()
	{
		startMenu.SetActive(false);
	}

	public void OpenStartMenu()
	{
		startMenu.SetActive(true);
	}

	public void GoToLogInScreen()
	{
		SceneManager.LoadScene("LoginScreen");
	}
}
