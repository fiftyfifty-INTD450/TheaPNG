using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
	public GameObject everything;
	public GameObject sfxManager;

	public GameObject warning;
	public GameObject prompt;
	public GameObject progress;

	public AudioSource audioPlayer;
	public AudioClip endingVO;

	public VideoPlayer videoPlayer;
	public VideoClip deleteClip;
	public VideoClip yesClip;

	public Slider progressSlider;

	public GameObject fadeBlack;

	public void Start()
	{
		ApplicationModel.SetFileSysHead("Diary");

		StartCoroutine(DeleteClip());
	}

	IEnumerator DeleteClip()
	{
		everything.SetActive(false);
		sfxManager.SetActive(false);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		double videoDuration = deleteClip.length;

		videoPlayer.clip = deleteClip;
		videoPlayer.Play();

		yield return new WaitForSeconds((float) videoDuration);

		videoPlayer.Stop();

		everything.SetActive(true);
		sfxManager.SetActive(true);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	IEnumerator YesClip()
	{
		everything.SetActive(false);
		sfxManager.SetActive(false);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		double videoDuration = yesClip.length;

		videoPlayer.clip = yesClip;
		videoPlayer.Play();

		yield return new WaitForSeconds((float) videoDuration);

		videoPlayer.Stop();

		everything.SetActive(true);
		sfxManager.SetActive(true);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		ShowProgress();
	}

	public void ShowPrompt()
	{
		warning.SetActive(true);
	}

	public void ShowProgress()
	{
		prompt.SetActive(false);
		progress.SetActive(true);

		StartCoroutine(ProgressSlider());
	}

	public void ForceDelete()
	{
		StartCoroutine(YesClip());
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
