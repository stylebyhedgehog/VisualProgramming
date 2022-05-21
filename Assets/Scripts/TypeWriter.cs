using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
	[SerializeField]Text text;
	string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.05f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;
	private Coroutine coroutine;

	public void StartTyping()
	{
		if (text != null && text.IsActive())
		{
			writer = text.text;
			text.text = "";

			coroutine = StartCoroutine("TypeWriterText");
		}
	}

	public void StopTyping()
    {
		if (coroutine!=null)
        {
			StopCoroutine(coroutine);
			writer = text.text;
			text.text = "";
		}
	}

	IEnumerator TypeWriterText()
	{
		text.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (text.text.Length > 0)
			{
				text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
			}
			text.text += c;
			text.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
		}
	}

}
