using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
    [SerializeField]
    private int damage;
	// Use this for initialization
	void Start () {
        if (damage == 0) damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        ICharacter enemigo = collision.gameObject.transform.GetComponent<ICharacter>();
        if (enemigo != null)
        {
            enemigo.PerderVida(damage);
            
        }
            Destroy(gameObject);
    }
}
