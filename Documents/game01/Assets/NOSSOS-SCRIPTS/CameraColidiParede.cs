using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColidiParede : MonoBehaviour {

    public Transform alvo;
    RaycastHit hit = new RaycastHit();
    public float mouseX = 0;
    public float mouseY = 0;
    public float distCam = 6;

    void Start () {
	}
	
	
	void Update () {
        transform.RotateAround(alvo.position, transform.up, Input.GetAxis("Mouse X") * mouseX);
        transform.RotateAround(alvo.position, transform.right, Input.GetAxis("Mouse Y") * mouseY);

        Vector3 rotacao = transform.eulerAngles;
        rotacao.z = 0;
        transform.eulerAngles = rotacao;

        transform.position = alvo.position - transform.forward * distCam;

        if(Physics.Linecast(alvo.position, transform.position, out hit))
        {
            transform.position = hit.point + transform.forward * 0.2f;
        }
        //se apertar tecla c muda distancia da camera para, 0 aproximando a visao em jogo
        if (Input.GetKeyDown("c"))
        {
            AproximaCamera();
        }
    }

    void AproximaCamera()
    {
        if (this.distCam == 6)
        {
            this.distCam = 0;
        }
        else
        {
            this.distCam = 6;
        }
           
    }
}//class
