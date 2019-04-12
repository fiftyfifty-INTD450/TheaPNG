using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;


public class InitialVideo : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public VideoClip introVideo;
	public VideoClip introCutscene;

	public GameObject titleBar;
	public GameObject videoBG;
	public GameObject videoPlayerActive;

	public GameObject taskbar;

    void Start()
    {
		double videoDuration = introVideo.length;
		StartCoroutine(WaitAndLoad(videoDuration));

		titleBar.SetActive(false);
		taskbar.SetActive(false);
		videoBG.SetActive(false);

		videoPlayerActive.SetActive(true);
		videoPlayer.clip = introVideo;
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.F12))
		{
			StopAllCoroutines();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			SceneManager.LoadScene("TheaDesktop");
		}
	}

	private IEnumerator WaitAndLoad(double videoDuration)
	{
		// Lock user mouse controls
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		// Wait for initial video to finish
		yield return new WaitForSeconds((float) videoDuration);

		taskbar.SetActive(true);

		videoPlayer.Stop();
		videoPlayer.clip = introCutscene;
		videoPlayer.Play();

		StartCoroutine(WaitAndRemoveTaskbar());

		yield return new WaitForSeconds((float) introCutscene.length);

		SceneManager.LoadScene("LoginScreen");
	}

	private IEnumerator WaitAndRemoveTaskbar()
	{
		yield return new WaitForSeconds(4.5f);

		taskbar.SetActive(false);
	}

	//public void GoToSamDesktop()
	//{
	//	SceneManager.LoadScene("SamDesktop");
	//}
}
