using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteAgua : MonoBehaviour {
    /* Este script eu jogo na agua e a variavel destinoTrigger
       é o objeto que será usado como parametro para teleporta o
       jogador até o local onde o destinoTrigger estiver  */

    // variavel que recebe um obj e onde este obj estiver o jogador sera teleportado
    public Transform destinoTrigger;

	// função que teleporta o jogador se tocar na agua
	void OnTriggerEnter (Collider col) {
		if(col.transform.name == "Aluno")
        {
            Vector3 newPos = destinoTrigger.position;
            newPos.y = 7.5f;
            col.transform.position = newPos;
            Debug.Log("ola");
        }
	}
}
