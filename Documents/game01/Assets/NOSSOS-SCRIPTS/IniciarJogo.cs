using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJogo : MonoBehaviour {

	[SerializeField] private GameObject painelInicial;

    public void Iniciar() {
        painelInicial = GameObject.FindGameObjectWithTag("PainelInicial");
        painelInicial.SetActive(false);
    }
}
