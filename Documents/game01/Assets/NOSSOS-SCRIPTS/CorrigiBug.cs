using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrigiBug : MonoBehaviour {

    public Transform destino;
   

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("b") && Input.GetKeyDown("u") && Input.GetKeyDown("g"))
        {
            Vector3 newPos = destino.position;
            Vector3 newPosCar = destino.position;
            newPos.y = 7.5f;
            newPosCar.y = 10.0f;
            GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
            GameObject.FindGameObjectWithTag("veiculo").transform.position = newPosCar;
        }
    }
}
