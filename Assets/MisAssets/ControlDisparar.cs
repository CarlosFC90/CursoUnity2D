using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparar : MonoBehaviour {
	Collider2D disparandoO = null;
	public float probabilidadDeDisparo = 1f;

    EnemyControl crt;
	
	void Start () {
        crt = GameObject.Find("Enemy").GetComponent<EnemyControl>();
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("orc (1)") && disparandoO == null)
        {
            Disparar();
            disparandoO = other;
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
        crt.Disparar();
    }
}
