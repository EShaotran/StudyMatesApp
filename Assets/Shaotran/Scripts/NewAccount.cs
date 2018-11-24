using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class NewAccount : MonoBehaviour {
	public GameObject EmailFieldText;
	public GameObject PasswordFieldText;
	Animator anim;

	Firebase.Auth.FirebaseAuth auth;

	string emailtext;
	string pwtext;

	string currentEmail;

	DatabaseReference reference;


	// Use this for initialization
	void Start () {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		anim = GetComponent<Animator> ();


		// Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://thetwoethans.firebaseio.com/");

		// Get the root reference location of the database.
		reference = FirebaseDatabase.DefaultInstance.RootReference;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateButtonClicked () {
		bool FieldsFull = (EmailFieldText.GetComponent<Text>().text != "") && (PasswordFieldText.GetComponent<Text>().text != "");

		if (FieldsFull) {
			emailtext = EmailFieldText.GetComponent<Text> ().text;
			pwtext = PasswordFieldText.GetComponent<Text> ().text;
			CreateAccount (emailtext, pwtext);
		}

		Invoke ("ChangeToLoggedIn",2);

	}

	public void CreateAccount (string email, string password) {
		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				return;
			}

			// Firebase user has been created.
			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
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

			writeNewUser (uid, name, currentEmail);

			SceneManager.LoadScene ("Home");
		}
	}

	public void SignToCreateTransition () {
		anim.SetTrigger ("Animate");
	}

	public void CancelNewAccount () {
		SceneManager.LoadScene ("Start");
	}

	private void writeNewUser(string userId, string name, string email) {
		string tstamp = System.DateTime.Now.ToString ();
		User user = new User(name, email, userId, tstamp);
		string json = JsonUtility.ToJson(user);

		reference.Child("users").SetRawJsonValueAsync(json);
	}
		
}

public class User {
	public string username;
	public string email;
	public string UID;
	public string timestamp;

	public User() {
	}

	public User(string username, string email, string UID, string timestamp) {
		this.username = username;
		this.email = email;
		this.UID = UID;
		this.timestamp = timestamp;
	}
}