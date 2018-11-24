using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backup : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void BackupUsed () {
		SceneManager.LoadScene ("Home");
	}
}