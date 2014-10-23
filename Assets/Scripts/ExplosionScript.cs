using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	void Start(){
		Invoke ("Die", 1f);
	}

	void Die(){
		Destroy (gameObject);
	}
}
