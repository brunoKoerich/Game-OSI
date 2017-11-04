using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharJogo : MonoBehaviour {

	// Função que fecha o jogo ao clicar no botão
	public void Fechar () {
       // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
