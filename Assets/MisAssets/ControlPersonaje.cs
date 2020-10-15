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

	bool inFire1 = false;
	public GameObject hacha = null;

	public int CostoGolpeAlAire = 1;
	
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		hacha = GameObject.Find("/orc (1)/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
	}

	void Update()
	{
        if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f)
        {
            if (inFire1 == false)
            {
				inFire1 = true;
				hacha.GetComponent<CircleCollider2D>().enabled = false;
				anim.SetTrigger("attack");
				energy -= CostoGolpeAlAire;
			}
        }
        else
        {
			inFire1 = false;
        }

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
