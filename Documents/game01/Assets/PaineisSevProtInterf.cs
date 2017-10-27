using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaineisSevProtInterf : MonoBehaviour {
    //criando um obj para poder intancia-lo depois podendo asism exibir no game com SetActive(true)
    [SerializeField] GameObject painelServicos;
    [SerializeField] GameObject painelProtocolos;
    [SerializeField] GameObject painelInterfaces;

    // Inicia escondendo os paineis
    public void Start () {
        //astribuindo o obj com a tag PainelServico no obj "painelServicos"
        painelServicos = GameObject.FindGameObjectWithTag("PainelServico");
        painelProtocolos = GameObject.FindGameObjectWithTag("PainelProtocolo");
        painelInterfaces = GameObject.FindGameObjectWithTag("PainelInterface");
        //escondendo o painel
        painelServicos.SetActive(false);
        painelProtocolos.SetActive(false);
        painelInterfaces.SetActive(false);
    }
	
	// Exibe ou esconde o painel Serviços ao clicar no botão serviços
	public void ExibeEscondePainelServico () {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelServicos.activeSelf)
         {
             painelServicos.SetActive(false);
        } // se não exibe o painel
         else
         {
            painelServicos.SetActive(true);
         }
   
    }

    // Exibe ou esconde o painel Protocolo ao clicar no botão protocolo
    public void ExibeEscondePainelProtocolo()
    {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelProtocolos.activeSelf)
        {
            painelProtocolos.SetActive(false);
        } // se não exibe o painel
        else
        {
            painelProtocolos.SetActive(true);
        }

    }

    // Exibe ou esconde o painel Interface ao clicar no botão interface
    public void ExibeEscondePainelIntreface()
    {
        //activeSelf retorna o valor boleano do obj - se o painel estiver aberto esconde
        if (painelInterfaces.activeSelf)
        {
            painelInterfaces.SetActive(false);
        } // se não exibe o painel
        else
        {
            painelInterfaces.SetActive(true);
        }

    }
}
