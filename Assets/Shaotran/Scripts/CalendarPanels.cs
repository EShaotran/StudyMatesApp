using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarPanels : MonoBehaviour {
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	public GameObject Panel4;
	public GameObject Panel5;
	public GameObject Panel6;

	// Use this for initialization
	void Start () {
		//Request for JSON
		//Convert to List
		System.Collections.Generic.List<int> testList = 
			new System.Collections.Generic.List<int>();
		int i = testList.Count;

		if (i >= 1)
			Panel1.GetComponent<TestPanel> ().UpdateField ();
		if (i >= 2)
			Panel2.GetComponent<TestPanel> ().UpdateField ();
		if (i >= 3)
			Panel3.GetComponent<TestPanel> ().UpdateField ();
		if (i >= 4)
			Panel4.GetComponent<TestPanel> ().UpdateField ();
		if (i >= 5)
			Panel5.GetComponent<TestPanel> ().UpdateField ();
		if (i >= 6)
			Panel6.GetComponent<TestPanel> ().UpdateField ();


	}

}
