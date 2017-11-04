using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissaoComObjetivosGUI : MonoBehaviour {

	public Text missaoTitulo;
	public VerticalLayoutGroup verticalLayout;

	private Missao missao;
	private List<MissaoObjetivoGUI> objetivosGUI = new List <MissaoObjetivoGUI> ();

	public void SetMissao(Missao missao) {
		this.missao = missao;

		if (missao == null) {
			this.missaoTitulo.text = "Sem missão";
		} else {
			this.missaoTitulo.text = this.missao.GetTitulo();
		}

		this.LimparObjetivos ();
		this.AdicionarObjetivos ();
	}

	private void AdicionarObjetivos() {
		if (this.missao == null) {
			return;
		}

		List<MissaoObjetivo> objetivos = this.missao.GetObjetivos ();
		for (int i = 0; i < objetivos.Count; i++) {
			GameObject itemGameObject = (GameObject) Instantiate(Resources.Load("MissaoComObjetivosGUI/MissaoObjetivoGUI", typeof(GameObject)));
			itemGameObject.transform.SetParent (this.verticalLayout.transform);

			MissaoObjetivoGUI item = itemGameObject.GetComponent<MissaoObjetivoGUI> ();
			item.SetObjetivo (objetivos[i]);

			this.objetivosGUI.Add (item);
		}
	}

	private void LimparObjetivos() {
		// Remove todos os objetos filhos da lista de objetivos
		for (int i = 0; i < this.verticalLayout.transform.childCount; i++) {
			Destroy (this.verticalLayout.transform.GetChild(i).gameObject);
		}

		// Limpa referências dos objetivos
		this.objetivosGUI.Clear ();
	}
}
