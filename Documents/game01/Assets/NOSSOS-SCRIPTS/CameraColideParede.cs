using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColideParede : MonoBehaviour {

	[SerializeField] private Transform alvo;
	[SerializeField] private float mouseX = 0;
	[SerializeField] private float mouseY = 0;
	[SerializeField] private float distanciaCamera = 6;

	private RaycastHit hit = new RaycastHit();

	private void Update () {
		this.MovimentarCamera ();

        //se apertar tecla c muda distancia da camera para, 0 aproximando a visao em jogo
        if (Input.GetKeyDown("c")) {
            AproximarCamera();
        }
    }

	private void MovimentarCamera () {
		transform.RotateAround(alvo.position, transform.up, Input.GetAxis("Mouse X") * mouseX);
		transform.RotateAround(alvo.position, transform.right, Input.GetAxis("Mouse Y") * mouseY);

		Vector3 rotacao = transform.eulerAngles;
		rotacao.z = 0;
		transform.eulerAngles = rotacao;

		transform.position = alvo.position - transform.forward * distanciaCamera;

		if(Physics.Linecast(alvo.position, transform.position, out hit)) {
			transform.position = hit.point + transform.forward * 0.2f;
		}
	}

    private void AproximarCamera() {
        if (this.distanciaCamera == 6) {
            this.distanciaCamera = 0;
            //Para poder movimentar o mouse em Y
            this.mouseY = 2;
        } else {
            this.distanciaCamera = 6;
            //Travando o mouse em  Y
            this.mouseY = 0;
        }
           
    }
}
