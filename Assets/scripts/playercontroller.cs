using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float speed;
	public float jumpforce;
	public Text countText;
	public Text WinText;
	private int count;
	public Text livestext;
	private bool stage2;
	public GameObject cam;
	private AudioSource[] source;
	private Animator anim;
	public Text timer;
	public float seconds;
	public float bonusspeed;
	public float bonusdur;
	private float bonusstart;
	private bool bonus;
	public Text bonustext;

	private int lives;

	void Start()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		count = 0;
		SetCountText();
		WinText.text = "";
		lives = 3;
		Setlivestext();
		source = GetComponents<AudioSource>();
		bonus = false;
		setTimerText();

	}

	void Update()
	{

	}

	private void FixedUpdate()
	{

		float moveHorizotal = Input.GetAxis("Horizontal");

		if (moveHorizotal < 0)
			anim.SetTrigger("runL");
		else if (moveHorizotal > 0)
			anim.SetTrigger("runR");
		else
			anim.SetTrigger("idle");

		Vector2 movement = new Vector2(moveHorizotal, 0);

		rb2d.AddForce(movement * speed);

		if (Input.GetKey("escape"))
			Application.Quit();
		setTimerText();
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.tag == "ground")
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				anim.SetTrigger("jump");
				rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
			source[2].Play();
		}
		if (other.gameObject.CompareTag("enemy"))
		{
			other.gameObject.SetActive(false);
			lives = lives - 1;
			Setlivestext();
		}
		if (other.gameObject.CompareTag("bonus"))
		{
			float hold = speed;
			speed = bonusspeed;
			bonusspeed = hold;
			other.gameObject.SetActive(false);
			bonusstart = Time.time;
			bonus = true;
			setTimerText();


		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >=4  && stage2 == false)
		{
			rb2d.transform.Translate(new Vector3(50, 0, 0));
			cam.transform.Translate(new Vector3(50, 0, 0));
			lives = 3;
			Setlivestext();
			stage2 = true;
		}

		if (stage2 && count >= 8)
		{
			WinText.text = "You Win!!";
			source[0].Pause();
			source[1].Play();

		}

	}
	void Setlivestext()
	{
		livestext.text = "lives: " + lives.ToString();
		if (lives == 0)
		{
			WinText.text = "You Lose";
			Destroy(rb2d);
		}
			
	}
	void setTimerText()
	{
		float local = seconds - Time.time;
		timer.text = "Seconds " + local.ToString("F0");
		if (local <=0)
		{
			WinText.text = "You Lose";
			timer.text = "Seconds 0";
			Destroy(rb2d);
		}
		if (bonus)
		{
			float hold = Time.time - bonusstart;
			if (hold >= bonusdur)
			{
				bonustext.text = "No Bonus";
				bonus = false;

				float slow = speed;
				speed = bonusspeed;
				bonusspeed = slow;

			}
			else
				bonustext.text = (bonusdur - hold).ToString("F0") +" Bonus time remaining";
		}
		else
			bonustext.text = "No Bonus";
	}

}
