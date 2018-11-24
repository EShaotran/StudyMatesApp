using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Firebase;
//using Firebase.Database;
//using Firebase.Unity.Editor;

public class LogIn : MonoBehaviour {
	public GameObject EmailFieldText;
	public GameObject PasswordFieldText;
	public GameObject WelcomeText;

	Firebase.Auth.FirebaseAuth auth;

	string emailtext;
	string pwtext;

	string currentEmail;


	// Use this for initialization
	void Start () {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	}

	// Update is called once per frame
	void Update () {
		//FirebaseApp.DefaultInstance.SetEditorDatabaseUrl
	}

	public void LogInButtonClicked () {
		bool FieldsFull = (EmailFieldText.GetComponent<Text>().text != "") && (PasswordFieldText.GetComponent<Text>().text != "");

		if (FieldsFull) {
			emailtext = EmailFieldText.GetComponent<Text> ().text;
			pwtext = PasswordFieldText.GetComponent<Text> ().text;
			LogInAccount (emailtext, pwtext);
		}

		Invoke ("ChangeToLoggedIn",2);

	}

	public void LogInAccount (string email, string password) {
		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
				WelcomeText.GetComponent<Text>().text = "Error";
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				WelcomeText.GetComponent<Text>().text = "Error";
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			Debug.Log("User ID: " + newUser.UserId);
		});
	}

	public void ChangeToLoggedIn() {
		Firebase.Auth.FirebaseUser user = auth.CurrentUser;
		if (user != null) {
			string name = user.DisplayName;
			currentEmail = user.Email;
			System.Uri photo_url = user.PhotoUrl;
			// The user's Id, unique to the Firebase project.
			// Do NOT use this value to authenticate with your backend server, if you
			// have one; use User.TokenAsync() instead.
			string uid = user.UserId;

			SceneManager.LoadScene ("Home");

		}
	}

}
