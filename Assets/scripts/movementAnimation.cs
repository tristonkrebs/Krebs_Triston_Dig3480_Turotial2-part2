using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAnimation : MonoBehaviour
{
	
	public float speed;
	public float start;
	public float end;
	private bool reverse;
	

	void flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Start()
	{
		reverse = false;
		flip();
	}

	void Update()
	{
		Vector3 loc = transform.localPosition;

		
		
			if (reverse)
			{
				loc = new Vector3(loc.x - (1 * speed), loc.y, loc.z);

				if (loc.x <= start)
				{
					reverse = false;
					flip();
				}
			}

			else
			{
				loc = new Vector3(loc.x + (1 * speed), loc.y, loc.z);

				if (loc.x >= end)
				{
					reverse = true;
					flip();
				}
			}
			transform.localPosition = loc;
		}

	}


