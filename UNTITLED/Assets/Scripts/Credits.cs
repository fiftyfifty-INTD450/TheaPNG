using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

	public AudioSource audioPlayer;
	public AudioClip song;

	public GameObject prompt1;
	public GameObject prompt2;
	public GameObject prompt3;
	public GameObject prompt4;
	public GameObject prompt5;
	public GameObject prompt6;
	public GameObject prompt7;
	public GameObject prompt8;
	public GameObject prompt9;
	public GameObject prompt10;
	public GameObject prompt11;
	public GameObject prompt12;

	public GameObject skipPrompt;

    void Start()
    {
		StartCoroutine(PlaySong());
    }

	IEnumerator PlaySong()
	{
		audioPlayer.clip = song;
		audioPlayer.Play();

		StartCoroutine(Timer());

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt1);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt2);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt3);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt4);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt5);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt6);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt7);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt8);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt9);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt10);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt11);

		yield return new WaitForSeconds(2);

		GetComponent<TextFade>().TextFadeIn(prompt12);

		yield return new WaitForSeconds(4);

		GetComponent<TextFade>().TextFadeIn(skipPrompt);

		while (!Input.anyKey)
		{
			yield return null;
		}

		audioPlayer.Stop();
		StopAllCoroutines();

		SceneManager.LoadScene("TitleScreen");
	}

	IEnumerator Timer()
	{
		float songDuration = song.length;

		yield return new WaitForSeconds(songDuration);

		audioPlayer.Stop();
		StopAllCoroutines();

		SceneManager.LoadScene("TitleScreen");
	}
}
