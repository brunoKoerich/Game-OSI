using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaineisSevProtInterf : MonoBehaviour {
    //criando um obj para poder intancia-lo depois podendo asism exibir no game com SetActive(true)
    [SerializeField] private GameObject painelServicos;
    [SerializeField] private GameObject painelProtocolos;
    [SerializeField] private GameObject painelInterfaces;

    // Inicia escondendo os paineis
    public void Start () {
        //escondendo o painel
        painelServicos.SetActive(false);
        painelProtocolos.SetActive(false);
        painelInterfaces.SetActive(false);
    }
	
	// Exibe ou esconde o painel Serviços ao clicar no botão serviços
	public void ExibeEscondePainelServicos () {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelServicos.activeSelf) {
             painelServicos.SetActive(false);
        } else { // se não exibe o painel
            painelServicos.SetActive(true);
            //escondendo os demais caso estejam abertos
            painelProtocolos.SetActive(false);
            painelInterfaces.SetActive(false);
        }
    }

    // Exibe ou esconde o painel Protocolo ao clicar no botão protocolo
    public void ExibeEscondePainelProtocolos() {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelProtocolos.activeSelf) {
            painelProtocolos.SetActive(false);
        } else { // se não exibe o painel
            painelProtocolos.SetActive(true);
            //escondendo os demais caso estejam abertos
            painelInterfaces.SetActive(false);
            painelServicos.SetActive(false);
        }
    }

    // Exibe ou esconde o painel Interface ao clicar no botão interface
    public void ExibeEscondePainelIntrefaces() {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelInterfaces.activeSelf) {
            painelInterfaces.SetActive(false);
        } else { // se não exibe o painel
            painelInterfaces.SetActive(true);
            //escondendo os demais caso estejam abertos
            painelServicos.SetActive(false);
            painelProtocolos.SetActive(false);
        }
    }
}
