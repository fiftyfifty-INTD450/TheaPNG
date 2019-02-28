using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class MessagingApp : MonoBehaviour
{

	public Transform contentPanel;
	public ObjectPool buttonObjectPool;
	public Text messageBox;

	private List<string> contacts = new List<string>();

	void Start()
	{
		// Load all contacts
		string chatAppFilePath = "Assets/Resources/Data/ChatApp/contacts.txt";
		StreamReader inputFile = new StreamReader(chatAppFilePath);

		while(!inputFile.EndOfStream)
		{
			string line = inputFile.ReadLine( );
			contacts.Add(line);
		}

		inputFile.Close();

		// Add buttons to contact list
		AddButtons();
	}

	private void AddButtons()
	{
		for (int i = 0; i < contacts.Count; i++)
		{
			// Get a button and assign it to scroll list
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);

			// Update button with user information
			ContactButton contactButton = newButton.GetComponent<ContactButton>();
			contactButton.Setup(contacts[i], this);
		}
	}

	public void UpdateMessages(string username)
	{
		string messageFilePath = "Assets/Resources/Data/ChatApp/" + username + ".txt";
		StreamReader inputFile = new StreamReader(messageFilePath);

		string temp = "";

		while (!inputFile.EndOfStream)
		{
			string line = inputFile.ReadLine();
			temp = temp + line + "\n";
		}

		messageBox.text = temp;

		inputFile.Close();
	}
}
