using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float speed;
	public float jumpforce;

    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
	private void FixedUpdate()
	{
		float moveHorizotal = Input.GetAxis("Horizontal");
		

		Vector2 movement = new Vector2(moveHorizotal, 0);

		rb2d.AddForce(movement * speed);

		if (Input.GetKey("escape"))
			Application.Quit();
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.collider.tag == "ground")
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
			}
		}
	}
}
