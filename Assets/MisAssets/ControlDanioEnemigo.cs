using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDanioEnemigo : MonoBehaviour {
	Collider2D colliderEnem = null;
	public int delayBajarPuntosemnemigo = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Enemy") && colliderEnem == null)
        {
			colliderEnem = other;
			Invoke("BajarPuntosEnemigo", delayBajarPuntosemnemigo);
        }
    }
	
	void OnTriggerExit2D(Collider2D other)
    {
        if (other == colliderEnem)
        {
			colliderEnem = null;
			CancelInvoke("BajarPuntosEnemigo");
        }
    }

	void BajarPuntosEnemigo()
    {
		colliderEnem.gameObject.GetComponent<EnemyControl>().BajarPuntosPorOrcoCerca();
    }
}
