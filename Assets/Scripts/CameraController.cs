using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public Transform target;

	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	void Update(){
		transform.LookAt(target);
		transform.Translate (Vector3.right * Time.deltaTime);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}