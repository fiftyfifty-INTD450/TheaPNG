using System.Collections;
using UnityEngine;

public class ReceiveCall : MonoBehaviour
{
	public GameObject receivingCall;
	public GameObject inCall;

	public AudioSource audioPlayer;
	public AudioClip ringtone;
	public AudioClip callAudio;

	private IEnumerator phoneCallCoroutine;

	void Update()
	{
		if (BothPasswordsFound())
		{
			phoneCallCoroutine = PhoneRing();
			StartCoroutine(phoneCallCoroutine);
		}
	}

	private IEnumerator PhoneRing()
	{
		float ringtoneLength = ringtone.length;

		receivingCall.SetActive(true);

		audioPlayer.clip = ringtone;
		audioPlayer.Play();

		yield return new WaitForSeconds(ringtoneLength - 0.2f);

		Hangup();
	}

	public void Hangup()
	{
		audioPlayer.Stop();
		receivingCall.SetActive(false);
	}

	public void PickUp()
	{
		StopCoroutine(phoneCallCoroutine);
		StartCoroutine(Call());
	}

	private IEnumerator Call()
	{
		float callLength = callAudio.length;

		receivingCall.SetActive(false);
		inCall.SetActive(true);

		audioPlayer.Stop();
		audioPlayer.clip = callAudio;
		audioPlayer.Play();

		yield return new WaitForSeconds(callLength + 0.5f);

		EndCall();
	}

	public void EndCall()
	{
		audioPlayer.Stop();

		inCall.SetActive(false);
	}

	public void ToggleEmailPassword()
	{
		StoryProgression.Instance.emailPasswordFound = true;
	}

	public void ToggleFilePassword()
	{
		StoryProgression.Instance.filePasswordFound = true;
	}

	public bool BothPasswordsFound()
	{
		bool emailPasswordFound = StoryProgression.Instance.emailPasswordFound;
		bool filePasswordFound = StoryProgression.Instance.filePasswordFound;
		bool firstCall = StoryProgression.Instance.firstCall;

		if (emailPasswordFound && filePasswordFound && firstCall)
		{
			StoryProgression.Instance.firstCall = false;

			StoryProgression.Instance.emailPasswordFound = false;
			StoryProgression.Instance.filePasswordFound = false;

			return true;
		}

		return false;
	}
}
