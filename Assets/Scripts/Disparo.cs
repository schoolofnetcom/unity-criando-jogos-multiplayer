using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {
	void OnTriggerEnter(Collider Jogador){
		Jogador.gameObject.transform.position = Vector3.zero;
		Jogador.gameObject.transform.rotation = Quaternion.identity;
	}
}
