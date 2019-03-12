using UnityEngine;
using UnityEngine.UI;
using System;

public class MessagingApp : MonoBehaviour
{

	// Contains all contacts to be displayed
	public TextAsset contactData;

	// Contains all messages for each contact
	public TextAsset grungeNRock;
	public TextAsset hilary;
	public TextAsset abigail;
	public TextAsset dad;

	public Transform contactsPanel;
	public Transform messagePanel;
	public ObjectPool buttonObjectPool;

	public GameObject InboundPrefab;
	public GameObject OutboundPrefab;
	public GameObject DatePrefab;
	public GameObject InboundDeletedPrefab;
	public GameObject OutboundDeletedPrefab;

	private string[] contacts;

	void Start()
	{
		// Load all contacts
		contacts = contactData.text.Split('\n');

		// Remove new line from each contact
		for (int i = 0; i < contacts.Length; i++){
			contacts[i] = RemoveNewLineChar(contacts[i]);
		}

		// Add buttons to contact list
		AddButtons();
	}

	// Load in contacts (Not working in build)
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

	private string RemoveNewLineChar(string input)
	{
		string retString = input;

		retString = retString.Replace("\n", "");
		retString = retString.Replace("\r", "");
		retString = retString.Replace("\t", "");

		return retString;
	}

	private void AddButtons()
	{
		for (int i = 0; i < contacts.Length; i++)
		{
			// Get a button and assign it to scroll list
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contactsPanel);

			// Update button with user information
			ContactButton contactButton = newButton.GetComponent<ContactButton>();
			contactButton.Setup(contacts[i], this);
		}
	}

	public void UpdateMessages(string username)
	{
		// Remove old bubbles
		foreach (Transform child in messagePanel)
		{
			Destroy(child.gameObject);
		}

		// Read from TextAsset based on contact pressed
		string textToDisplay = "";

		if(username == "grunge_n_rock")
		{
			textToDisplay = grungeNRock.text;
		}
		else if(username == "Hilary")
		{
			textToDisplay = hilary.text;
		}
		else if(username == "Abiail")
		{
			textToDisplay = abigail.text;
		}
		else if(username == "Dad")
		{
			textToDisplay = dad.text;
		}
		//else if (username == "")
		//{
		//	textToDisplay = ;
		//}

		// Split file into lines
		string[] lines = textToDisplay.Split('\n');

		// Pharse each line
		foreach(string line in lines)
		{
			// Split each line at "__"
			string[] content = line.Split(new string[] { "__" }, StringSplitOptions.None);

			// Remove new line characters
			for(int i = 0; i < content.Length; i++)
			{
				content[i] = RemoveNewLineChar(content[i]);
			}

			// Check which bubble to create
			if (content[0] == "INBOUND_DELETED")
			{
				// Create Deleted Bubble
				GameObject newBubble = Instantiate(InboundDeletedPrefab);
				newBubble.transform.SetParent(messagePanel);
			}
			else if (content[0] == "OUTBOUND_DELETED")
			{
				// Create Deleted Bubble
				GameObject newBubble = Instantiate(OutboundDeletedPrefab);
				newBubble.transform.SetParent(messagePanel);
			}
			else if (content[0] == "DATE")
			{
				// Create Date Seperator with content[1] as Date and content[2] as Time
				string dateText = content[1] + "\n" + content[2];

				GameObject newBubble = Instantiate(DatePrefab);
				newBubble.transform.SetParent(messagePanel);

				Text dateLabel = newBubble.GetComponentInChildren<Text>();
				dateLabel.text = dateText;
			}
			else if (content[0] == "INBOUND")
			{
				// Create Inbound Bubble with content[1] as Text
				GameObject newBubble = Instantiate(InboundPrefab);
				newBubble.transform.SetParent(messagePanel);

				Text dateLabel = newBubble.GetComponentInChildren<Text>();
				dateLabel.text = content[1];

			}
			else if (content[0] == "OUTBOUND")
			{
				// Create Outbound Bubble with content[1] as Text
				GameObject newBubble = Instantiate(OutboundPrefab);
				newBubble.transform.SetParent(messagePanel);

				Text dateLabel = newBubble.GetComponentInChildren<Text>();
				dateLabel.text = content[1];
			}
			else
			{
				// This should not happen
				// Something wrong with the message files
				print("Error in data formatting.");
				print(line + " @ " + content[0]);
			}
		}
	}

	// Display messages (Not working in build)
	/*
	public Text messageBox;

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
