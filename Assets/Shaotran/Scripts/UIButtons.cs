using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {
	Animator anim;
	public GameObject BackButtonMenu;
	public GameObject OffPlusButton;
	public GameObject NewButton; //For animating NewButton anims
	public GameObject mainObj;

	public GameObject TP1;
	public GameObject TP2;
	public GameObject TP3;
	public GameObject TP4;
	public GameObject TP5;
	public GameObject TP6;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		BackButtonMenu.SetActive (false);
		OffPlusButton.SetActive (false);
	}

	public void HomeButton () {
		anim.SetTrigger ("CloseMessages");
	}

	public void MessagesButton () {
		anim.SetTrigger ("OpenMessages");
	}

	public void MenuButton () {
		anim.SetTrigger ("OpenMenu");
		BackButtonMenu.SetActive (true);
	}

	public void ExitMenu () {
		anim.SetTrigger ("CloseMenu");
		BackButtonMenu.SetActive (false);
	}

	public void ProfileButton () {
		
	}

	public void LogOut () {
		Firebase.Auth.FirebaseAuth auth;
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.SignOut();
		SceneManager.LoadScene ("Start");
	}

	//PLUS BUTTONS:
	public void ClickedPlusButton () {
		NewButton.GetComponent<Animator>().SetTrigger ("Expand");
		OffPlusButton.SetActive (true);
	}
	public void ClickedOffPlusButton () {
		NewButton.GetComponent<Animator>().SetTrigger ("Shrink");
		OffPlusButton.SetActive (false);
	}

	public void CreateTestButton () {
		mainObj.GetComponent<Animator> ().SetTrigger ("MoveUp");
		NewButton.GetComponent<Animator> ().SetTrigger ("Disappear");
		Invoke ("Step1", 0.3f);
	}
	public void Step1 () {
		TP1.GetComponent<Animator> ().SetTrigger ("MoveLeft");
		Invoke ("Step2", 0.3f);
	}
	public void Step2 () {
		TP2.GetComponent<Animator> ().SetTrigger ("MoveRight");
		Invoke ("Step3", 0.3f);
	}
	public void Step3 () {
		TP3.GetComponent<Animator> ().SetTrigger ("MoveLeft");
		Invoke ("Step4", 0.3f);
	}
	public void Step4 () {
		TP4.GetComponent<Animator> ().SetTrigger ("MoveRight");
		Invoke ("Step5", 0.3f);
	}
	public void Step5 () {
		TP5.GetComponent<Animator> ().SetTrigger ("MoveLeft");
		Invoke ("Step6", 0.3f);
	}
	
	public void Step6 () {
		TP6.GetComponent<Animator> ().SetTrigger ("MoveRight");
	}


	//EXIT CREATING TEST:
	public void ExitCreateTest () {
		SceneManager.LoadScene ("Home");
	}
}
