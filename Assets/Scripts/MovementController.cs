using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementController : MonoBehaviour {

	public GameObject player;
	private Rigidbody rb;

	public float turnRate;

	public Slider speedSlider;
	public Slider angleSlider;

	private float forwardSpeed;

	private float currentHeading;
	private float currentAngle;

	// Use this for initialization
	void Start () {

		rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		setCurrentSpeed ();
		setCurrentHeading ();
		setCurrentAngle ();

	}

	void FixedUpdate()
	{
		rb.AddForce(transform.forward * forwardSpeed * Time.deltaTime, ForceMode.Force);
		turnToHeading ();
		turnToAngle ();
	}

	void LateUpdate () {
		forwardSpeed = speedSlider.value;
	}

	void turnToHeading(){
		float turnToApply = turnRate;

		if (isTurnCCW()) {
			rb.AddTorque (transform.up * -turnToApply * Time.deltaTime);
			if(headingDiff()>-15 && isTurnCCW()){
				Vector3 force = new Vector3(0,rb.angularVelocity.y,0);
				rb.AddTorque(force * -1f, ForceMode.Force);
			}
		} else {
			rb.AddTorque (transform.up * turnToApply * Time.deltaTime);
			if(headingDiff()<15 && !isTurnCCW()){
				Vector3 force = new Vector3(0,rb.angularVelocity.y,0);
				rb.AddTorque(force * -1f, ForceMode.Force);
			}
		}
	}


	void turnToAngle(){
		float turnToApply = turnRate;

		if (isAngleUp()) {
			rb.AddTorque (transform.right * -turnToApply * Time.deltaTime);
			if(angleDiff()>-15 && isAngleUp()){
				Vector3 force = new Vector3(rb.angularVelocity.x,0,0);
				rb.AddTorque(force * -1f, ForceMode.Force);
			}
		} else {
			rb.AddTorque (transform.right * turnToApply * Time.deltaTime);
			if(angleDiff()<15 && !isAngleUp()){
				Vector3 force = new Vector3(rb.angularVelocity.x,0,0);
				rb.AddTorque(force * -1f, ForceMode.Force);
			}
		}
	}

	void rollIntoTurn(){

	}

	
	void setCurrentSpeed(){
		Vector3 speed = rb.velocity;
		float mag = speed.magnitude;
		CourseInfo.currentSpeed = mag;
	}

	void setCurrentHeading(){
		Vector3 curHeadingVector = rb.transform.forward;
		currentHeading = Quaternion.LookRotation (curHeadingVector).eulerAngles.y;
		CourseInfo.currentHeading = currentHeading;
	}

	void setCurrentAngle(){
		Vector3 curHeadingVector = rb.transform.forward;
		currentAngle = Quaternion.LookRotation (curHeadingVector).eulerAngles.x;
		CourseInfo.currentAngle = currentAngle;
	}

	float getCurrentAngle(){
		return CourseInfo.currentAngle;
	}

	float getDesiredAngle(){
		return CourseInfo.desiredAngle;
	}

	float getCurrentHeading(){
		return CourseInfo.currentHeading;
	}

	float getDesiredHeading(){
		return CourseInfo.desiredHeading;
	}

	float angleDiff(){
		float diff = (Mathf.DeltaAngle(getCurrentAngle(), getDesiredAngle()));
		return diff;
	}

	float headingDiff(){
		float diff = (Mathf.DeltaAngle(getCurrentHeading(),getDesiredHeading()));
		return diff;
	}

	bool isTurnCCW (){
		float diff = getDesiredHeading () - getCurrentHeading ();
		return diff > 0 ? diff > 180 : diff >= -180;
	}

	bool isAngleUp(){
		float diff = getDesiredAngle () - getCurrentAngle ();
		return diff > 0 ? diff > 180 : diff >= -180;
	} 

















}
