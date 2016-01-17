using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	const int ONE_SECOND = 60;
	const int TIME_TO_WAIT = 4;
	
	private int max;
	private int min;
	private int guess;
	private int framesWaited;
	private int timeWaited;
	
	private bool isInStartUp = false;
	
	// Use this for initialization
	void Start () {
		//Set Framerate
		Application.targetFrameRate = ONE_SECOND;
		
		//Begin Game
		StartGame ();
	}

	void StartGame ()
	{
		isInStartUp = true;
		framesWaited = 0;
		timeWaited = 0;
		max = 1000;
		min = 1;
		guess = 500;
		
		//Start Up Text
		print ("========================");
		print ("Welcome to Number Wizard");
		print ("Pick a number from " + min + " to " + max + " in your head, but don't tell me!");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isInStartUp)
		{
			//Advance Time
			framesWaited++;
			
			//Advance One Second
			if(framesWaited >= ONE_SECOND)
			{
				print (".");
				timeWaited++;
				framesWaited = 0;
			}
			
			//End Startup
			if(timeWaited >= TIME_TO_WAIT)
			{
				isInStartUp = false;
				print ("OK got it?");
				NextGuess();
			}
		}else{
			if (Input.GetKeyDown (KeyCode.UpArrow))
			{
				min = guess + 1;
				//Validate for edge case
				if(min > max)
				{
					min = max;
				}
				NextGuess();
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow))
			{
				max = guess - 1;
				//Validate for edge case
				if(max < min)
				{
					max = min;
				}
				NextGuess();
			}
			else if (Input.GetKeyDown (KeyCode.Return))
			{
				print ("I Won!");
				StartGame ();
			} 
		} 
	}
	
	void NextGuess()
	{
		print ("**Range is " + min + " to " + max);
		
		guess = Random.Range(min, max + 1);
		print ("Is the number higher or lower then " + guess + "?");
		print ("UP = higher, DOWN = lower, RETURN = equals");
	}
}
