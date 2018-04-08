using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject focus;
    public float leadSpace;
    public float transitionTime;
    public bool followTarget;

    private Vector3 focusPosition;

	// Use this for initialization
	void Start () {
        followTarget = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (followTarget)
        {
            focusPosition = new Vector3(focus.transform.position.x, transform.position.y, transform.position.z);

            if (focus.transform.localScale.x > 0f)
            {
                focusPosition = new Vector3(focusPosition.x + leadSpace, focusPosition.y, focusPosition.z);
            }
            else
            {
                focusPosition = new Vector3(focusPosition.x - leadSpace, focusPosition.y, focusPosition.z);
            }

            //transform.position = focusPosition;

            transform.position = Vector3.Lerp(transform.position, focusPosition, transitionTime * Time.deltaTime);
        }
	}
}
