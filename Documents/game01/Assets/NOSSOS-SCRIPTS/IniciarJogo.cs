using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJogo : MonoBehaviour {

	[SerializeField] private GameObject painelInicial;

    public void Iniciar() {
        this.painelInicial.SetActive(false);
    }
}
