using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextosNPC : MonoBehaviour {
    //variavel que indica a quantidade de caixas de dialogos, configurar na unity
    public int qtdCaixasDialogo; //contem os indices do array iniciando em 0

    //cria caixas de dialogo na unity para os textos
    public string[] msg = {};

    // retorna as msgs escritas nas caixas de dialogos do script
    public string GetMsg() {
        return msg[qtdCaixasDialogo];
	}

    //Função que chama proximo texto ao clicar no botão continuar
    public void BtnCont()
    {
        //verificando se tem proximo texto para exibir SENAO esconde o objeto com a tag PainelDeDialogos
        if (qtdCaixasDialogo < (msg.Length-1))
       {
            qtdCaixasDialogo++;
       }else
        {
            GameObject.FindGameObjectWithTag("PainelDeDialogos").SetActive(false);
        }
    }
    //Função que reinicia dialogos, colocando o indice do array em 0
    public void ReiniciarDialogo()
    {
        qtdCaixasDialogo = 0;
    }

}//class
