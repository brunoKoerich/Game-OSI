using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoNPC : MonoBehaviour
{

    // Objeto que contem o painel de dialogo (Painel de dialogo foi arrastado na unity)
    [SerializeField] GameObject msgDialogo;
    // Objeto que contem o texto do dialogo (texto foi arrastado na unity)
    [SerializeField] Text msgTexto;
    //Botoes do Dialogo
    [SerializeField] Button btnContinuar;
   // [SerializeField] Button btnFechar;

    //Para verifical qual npc será o dialogo;
    GameObject npcAtual;

    void Start()
    {
        //Inicialmente o painel começa false para não ser exibido
        msgDialogo.SetActive(false);
    }

    //Função que verifica se o personagem entrou na area Trigger do NPC e entaõ exibe o painel de dialogo
    void OnTriggerEnter(Collider other)
    {

        // Painel so será exibido se o obj fou um NPC
        if (other.name == "npc")
        {
            //Pegar o dialogo do NPC que a trigger foi ativada
            npcAtual = other.gameObject;
            // chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
            string msg = npcAtual.GetComponent<TextosNPC>().GetMsg();
            // atribui a msg ao texto que será exibido no painel
            msgTexto.text = msg;
            // exibe o painel
            msgDialogo.SetActive(true);
        }
    }

    //função para fecha caixa de dialogo ao sair da area trigger do NPC
    void OnTriggerExit(Collider other)
    {
        // Painel so será exibido se o obj fou um NPC
        if (other.name == "npc")
        {
            //reinicia o dialogo para o indice 0 do array ao sair da trigger do npc
            npcAtual.GetComponent<TextosNPC>().ReiniciarDialogo();
            // chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
            string msg = npcAtual.GetComponent<TextosNPC>().GetMsg();
            // atribui a msg ao texto que será exibido no painel
            msgTexto.text = msg;
            //O painel será exibido
        }
        msgDialogo.SetActive(false);
    }

    //Função para Percorre dialogo ao clicar no botão continuar
    public void BtnContinuar()
    {
        if (npcAtual)
        {
            //Pega o proximo indice do array das msg de dialogo, ao clicar no botão continuar
            npcAtual.GetComponent<TextosNPC>().BtnCont();
            // chama o metodo do script TextosNPC, o qual retorna a msg escrita na unity
            string msg = npcAtual.GetComponent<TextosNPC>().GetMsg();
            // atribui a msg ao texto que será exibido no painel
            msgTexto.text = msg;
        }
    }

    //Função para Fecha caixa de dialogo ao clicar no botao fechar////basta add o btn e adicionar a funcao de clique la na unit
   /* public void BtnFechar()
    {
        msgDialogo.SetActive(false);
    }*/
}