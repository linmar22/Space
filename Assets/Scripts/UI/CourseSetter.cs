using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CourseSetter : MonoBehaviour {

	bool tabKeyDown;
	bool drawDesired;

	public Texture2D backgroundCompass;
	public Texture2D desiredArrow;
	public Texture2D currentArrow;

	private float mouseX;
	private float mouseY;

	private float desiredDegrees;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			mouseX=Input.mousePosition.x;
			mouseY=Screen.height - Input.mousePosition.y;
			tabKeyDown = true;
		}
		if (Input.GetKeyUp (KeyCode.Tab)) {
			tabKeyDown = false;
			drawDesired = false;
		}
	}

	void OnGUI(){
		if (tabKeyDown) {
			Vector2 pivot = new Vector2(mouseX,mouseY);

			GUI.backgroundColor = new Color(0,0,0,0);
			GUI.Box (new Rect(mouseX-100,mouseY-100, 200, 200), backgroundCompass);

			Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height-Input.mousePosition.y);
			Vector2 mouseVec = mouse - pivot;
			float angle = Mathf.Atan2 (mouseVec.y, mouseVec.x);
			float degrees = angle * Mathf.Rad2Deg-270+360;
			
			if (degrees < 0) {
				degrees = degrees+360;
			}
			if(degrees>360){
				degrees = degrees-360;
			}
			GUIUtility.RotateAroundPivot(degrees,pivot);
			GUI.Box	(new Rect(mouseX-100,mouseY-100, 200, 200), desiredArrow);
			GUIUtility.RotateAroundPivot(-degrees,pivot);
			if(Input.GetMouseButton(0)){

				desiredDegrees=degrees;
				drawDesired=true;

			}
			if(drawDesired){
				GUIUtility.RotateAroundPivot(desiredDegrees,pivot);
				GUI.Box	(new Rect(mouseX-100,mouseY-100, 200, 200), currentArrow);

				setCourse (desiredDegrees);
			}
		}
	}

	void setCourse(float deg){
		CourseInfo.desiredHeading = deg;
	}

	
}
