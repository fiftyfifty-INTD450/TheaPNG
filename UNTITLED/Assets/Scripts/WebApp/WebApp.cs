using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

public class WebApp : MonoBehaviour
{
	public TextAsset kensEmail;
	public TextAsset rhoderaBusiness1;
	public TextAsset rhoderaBusiness2;
	//public TextAsset

	// List of Emails
	public Transform emailsPanel;

	// Email Content
	public GameObject emailContentPanel;
	public Text emailSubjectText;
	public Text emailFromText;
	public Text emailCCText;
	public Text emailDateText;
	public Text emailContentText;

	public ObjectPool buttonObjectPool;

	private List<TextAsset> emails = new List<TextAsset>();

	void Start()
	{
		emailContentPanel.SetActive(false);

		// Manually order and add all emails here 
		emails.Add(rhoderaBusiness1);
		emails.Add(rhoderaBusiness2);
		emails.Add(kensEmail);

		for (int i = 0; i < emails.Count; i++)
		{
			// Get data from file
			string fileData = emails[i].text;

			// Split file into lines and remove new line characters (Only first 2 lines)
			string[] lines = fileData.Split('\n');
			for (int j = 0; j < 2; j++)
			{
				lines[j] = RemoveNewLineChar(lines[j]);
			}

			// Get a button and assign it to scroll list
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(emailsPanel);

			// Update button with email subject and date
			EmailButton emailButton = newButton.GetComponent<EmailButton>();
			emailButton.Setup(lines[0], lines[1], this);
		}
	}

	private string RemoveNewLineChar(string input)
	{
		string retString = input;

		retString = retString.Replace("\n", "");
		retString = retString.Replace("\r", "");
		retString = retString.Replace("\t", "");

		return retString;
	}

	public void UpdateEmailContent(string subject, string date)
	{
		string emailContent = "";

		// Find matching data file
		for (int i = 0; i < emails.Count; i++)
		{
			// Get data from file
			string fileData = emails[i].text;

			// Split file into lines and remove new line characters (Only first 2 lines)
			string[] lines = fileData.Split('\n');
			for (int j = 0; j < 2; j++)
			{
				lines[j] = RemoveNewLineChar(lines[j]);
			}

			if (lines[0] == subject && lines[1] == date)
			{
				emailContent = fileData;
				break;
			}
		}

		// Parse Data
		if(emailContent == "")
		{
			print("This should not happen!");
		}
		else
		{
			emailContentPanel.SetActive(true);
			// Split file into lines and remove new line characters
			string[] lines = emailContent.Split('\n');
			for (int j = 0; j < lines.Length; j++)
			{
				lines[j] = RemoveNewLineChar(lines[j]);
			}

			emailSubjectText.text = lines[0];
			emailDateText.text = lines[1];
			emailFromText.text = "From: " + lines[2];
			emailCCText.text = "CC: " + lines[3];

			string emailContents = "";

			for(int i = 4; i < lines.Length; i++)
			{
				string temp;

				if (i != lines.Length - 1)
				{
					temp = lines[i] + "\n";
				}
				else
				{
					temp = lines[i];
				}

				emailContents += temp;
			}

			emailContentText.text = emailContents;
		}
	}
}
