using UnityEngine;
using UnityEngine.UI;

public class EmailButton : MonoBehaviour
{
	public Button button;
	public Text subjectLabel;
	public Text dateLabel;

	private WebApp webApp;

	void Start()
	{
		button.onClick.AddListener(HandleClick);
	}

	public void Setup(string subject, string date, WebApp currentWebApp)
	{
		subjectLabel.text = subject;
		dateLabel.text = date;

		webApp = currentWebApp;
	}

	public void HandleClick()
	{
		webApp.UpdateEmailContent(subjectLabel.text, dateLabel.text);
	}
}
