using System.Collections;
using UnityEngine;

public class ReceiveCall : MonoBehaviour
{
	public GameObject obj;
	public GameObject receivingCall;
	public GameObject inCall;

	public AudioClip ringtone;
	public AudioClip call;
	public AudioSource audioPlayer;

	private StoryProgression storyProgression;

	void Start()
	{
		receivingCall.SetActive(false);
		inCall.SetActive(false);

		storyProgression = obj.AddComponent<StoryProgression>();
	}

	void Update()
	{
		if (storyProgression.BothPasswordsFound())
		{
			storyProgression.ToggleNewCall();

			StartCoroutine(PhoneRing());
		}
	}

	public void TogglePassword1()
	{
		storyProgression.TogglePassword1();
	}

	public void TogglePassword2()
	{
		storyProgression.TogglePassword2();
	}

	private IEnumerator PhoneRing()
	{
		float ringtoneLength = ringtone.length;

		receivingCall.SetActive(true);

		audioPlayer.clip = ringtone;
		audioPlayer.Play();

		yield return new WaitForSeconds(ringtoneLength * 2);

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
		float callLength = call.length;

		receivingCall.SetActive(false);
		inCall.SetActive(true);

		audioPlayer.Stop();
		audioPlayer.clip = call;
		audioPlayer.Play();

		yield return new WaitForSeconds(callLength);

		EndCall();
	}

	public void EndCall()
	{
		audioPlayer.Stop();
		inCall.SetActive(false);
	}
}
