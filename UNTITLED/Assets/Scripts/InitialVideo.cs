using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;


public class InitialVideo : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public VideoClip videoToPlay;

	public GameObject titleBar;
	public GameObject videoBG;
	public GameObject videoPlayerActive;

    void Start()
    {
		double videoDuration = videoToPlay.length;
		StartCoroutine(WaitAndLoad(videoDuration));

		titleBar.SetActive(false);
		videoBG.SetActive(false);
		videoPlayerActive.SetActive(true);

		videoPlayer.clip = videoToPlay;
	}

	private IEnumerator WaitAndLoad(double videoDuration)
	{
		// Lock user mouse controls
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		// Wait for initial video to finish
		yield return new WaitForSeconds((float) videoDuration);

		videoPlayerActive.SetActive(false);
		titleBar.SetActive(true);
		videoBG.SetActive(true);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void GoToSamDesktop()
	{
		SceneManager.LoadScene("SamDesktop");
	}
}
