using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Level 2"))
        {
            Application.LoadLevel(2);
        }

        // This line feeds "This is the tooltip" into GUI.tooltip
        GUI.Button(new Rect(200, 10, 100, 20), new GUIContent("Click me", "This is the tooltip"));

        // This line reads and displays the contents of GUI.tooltip
        GUI.Label(new Rect(200, 40, 100, 20), GUI.tooltip);
    }
}
