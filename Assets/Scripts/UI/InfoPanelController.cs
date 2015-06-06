using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour {

	public GameObject player;
	private Rigidbody rb;

	public Text speedText;
	public Text targetVectorText;
	public Text currentVectorText;

	public Slider headingSlider;

	private Vector3 speed;
	private Vector3 forwardVector;

	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody>();
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
		speed = rb.velocity;
		float spfl = speed.magnitude;
		speedText.text = "Speed: " + spfl.ToString ("F2");
	}

	void setForwardVectorText(){
		forwardVector = rb.transform.forward;
		float heading = Quaternion.LookRotation (forwardVector).eulerAngles.y;
		currentVectorText.text = "Current Heading: " + heading.ToString ("0");
	}

	void setDesiredVectorText(){
		targetVectorText.text = "Target Heading: " + getDesiredHeading ().ToString ("0");
	}

	float getDesiredHeading(){
		return CourseInfo.desiredHeading;
	}
}
