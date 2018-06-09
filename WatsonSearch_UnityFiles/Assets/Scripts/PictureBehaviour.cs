 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBehaviour : MonoBehaviour {

    public Renderer QuadRenderer;
    private Vector3 DesiredPosition;

	// Use this for initialization
	void Start () {
        transform.LookAt(Camera.main.transform); /* So that image faces camera */
        Vector3 DesiredAngle = new Vector3(0, transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(DesiredAngle); /* Only transform on y-axis */

        /* To force into air upon generation */
        DesiredPosition = transform.localPosition;
        transform.localPosition += new Vector3(0, 20, 0); /* Add 20 to y */
    }
	
	// Update is called once per frame
	void Update () {
        /* In Start(), initial position of object = local position + 20, interpolated back down to deisred position here */
        transform.localPosition = Vector3.Lerp(transform.localPosition, DesiredPosition, Time.deltaTime * 4f);
	}

    public void LoadImage(string url) {
        StartCoroutine(LoadImageFromURL(url));
    }

    IEnumerator LoadImageFromURL(string url) {
        WWW www = new WWW(url);
        yield return www;
        QuadRenderer.material.mainTexture = www.texture;
    }
}
