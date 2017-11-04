using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrigiBug : MonoBehaviour {

	[SerializeField] private Transform destino;
   
    // Update is called once per frame
    private void Update () {
		if (Input.GetKeyDown("b") && Input.GetKeyDown("u") && Input.GetKeyDown("g")) {
			this.ResetarPosicao();
		}
    }
    
    private void ResetarPosicao () {
	    Vector3 newPos = destino.position;
        Vector3 newPosCar = destino.position;
        newPos.y = 7.5f;
        newPosCar.y = 10.0f;
        GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
        GameObject.FindGameObjectWithTag("veiculo").transform.position = newPosCar;
    }
}
