using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WebApp : MonoBehaviour
{
	// Add email data here
	public TextAsset prescriptionRefill;
	public TextAsset easter;
	public TextAsset eastEndBar;
	public TextAsset churchill1;
	public TextAsset churchill2;
	public TextAsset beddit1;
	public TextAsset rhoderaBusiness1;
	public TextAsset rhoderaBusiness2;
	public TextAsset beddit2;
	public TextAsset laborDay;
	public TextAsset galaxyInvestments1;
	public TextAsset beddit3;
	public TextAsset hatton1;
	public TextAsset hatton2;
	public TextAsset beddit4;
	public TextAsset econ;
	public TextAsset draft1;
	public TextAsset draft2;

	// List of Emails
	public Transform emailsPanel;

	// Email Content
	public GameObject emailContentPanel;
	public Text emailSubjectText;
	public Text emailFromText;
	public Text emailCCText;
	public Text emailDateText;
	public Text emailContentText;

	public GameObject bedditUnsubText;
	public GameObject resume1;
	public GameObject resume2;
	public GameObject easterImage;
	public GameObject laborDayImage;

	public ObjectPool buttonObjectPool;

	public Text inboxType;


	private List<TextAsset> emails = new List<TextAsset>();
	private List<TextAsset> drafts = new List<TextAsset>();

	void Start()
	{
		emailContentPanel.SetActive(false);

		// Manually order and add all emails here 
		emails.Add(prescriptionRefill);
		emails.Add(easter);
		emails.Add(eastEndBar);
		emails.Add(churchill1);
		emails.Add(churchill2);
		emails.Add(beddit1);
		emails.Add(rhoderaBusiness1);
		emails.Add(rhoderaBusiness2);
		emails.Add(beddit2);
		emails.Add(laborDay);
		emails.Add(galaxyInvestments1);
		emails.Add(beddit3);
		emails.Add(hatton1);
		emails.Add(hatton2);
		emails.Add(beddit4);
		emails.Add(econ);

		drafts.Add(draft1);
		drafts.Add(draft2);

		ShowInboxEmails();
	}

	private void ShowInboxEmails()
	{
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

	private void ShowDraftEmails()
	{
		for (int i = 0; i < drafts.Count; i++)
		{
			// Get data from file
			string fileData = drafts[i].text;

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
		//retString = retString.Replace("\t", "");

		return retString;
	}

	public void UpdateEmailContent(string subject, string date)
	{
		string emailContent = "";

		// Find matching data file
		if (inboxType.text == "Inbox")
		{
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
		}
		else if (inboxType.text == "Draft")
		{
			for (int i = 0; i < drafts.Count; i++)
			{
				// Get data from file
				string fileData = drafts[i].text;

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
		}
		else
		{
			print("This should not happen.");
		}

		// Parse Data
		if (emailContent == "")
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

			// Main Body Contents
			string emailContents = "";

			for (int i = 4; i < lines.Length; i++)
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

			
			if (lines[0].Contains("Beddit"))
			{
				bedditUnsubText.SetActive(true);
				easterImage.SetActive(false);
				laborDayImage.SetActive(false);
				resume1.SetActive(false);
				resume2.SetActive(false);
			}
			else if (lines[0] == "Easter Day Email!")
			{
				bedditUnsubText.SetActive(false);
				easterImage.SetActive(true);
				laborDayImage.SetActive(false);
				resume1.SetActive(false);
				resume2.SetActive(false);
			}
			else if (lines[0] == "Happy Labour Day!")
			{
				bedditUnsubText.SetActive(false);
				easterImage.SetActive(false);
				laborDayImage.SetActive(true);
				resume1.SetActive(false);
				resume2.SetActive(false);
			}
			else if (lines[0] == "[Draft] Internship Cover Letter")
			{
				bedditUnsubText.SetActive(false);
				easterImage.SetActive(false);
				laborDayImage.SetActive(false);
				resume1.SetActive(true);
				resume2.SetActive(true);

				emailFromText.text = "To: ";
			}
			else
			{
				bedditUnsubText.SetActive(false);
				easterImage.SetActive(false);
				laborDayImage.SetActive(false);
				resume1.SetActive(false);
				resume2.SetActive(false);
			}
		}
	}

	public void ShowInbox()
	{
		inboxType.text = "Inbox";
		ClearEmails();
		ShowInboxEmails();
	}

	public void ShowDraft()
	{
		inboxType.text = "Draft";
		ClearEmails();
		ShowDraftEmails();
	}

	public void ClearEmails()
	{
		foreach (Transform child in emailsPanel)
		{
			Destroy(child.gameObject);
		}
	}
}
