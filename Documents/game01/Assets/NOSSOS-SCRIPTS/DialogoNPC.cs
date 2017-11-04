using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoNPC : MonoBehaviour {

    // Objeto que contem o painel de dialogo (Painel de dialogo foi arrastado na unity)
    public GameObject msgDialogo;
    // Objeto que contem o texto do dialogo (texto foi arrastado na unity)
    public Text msgTexto;
    //Botoes do Dialogo
    public Button btnContinuar;

    //Para verifical qual npc será o dialogo;
	private TextosNPC npcAtualTextos;

    private void Start() {
        //Inicialmente o painel começa false para não ser exibido
        msgDialogo.SetActive(false);
    }

    private void OnTriggerEnter(Collider col) {
		this.ChecarNPCPerto (col);
    }

    
	private void OnTriggerExit(Collider col) {
		this.ChecarNPCLonge (col);
    }

	//Função que verifica se o personagem entrou na area Trigger do NPC e entaõ exibe o painel de dialogo
	private void ChecarNPCPerto(Collider col) {
		// Painel so será exibido se o obj fou um NPC
		if (col.gameObject.tag == "npc") {
			//Pegar o dialogo do NPC que a trigger foi ativada
			npcAtualTextos = (TextosNPC) col.gameObject.GetComponent<TextosNPC>();
			// chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
			string msg = npcAtualTextos.TextoAtual();
			// atribui a msg ao texto que será exibido no painel
			msgTexto.text = msg;
			// exibe o painel
			msgDialogo.SetActive(true);
		}
	}

	//função para fecha caixa de dialogo ao sair da area trigger do NPC
	private void ChecarNPCLonge(Collider col) {
		// Painel so será exibido se o obj fou um NPC
		if (col.gameObject.tag == "npc") {
			//reinicia o dialogo para o indice 0 do array ao sair da trigger do npc
			npcAtualTextos.ReiniciarDialogo();
			// chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
			string msg = npcAtualTextos.TextoAtual();
			// atribui a msg ao texto que será exibido no painel
			msgTexto.text = msg;
			//O painel será exibido
		}

		msgDialogo.SetActive(false);
	}

    //Função para Percorre dialogo ao clicar no botão continuar
    public void Continuar() {
        if (npcAtualTextos != null) {
            //Pega o proximo indice do array das msg de dialogo, ao clicar no botão continuar
			npcAtualTextos.Continuar();
            // chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
            string msg = npcAtualTextos.TextoAtual();
            // atribui a msg ao texto que será exibido no painel
            msgTexto.text = msg;
        }
    }

    //Função para Percorre dialogo ao clicar no botão continuar
    public void Voltar()
    {
        if (npcAtualTextos != null)
        {
            //Pega o proximo indice do array das msg de dialogo, ao clicar no botão continuar
            npcAtualTextos.Voltar();
            // chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
            string msg = npcAtualTextos.TextoAtual();
            // atribui a msg ao texto que será exibido no painel
            msgTexto.text = msg;
        }
    }
}