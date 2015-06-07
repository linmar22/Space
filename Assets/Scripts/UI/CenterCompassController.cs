using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CenterCompassController : MonoBehaviour {

	public RectTransform compassFace;
	public Text headingText;
	public Text desiredHeadingText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		changeHeadingText ();
		changeDesHeadingText ();
		rotateCompass ();
	}

	void rotateCompass(){
		compassFace.transform.rotation = Quaternion.Euler(0, 0, CourseInfo.currentHeading);
	}

	void changeHeadingText(){
		headingText.text = CourseInfo.currentHeading.ToString("0");
	}

	void changeDesHeadingText(){
		desiredHeadingText.text = CourseInfo.desiredHeading.ToString ("0");
	}
}
