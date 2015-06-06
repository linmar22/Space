using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompassController : MonoBehaviour {

	public GameObject player;
	private Rigidbody rb;

	public Image compassFace;
	public Image compassTarget;
	public Image compassCurrent;

	private RectTransform panel;
	private Vector2 pivotPoint;

	private float currentHeading;

	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody>();
		panel = GetComponent<RectTransform>();
		setPivotPoint ();
	}
	
	// Update is called once per frame
	void Update () {
		updateCurrentHeading ();
	}

	void setPivotPoint(){
		pivotPoint = new Vector2 (panel.rect.width/2, panel.rect.height/2);
	}

	void updateCurrentHeading(){
		Vector3 forwardVector = rb.transform.forward;
		currentHeading = Quaternion.LookRotation (forwardVector).eulerAngles.y;
	}

	void rotateCurrentHeadingNeedle(){
		compassCurrent.transform.RotateAround
	}
}
