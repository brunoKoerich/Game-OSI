using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteAgua : MonoBehaviour {
    /* Este script eu jogo na agua e a variavel destinoTrigger
       é o objeto que será usado como parametro para teleporta o
       jogador até o local onde o destinoTrigger estiver  */

    // variavel que recebe um obj e onde este obj estiver o jogador sera teleportado
    public Transform destino;

	// função que teleporta o jogador se tocar na agua
	private void OnTriggerEnter (Collider col) {
		this.ChecarJogadorEntrou (col);
	}

	private void ChecarJogadorEntrou (Collider col) {
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Veiculo") {
			Vector3 newPos = destino.position;
			newPos.y = 7.5f;
			col.transform.position = newPos;
			Debug.Log("ola");
		}
	}
}
