using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounsmover : MonoBehaviour
{

	public float top;
	public float bottom;
	public float left;
	public float right;
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
		Vector3 position = new Vector3(Random.Range(left, right), Random.Range(bottom, top), 0);
		transform.localPosition = position;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 loc = transform.localPosition;
		Vector3 mov = new Vector3(Random.Range(-1, 1) * speed, Random.Range(-1, 1) * speed, 0);
		loc = new Vector3(loc.x + mov.x, loc.y + mov.y, 0);
		if (loc.x >= right)
			loc.x = right;
		if (loc.x <= left)
			loc.x = left;
		if (loc.y >= top)
			loc.y = top;
		if (loc.y <= bottom)
			loc.y = bottom;

		transform.localPosition = loc;
	}
}
