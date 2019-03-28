using UnityEngine;

public class StoryProgression : MonoBehaviour
{

	private bool emailPasswordFound;
	private bool fileExplorerFound;
	private bool newCall;

	public StoryProgression()
	{
		emailPasswordFound = false;
		fileExplorerFound = false;
		newCall = true;
	}

	public void TogglePassword1()
	{
		emailPasswordFound = true;
	}

	public void TogglePassword2()
	{
		fileExplorerFound = true;
	}

	public bool BothPasswordsFound()
	{
		if(emailPasswordFound && fileExplorerFound && newCall)
		{
			return true;
		}

		return false;
	}

	public void ToggleNewCall()
	{
		//newCall = false;
		emailPasswordFound = false;
		fileExplorerFound = false;
	}
}
