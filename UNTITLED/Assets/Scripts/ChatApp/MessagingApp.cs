using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class MessagingApp : MonoBehaviour
{

	// Contains all contacts to be displayed
	public TextAsset contactData;

	// Contains all messages for each contact
	public TextAsset debugKen;
	public TextAsset grungeNRock;

	public Transform contentPanel;
	public ObjectPool buttonObjectPool;
	public Text messageBox;

	private string[] contacts;

	void Start()
	{
		// Load all contacts
		contacts = contactData.text.Split('\n');

		// Remove new line from each contact
		for (int i = 0; i < contacts.Length; i++){
			contacts[i] = contacts[i].Replace("\n", "");
			contacts[i] = contacts[i].Replace("\r", "");
			contacts[i] = contacts[i].Replace("\t", "");
		}

		// Add buttons to contact list
		AddButtons();
	}

	// Not working after building
	/*
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
	*/
	private void AddButtons()
	{
		for (int i = 0; i < contacts.Length; i++)
		{
			// Get a button and assign it to scroll list
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);

			// Update button with user information
			ContactButton contactButton = newButton.GetComponent<ContactButton>();
			contactButton.Setup(contacts[i], this);
		}
	}


	// Hardcoded
	public void UpdateMessages(string username)
	{
		string textToDisplay;

		if(username == "debug_ken")
		{
			textToDisplay = debugKen.text;
		}
		else if(username == "grunge_n_rock")
		{
			textToDisplay = grungeNRock.text;
		}
		else
		{
			textToDisplay = "";
		}
		
		messageBox.text = textToDisplay;

	}

	// Not working after building
	/*
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
	*/
}
