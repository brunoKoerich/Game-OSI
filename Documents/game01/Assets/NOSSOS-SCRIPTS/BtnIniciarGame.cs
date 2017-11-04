using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnIniciarGame : MonoBehaviour {

    [SerializeField] GameObject painelInicial;

    public void IniciarGame()
    {
        painelInicial = GameObject.FindGameObjectWithTag("PainelInicial");
        painelInicial.SetActive(false);
    }
}
