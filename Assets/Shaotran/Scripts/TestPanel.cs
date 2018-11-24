using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour {

	public int TESTID;
	public int SCHOOLID;
	public string CLASS;
	public string DayOfWeek;
	public string Date;
	public string TestTitle;
	public string TimeHrs;

	public Color Redish;
	public Color Greyish;

	public Color TanText;
	public Color PurpleText;

	//Main Text Objects - Front Level
	GameObject DOWObj;
	GameObject DateObj;
	GameObject TitleObj;

	//Circle Text Objects - Back
	public GameObject DateCircle;
	public GameObject TimeCircle;
	public GameObject Friend1;
	public GameObject Friend2;
	public GameObject Friend3;

	public int PanelState; //0=Default, 1=Opened
	public Animator anim;

	public void Start () {
		DOWObj = transform.GetChild (0).gameObject;
		DateObj = transform.GetChild (1).gameObject;
		TitleObj = transform.GetChild (2).gameObject;

		int rnd = Random.Range (0, 2);
		if (rnd == 0) {
			gameObject.GetComponent<Image> ().color = Redish;
			DOWObj.GetComponent<Text> ().color = TanText;
			DateObj.GetComponent<Text> ().color = TanText;
			TitleObj.GetComponent<Text> ().color = TanText;
		} else {
			gameObject.GetComponent<Image> ().color = Greyish;
			DOWObj.GetComponent<Text> ().color = PurpleText;
			DateObj.GetComponent<Text> ().color = PurpleText;
			TitleObj.GetComponent<Text> ().color = PurpleText;
		}

		UpdateField ();
	}

	public void UpdateField () {
		

		/*
		testID =; //Request ID;
		schoolID =; //Request School ID
		Class = ; //Request Class it is
		DayOfWeek = ;//Request Day of Week
		Date = ; //Request Date
		TestTitle = ;//RequestTitle
		*/


		DOWObj.GetComponent<Text>().text = DayOfWeek;
		DateObj.GetComponent<Text>().text = Date;
		TitleObj.GetComponent<Text>().text = TestTitle;

		DateCircle.GetComponent<Text>().text = Date;
		TimeCircle.GetComponent<Text>().text = TimeHrs;
		Friend1.GetComponent<Text>().text = "CG";
		Friend2.GetComponent<Text>().text = "ES";
		Friend3.GetComponent<Text>().text = "EH";
	}

	public void PanelClicked () {
		if (PanelState == 0) {
			PanelState = 1;
			anim.SetTrigger ("ShowBehind");
		} else if (PanelState == 1) {
			PanelState = 0;
			anim.SetTrigger ("HideBehind");
		}
			
	}

	public void MoveLeft () {
		anim.SetTrigger ("SwipeLeft");
	}

	public void MoveRight () {
		anim.SetTrigger ("SwipeRight");
	}
}
