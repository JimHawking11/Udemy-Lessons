using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {cell, panel, door_0, bed_0, cell_panel, door_1, bed_1, freedom};
	
	private States myState;
	private TextAsset curText;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
		changeState();
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		string methodName = "state_" + myState.ToString();
		this.SendMessage(methodName);
	}

	void changeState() {	
		//update textAsset object and set text object
		curText = Resources.Load(myState.ToString()) as TextAsset;
		text.text = curText.ToString();
	}
	
	// STATE FUNCTIONS
	
	void state_bed_0 () {		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
			changeState();
		}
	}
	
	void state_cell () {			
		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bed_0;
			changeState();
		} else if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.panel;
			changeState();
		}else if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.door_0;
			changeState();
		}
	}
	
	void state_door_0 () {		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
			changeState();
		}
	}
	
	void state_panel () {		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
			changeState();
		}else if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.cell_panel;
			changeState();
		}
	}
	
	
}
