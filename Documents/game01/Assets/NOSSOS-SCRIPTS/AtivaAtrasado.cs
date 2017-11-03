using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaAtrasado : MonoBehaviour {

	public int segundos;
	public GameObject objeto;

	private void Start () {
		StartCoroutine (this.Ativa());
	}

	private IEnumerator Ativa() {
		yield return new WaitForSeconds(this.segundos);

		this.objeto.SetActive (true);
	}
}
