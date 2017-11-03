using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	private float horizontal, vertical;
	private GameObject caps;
	public GameObject bala;
	public Transform ponto;
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			return;
		}
		Movimentacao();
		CmdAtirar();
	}

	void Movimentacao(){
		horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 120.0f;
		vertical = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		transform.Rotate(0, horizontal, 0 );
		transform.Translate(0,0,vertical);
	}

	[Command]
	void CmdAtirar(){
		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject balaTeste = (GameObject)Instantiate(bala, ponto.position, ponto.rotation);
			balaTeste.GetComponent<Rigidbody>().velocity = balaTeste.transform.forward * 10;
			NetworkServer.Spawn(balaTeste);
			Destroy(balaTeste, 3.0f);
		}
	}

	public override void OnStartLocalPlayer(){
		caps = transform.Find("Capsule").gameObject;
		caps.GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
