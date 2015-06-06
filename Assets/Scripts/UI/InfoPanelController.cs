using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour {
	
	public Text speedText;
	public Text targetVectorText;
	public Text currentVectorText;
	public Text currentAngleText;
	public Text targetAngleText;

	// Use this for initialization
	void Start () {
		setSpeedText();
		setForwardVectorText ();
		setDesiredVectorText ();
	}
	
	// Update is called once per frame
	void Update () {
		setSpeedText();
		setForwardVectorText ();
		setDesiredVectorText ();
	}

	void setSpeedText(){
		speedText.text = "Speed: " + (CourseInfo.currentSpeed * 100).ToString("0");
	}

	void setForwardVectorText(){
		currentVectorText.text = "Current Heading: " + CourseInfo.currentHeading.ToString("0");
	}

	void setDesiredVectorText(){
		targetVectorText.text = "Target Heading: " + CourseInfo.desiredHeading.ToString("0");
	}

	void setCurrentAngleText(){
		currentAngleText.text = "Current Angle: " + CourseInfo.currentAngle.ToString("0");
	}

	void setDesiredAngleText(){
		currentAngleText.text = "Target Angle: " + CourseInfo.desiredAngle.ToString("0");
	}



	float getDesiredHeading(){
		return CourseInfo.desiredHeading;
	}
}
