using UnityEngine;
using UnityEngine.UI;

public class ContactButton : MonoBehaviour
{

	public Button button;
	public Text usernameLabel;
	//public Text nicknameLabel;
	//public Image userProfileImage;

	void Start()
    {
        
    }

	public void Setup(string username)
	{
		usernameLabel.text = username;
		//nicknameLabel.text = user.nickname;
		//userProfileImage.sprite = user.profilePicture;
	}
}
