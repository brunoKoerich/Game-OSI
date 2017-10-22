using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaineisSevProtInterf : MonoBehaviour {
    //criando um obj para poder intancia-lo depois caso precise exibi-lo no game com SetActive(true)
    [SerializeField] GameObject painelServicos;

    // Inicia escondendo os paineis
    public void Start () {
        //astribuindo o obj com a tag PainelServico no obj "painelServicos"
        painelServicos = GameObject.FindGameObjectWithTag("PainelServico");
        //escondendo o painel
        painelServicos.SetActive(false);
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
}
