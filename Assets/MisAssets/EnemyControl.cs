using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour {

	public float vel = -1f;
	Rigidbody2D rgb;
	Animator anim;

	public Slider slider;
	public Text txt;

	public int energy = 100;

	public GameObject bulletPrototype;

	void Start()
	{
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
    {
        if (energy <= 0)
        {
			energy = 0;
			anim.SetTrigger("Morir");
        }

		slider.value = energy;
		txt.text = energy.ToString();
    }

	void FixedUpdate()
	{
		Vector2 v = new Vector2(vel, 0);
		rgb.velocity = v;

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Caminar") && Random.value < 1f/ (60f * 3f))
		{
			anim.SetTrigger("Apuntar");
		}
		else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Apuntando"))
		{
            if (Random.value < 1f / 3f)
            {
				anim.SetTrigger("Disparar");
			}
			else
            {
				anim.SetTrigger("Caminar");
            }
		}
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		Flip();
    }

	void Flip()
    {
		vel *= -1;

		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
    }

	public void Disparar()
    {
		anim.SetTrigger("Apuntar");
    }

    public void EmitirBala()
    {
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3(-1f, transform.position.y, -1f);
        bulletCopy.GetComponent<ControlBala>().direction = new Vector3(transform.localScale.x, 0, 0);

        energy--;
    }
}
