using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	public int velocidade;
	public List<Item> itens;

	private Vector3 direcaoMovimento = Vector3.zero;

	private CharacterController controlador;

	private void Start() {
		this.controlador = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	private void Update () {
		this.Mover ();
	}

	private void Mover () {
		direcaoMovimento = new Vector3(0, 0, Input.GetAxis("Vertical"));
		direcaoMovimento = transform.TransformDirection(direcaoMovimento);
		direcaoMovimento *= velocidade;

		if (controlador.isGrounded == false) {
			direcaoMovimento += Physics.gravity;
		}

		controlador.Move(direcaoMovimento * Time.deltaTime);

		Vector3 rotateVector = new Vector3 (0, Input.GetAxis ("Horizontal"), 0);
		transform.Rotate (rotateVector);
	}
}
