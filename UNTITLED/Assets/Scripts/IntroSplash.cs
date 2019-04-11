using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSplash : MonoBehaviour
{
	public GameObject warningText;
	public GameObject helpText;
	public GameObject phoneText;
	public GameObject continueText;

	public Camera mainCamera;

    void Start()
    {
		StartCoroutine(StartingSplashes());
	}

	IEnumerator StartingSplashes()
	{
		// Initial Warning
		GetComponent<TextFade>().TextFadeIn(warningText);

		yield return new WaitForSeconds(3);

		// Continue Prompt
		GetComponent<TextFade>().TextFadeIn(continueText);

		// Wait for Input
		while (!Input.anyKey)
		{
			yield return null;
		}

		// Hide Prompts
		GetComponent<TextFade>().TextFadeOut(warningText);
		GetComponent<TextFade>().TextFadeOut(continueText);

		yield return new WaitForSeconds(1);

		// Need help Prompt
		GetComponent<TextFade>().TextFadeIn(helpText);

		yield return new WaitForSeconds(3);

		// Phone numbers Prompt
		GetComponent<TextFade>().TextFadeIn(phoneText);

		yield return new WaitForSeconds(2);

		// Continue Prompt
		GetComponent<TextFade>().TextFadeIn(continueText);

		while (!Input.anyKey)
		{
			yield return null;
		}

		// Hide Prompts
		GetComponent<TextFade>().TextFadeOut(helpText);
		GetComponent<TextFade>().TextFadeOut(phoneText);
		GetComponent<TextFade>().TextFadeOut(continueText);

		yield return new WaitForSeconds(2);

		// Show logo
		SceneManager.LoadScene("LogoSplash");

	}
}
