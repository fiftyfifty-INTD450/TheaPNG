using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class MessagingApp : MonoBehaviour
{

	public Transform contentPanel;
	public ObjectPool buttonObjectPool;

	private List<string> contacts = new List<string>();
	private List<string> messagesFilePath = new List<string>();

	void Start()
	{
		// Load contacts and create their corresponding message file path
		string chatAppFilePath = "Assets/Resources/Data/ChatApp/";
		string contactsFileName = "contacts.txt";
		StreamReader inputFile = new StreamReader(chatAppFilePath + contactsFileName);

		while(!inputFile.EndOfStream)
		{
			string line = inputFile.ReadLine( );
			contacts.Add(line);
			messagesFilePath.Add(chatAppFilePath + line + ".txt");
		}

		inputFile.Close();

		// Add buttons to screen
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
			contactButton.Setup(contacts[i]);
		}
	}
}
