using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextosNPC : MonoBehaviour {

    //cria caixas de dialogo na unity para os textos
	public List<string> textos;

	private int posicaoAtual = 0; //contem os indices do array iniciando em 0

    // retorna as msgs escritas nas caixas de dialogos do script
    public string TextoAtual() {
        return this.textos[this.posicaoAtual];
	}

    //Função que chama proximo texto ao clicar no botão continuar
    public void Continuar() {
    	//verificando se tem proximo texto para exibir SENAO esconde o objeto com a tag PainelDeDialogos
		if (this.posicaoAtual < (this.textos.Count - 1)) {
            this.posicaoAtual++;
       	}else {
            GameObject.FindGameObjectWithTag("PainelDeDialogos").SetActive(false);
    	}
    }
    //Função que reinicia dialogos, colocando o indice do array em 0
    public void ReiniciarDialogo() {
        this.posicaoAtual = 0;
    }

}
