using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScreen : MonoBehaviour
{
	public GameObject userPrompt;
	public GameObject loginPrompt;
	public GameObject loginSplash;

	public InputField usernameInput;
	public InputField passwordInput;

	public Text hintPromt;
	public Text hint;

	public AudioSource audioPlayer;
	public AudioClip loginSound;

	private int tries;

	private void Start()
	{
		//userPrompt.SetActive(true);
		//loginPrompt.SetActive(false);
		//loginSplash.SetActive(false);

		//tries = 0;

		Login();
	}

	public void LogInThea()
	{
		userPrompt.SetActive(false);
		loginPrompt.SetActive(true);

		usernameInput.text = "Thea";
	}

	public void CheckPassword()
	{
		tries += 1;

		if (tries == 3)
		{
			hintPromt.text = "Hint:";
			hint.text = "My fav month <33";
		}

		if (tries == 7)
		{
			Login();
		}

		passwordInput.text = "";
	}

	public void Login()
	{
		loginPrompt.SetActive(false);
		loginSplash.SetActive(true);

		StartCoroutine(LoginTimer());
	}

	private IEnumerator LoginTimer()
	{
		yield return new WaitForSeconds(1.0f);

		audioPlayer.clip = loginSound;
		audioPlayer.Play();

		yield return new WaitForSeconds(2.0f);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		SceneManager.LoadScene("TheaDesktop");
	}
}
