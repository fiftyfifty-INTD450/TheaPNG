using System.Collections;
using UnityEngine;

public class ReceiveCall : MonoBehaviour
{
	public GameObject receivingCall;
	public GameObject inCall;

	public AudioSource audioPlayer;
	public AudioClip ringtone;
	public AudioClip callAudio;

	void Update()
	{
		if (StoryProgression.Instance.BothPasswordsFound())
		{
			StartCoroutine(PhoneRing());
		}
	}

	private IEnumerator PhoneRing()
	{
		float ringtoneLength = ringtone.length;

		receivingCall.SetActive(true);

		audioPlayer.clip = ringtone;
		audioPlayer.Play();

		yield return new WaitForSeconds(ringtoneLength - 0.5f);

		Hangup();
	}

	public void Hangup()
	{
		audioPlayer.Stop();
		receivingCall.SetActive(false);
	}

	public void PickUp()
	{
		StartCoroutine(Call());
	}

	private IEnumerator Call()
	{
		float callLength = callAudio.length;

		print(callLength);

		receivingCall.SetActive(false);
		inCall.SetActive(true);

		audioPlayer.Stop();
		audioPlayer.clip = callAudio;
		audioPlayer.Play();

		yield return new WaitForSeconds(callLength + 0.5f);

		print("Ending Call");

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

}
