using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;


public class InitialVideo : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public VideoClip videoToPlay;

	public GameObject videoBG;
	public GameObject videoPlayerActive;
	public GameObject cursor;

    void Start()
    {
		double videoDuration = videoToPlay.length;
		StartCoroutine(WaitAndLoad(videoDuration));

		videoBG.SetActive(false);
		videoPlayerActive.SetActive(true);

		videoPlayer.clip = videoToPlay;
	}

	private IEnumerator WaitAndLoad(double videoDuration)
	{
		// Lock user mouse controls
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		cursor.SetActive(false);

		// Wait for initial video to finish
		yield return new WaitForSeconds((float) videoDuration);


		// Cutscene - Cursor closing window
		videoPlayerActive.SetActive(false);
		videoBG.SetActive(true);
		cursor.SetActive(true);

		// Wait for cutscene to finish
		yield return new WaitForSeconds(10);

		// Change to Sam's Desktop to continue cutscene
		SceneManager.LoadScene("SamDesktop");
	}
}
