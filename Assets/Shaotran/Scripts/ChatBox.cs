using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {
	public int ChatID;
	public string Title;
	public string Date;
	public Texture2D ImageID;
	public string Subject; //Chemistry, History, English, Math, Biology, Spanish

	public GameObject TitleText;
	public GameObject DueDateText;
	public GameObject GroupImage;

	public Color chem;
	public Color history;
	public Color English;
	public Color Math;
	public Color Bio;
	public Color Spanish;


	void Start () {
		//Get ChatID, Title, Date, ImageID, Subject

		DueDateText.GetComponent<Text>().text = "(On " + Date + ")";
		TitleText.GetComponent<Text>().text = Title;
		GroupImage.GetComponent<RawImage> ().texture = ImageID;

		switch (Subject) {
		case "Chemistry":
			gameObject.GetComponent<Image> ().color = chem;
			break;
		case "History":
			gameObject.GetComponent<Image> ().color = history;
			break;
		case "English":
			gameObject.GetComponent<Image> ().color = English;
			break;
		case "Math":
			gameObject.GetComponent<Image> ().color = Math;
			break;
		case "Biology":
			gameObject.GetComponent<Image> ().color = Bio;
			break;
		case "Spanish":
			gameObject.GetComponent<Image> ().color = Spanish;
			break;
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
