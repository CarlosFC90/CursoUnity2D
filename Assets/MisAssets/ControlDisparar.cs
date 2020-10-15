using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparar : MonoBehaviour {
	Collider2D disparandoO = null;
	public float probabilidadDeDisparo = 1f;

    public GameObject bulletPrototype;
	
	void Start () {
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("orc (1)") && disparandoO == null)
        {
			DecidaSiDispara(other);
        }
    }
	
	void OnTriggerExit2D(Collider2D other)
    {
        if (other == disparandoO)
        {
			disparandoO = null;
        }
    }

	void DecidaSiDispara(Collider2D other)
    {
        if (Random.value < probabilidadDeDisparo)
        {
            Disparar();
            disparandoO = other;
        }
    }

	void Disparar()
    {
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3( transform.parent.position.x, transform.parent.position.y, 0);
        bulletCopy.GetComponent<ControlBala>().direction = new Vector3(transform.localScale.x, 0, 0);

    }
}
