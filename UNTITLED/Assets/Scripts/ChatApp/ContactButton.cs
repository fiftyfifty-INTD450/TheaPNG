using UnityEngine;
using UnityEngine.UI;

public class ContactButton : MonoBehaviour
{

	public Button button;
	public Text usernameLabel;
	//public Text nicknameLabel;
	//public Image userProfileImage;

	private MessagingApp messagingApp;

	void Start()
	{
		button.onClick.AddListener(HandleClick);
	}

	public void Setup(string username, MessagingApp currentMessagingApp)
	{
		usernameLabel.text = username;
		//nicknameLabel.text = user.nickname;
		//userProfileImage.sprite = user.profilePicture;

		messagingApp = currentMessagingApp;
	}

	public void HandleClick()
	{
		messagingApp.UpdateMessages(usernameLabel.text);
	}
}
