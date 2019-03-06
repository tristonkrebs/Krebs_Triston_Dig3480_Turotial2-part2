using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
	public bool horizontal;
	public float speed;
	public float start;
	public float end;
	private bool reverse;

	void Start()
	{
		reverse = false;
	}

	void Update()
	{
		Vector3 loc = transform.localPosition;

		if (horizontal)
		{
			if (reverse)
			{
				loc = new Vector3(loc.x - (1 * speed), loc.y, loc.z);

				if (loc.x <= start)
					reverse = false;
			}

			else
			{
				loc = new Vector3(loc.x + (1 * speed), loc.y, loc.z);

				if (loc.x >= end)
					reverse = true;
			}

			transform.localPosition = loc;
		}
		else
		{
			if (reverse)
			{
				loc = new Vector3(loc.x, loc.y - (1 * speed), loc.z);

				if (loc.y <= start)
					reverse = false;
			}

			else
			{
				loc = new Vector3(loc.x, loc.y + (1 * speed), loc.z);

				if (loc.y >= end)
					reverse = true;
			}

			transform.localPosition = loc;
		}

	}


}

