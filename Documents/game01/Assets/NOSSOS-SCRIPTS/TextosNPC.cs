﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TextosNPC : MonoBehaviour {

    //cria caixas de dialogo na unity para os textos
	[SerializeField] private List<string> textos;

	[SerializeField] private bool iniciaMissoes;

	//informa se o jogador já falou com o npc
	private bool conversou = false;

	private int posicaoAtual = 0; //contem os indices do array iniciando em 0

    // retorna as msgs escritas nas caixas de dialogos do script
    public string TextoAtual() {
        return this.textos[this.posicaoAtual];
	}

	public bool GetConversou() {
		return this.conversou;
	}

    //Função que chama proximo texto ao clicar no botão continuar
    public void Continuar() {
    	//verificando se tem proximo texto para exibir SENAO esconde o objeto com a tag PainelDeDialogos
		if (this.posicaoAtual < (this.textos.Count - 1)) {
            this.posicaoAtual++;
       	}else {	
			this.ReiniciarDialogo ();
            GameObject.FindGameObjectWithTag("PainelDeDialogos").SetActive(false);
    	}
    }


    //Função que chama proximo texto ao clicar no botão continuar
    public void Voltar() {
        //verificando se tem proximo texto para exibir SENAO esconde o objeto com a tag PainelDeDialogos
        if (this.posicaoAtual > 0) {
            this.posicaoAtual--;
        } else {
            this.ReiniciarDialogo();
            GameObject.FindGameObjectWithTag("PainelDeDialogos").SetActive(false);
        }
    }


    //Função que reinicia dialogos, colocando o indice do array em 0
    public void ReiniciarDialogo() {
        this.posicaoAtual = 0;
		this.conversou = true;

		if (this.iniciaMissoes) {
			GerenciaMissao gerenciaMissao = GameObject.FindObjectOfType<GerenciaMissao> ();
			if (gerenciaMissao == null) {
				Debug.Log ("Sem gerenciador de missões");
			} else {
				gerenciaMissao.IniciaMissoes ();
			}
		}
    }

}
