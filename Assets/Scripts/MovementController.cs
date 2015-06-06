using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementController : MonoBehaviour {

	public GameObject player;
	private Rigidbody rb;

	public float turnRate;

	public Slider speedSlider;
	public Slider headingSlider;

	private float forwardSpeed;

	private float currentHeading;

	// Use this for initialization
	void Start () {
		//////SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
		STATICINFOCLASS.InfoHolder = "Yo dawg";

		rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
		print (STATICINFOCLASS.InfoHolder);
		setCurrentHeading ();
	}

	void FixedUpdate()
	{
		rb.AddForce(transform.forward * forwardSpeed * Time.deltaTime, ForceMode.Force);
		turnToHeading ();

	}

	void LateUpdate () {
		forwardSpeed = speedSlider.value;
	}

	void turnToHeading(){
		float turnToApply = turnRate;

		if (headingDiff () < 50) {
			turnToApply = turnRate/2;
		}
		if (isTurnCCW()) {
			rb.AddTorque (transform.up * -turnToApply * Time.deltaTime);
		} else {
			rb.AddTorque (transform.up * turnToApply * Time.deltaTime);
		}
	}

	void setCurrentHeading(){
		Vector3 curHeadingVector = rb.transform.forward;
		currentHeading = Quaternion.LookRotation (curHeadingVector).eulerAngles.y;
	}

	float getCurrentHeading(){
		return currentHeading;
	}

	float getDesiredHeading(){
		return headingSlider.value;
	}

	float headingDiff(){
		float diff = (Mathf.DeltaAngle(getCurrentHeading(),getDesiredHeading()));
		return diff;
	}

	bool isTurnCCW (){
		float diff = getDesiredHeading () - getCurrentHeading ();

		return diff > 0 ? diff > 180 : diff >= -180;
	}















}
