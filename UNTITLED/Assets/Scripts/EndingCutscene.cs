using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
	public GameObject prompt;
	public GameObject progress;

	public AudioSource audioPlayer;
	public AudioClip endingVO;

	public Slider progressSlider;

	public GameObject fadeBlack;

	public void ShowProgress()
	{
		prompt.SetActive(false);
		progress.SetActive(true);

		StartCoroutine(ProgressSlider());
	}

	IEnumerator ProgressSlider()
	{
		float progress = 0;

		StartCoroutine(PlayVO());

		while (progress < 1)
		{
			progressSlider.value = progress;

			progress += 0.0003f;

			yield return null;
		}
	}

	IEnumerator PlayVO()
	{
		yield return new WaitForSeconds(3.0f);

		float voDuration = endingVO.length;

		audioPlayer.clip = endingVO;
		audioPlayer.Play();

		yield return new WaitForSeconds(voDuration + 1.0f);

		fadeBlack.SetActive(true);

		audioPlayer.Stop();
		StopAllCoroutines();
		SceneManager.LoadScene("Credits");
	}
}
