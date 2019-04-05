using UnityEngine;

public class StoryProgression : MonoBehaviour
{
	public static StoryProgression Instance;

	public bool emailPasswordFound;
	public bool filePasswordFound;
	public bool firstCall;

	private void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	public bool BothPasswordsFound()
	{
		if(emailPasswordFound && filePasswordFound && firstCall)
		{
			firstCall = false;

			return true;
		}

		return false;
	}
}
