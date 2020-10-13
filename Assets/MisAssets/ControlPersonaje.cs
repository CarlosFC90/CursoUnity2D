using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPersonaje : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	public float maxVel = 5f;
	bool haciaDerecha = true;

	public Slider slider;
	public Text txt;

	public int energy = 100;
	
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		slider.value = energy;
		txt.text = energy.ToString();
	}


	void FixedUpdate () {
		float v = Input.GetAxis("Horizontal");
		Vector2 vel = new Vector2(0, rgb.velocity.y);
		v *= maxVel;
		vel.x = v;
		rgb.velocity = vel;

		anim.SetFloat("speed", vel.x);

        if (haciaDerecha && v < 0)
        {
			haciaDerecha = false;
			Flip();
        } 
		else if(!haciaDerecha && v > 0)
        {
			haciaDerecha = true;
			Flip();
        }

	}
	void Flip()
	{
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}
