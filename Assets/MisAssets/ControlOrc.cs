using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOrc : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	public float velMax = 5f;
	bool haciaDerecha = true;

	public Slider slider;
	public Text txt;

	public int energy = 100;

	bool enFire1 = false;
	public GameObject hacha = null;

	public int costoGolpeAlAire = 1;

	public bool Jumping = false;
	public float yJumpForce = 300;
	Vector2 jumpForce;

	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		hacha = GameObject.Find("/orc/orc_body/orc_R_arm/orc_R_hand/orc_weapon");

		jumpForce = new Vector2(0, 0);
	}

	void Update()
    {
		slider.value = energy;
		txt.text = energy.ToString();
    }

	public void HabilitarTriggerHacha()
    {
		hacha.GetComponent<CircleCollider2D>().enabled = true;
    }
	
	
	void FixedUpdate () {
		float v = Input.GetAxis("Horizontal");
		Vector2 vel = new Vector2(0, rgb.velocity.y);
		v *= velMax; 
		vel.x = v;
		rgb.velocity = vel;

		anim.SetFloat("speed", vel.x);

        if (haciaDerecha && v < 0)
        {
			haciaDerecha = false;
			Flip();
        }
        else if (!haciaDerecha && v>0)
        {
			haciaDerecha = true;
			Flip();
        }

        if (Input.GetAxis("Jump") > 0.01f)
        {
            if (!Jumping)
            {
				Jumping = true;
				jumpForce.x = 0f;
				jumpForce.y = yJumpForce;
				rgb.AddForce(jumpForce);
            }
			else
            {
				Jumping = false;
            }
        }
	}

	void Flip()
    {
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
    }
}
