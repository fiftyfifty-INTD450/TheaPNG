using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDiaryChange : MonoBehaviour
{
	public void CheckAndChange()
	{
		if(ApplicationModel.GetFileSysHead() == "Diary")
		{
			SceneManager.LoadScene("DiaryCutscene");
		}
	}
}
