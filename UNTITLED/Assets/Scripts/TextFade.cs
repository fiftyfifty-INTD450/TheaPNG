using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
	public float fadeInTime;
	public float fadeOutTime;

	public void TextFadeIn(GameObject text)
	{
		StartCoroutine(FadeInRoutine(text));
	}

	public void TextFadeOut(GameObject text)
	{
		StartCoroutine(FadeOutRoutine(text));
	}

	private IEnumerator FadeInRoutine(GameObject text)
	{
		Text textComponent = text.GetComponent<Text>();

		for (float t = 0.01f; t < fadeInTime; t += Time.deltaTime)
		{
			textComponent.color = Color.Lerp(Color.clear, Color.white, Mathf.Min(1, t / fadeInTime));
			yield return null;
		}
	}

	private IEnumerator FadeOutRoutine(GameObject text)
	{
		Text textComponent = text.GetComponent<Text>();
		Color originalColor = textComponent.color;
		for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
		{
			textComponent.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
			yield return null;
		}
	}
}
