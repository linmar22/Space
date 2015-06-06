using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CompassController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameObject player;
	private Rigidbody rb;

	public Image compassFace;
	//public Image compassTarget;
	public RectTransform compassCurrent;

	private RectTransform panel;
	private Vector2 pivotPoint = new Vector2(0,0);

	private float currentHeading;


	private bool mouseDown;
	private Vector3 clickMousePos;
	private Vector3 clickPos;


	void Start () {
		rb = player.GetComponent<Rigidbody>();
		panel = GetComponent<RectTransform>();
	}

	void Update () {
		updateCurrentHeading ();
	}

	void LateUpdate(){
		rotateCurrentHeadingNeedle ();
	}

	public void OnPointerDown(PointerEventData ped) 
	{
		mouseDown = true;
		clickPos = transform.position;
		clickMousePos = Input.mousePosition;
		//Debug.Log ("clickPos = " + clickPos + "   clickMousePos = " + clickMousePos);
		DebugPoint (ped);
	}
	
	public void OnPointerUp(PointerEventData ped) 
	{
		mouseDown = false;
	}

	void updateCurrentHeading(){
		Vector3 forwardVector = rb.transform.forward;
		currentHeading = Quaternion.LookRotation (forwardVector).eulerAngles.y;
	}

	void rotateCurrentHeadingNeedle(){
		compassCurrent.transform.rotation = Quaternion.Euler(0, 0, -currentHeading);
	}

	void DebugPoint(PointerEventData ped)
	{
		Vector2 localCursor;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle (GetComponent<RectTransform> (), ped.position, ped.pressEventCamera, out localCursor)) {
			return;
		}

		Vector2 mouseVec = localCursor - pivotPoint;
		float angle = Mathf.Atan2 (mouseVec.y, mouseVec.x);

		float degrees = angle * Mathf.Rad2Deg-90;

		if (degrees < 0) {
			degrees = degrees + 360;
		}
		Debug.Log ("Angle= " + ((degrees)-360)*-1);
	}
}
