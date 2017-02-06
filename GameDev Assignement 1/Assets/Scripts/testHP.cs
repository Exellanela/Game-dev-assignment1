using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHP : MonoBehaviour {

	public Slider PlayerHPSlider;
	public Slider EnemyHPSlider;

	public GameObject gameOverCanvas;
	public GameObject Player;
	public GameObject Enemy;

	public int dmg2Player;

	void Update() {

		if (PlayerHPSlider.value <= 0) {
			gameOverCanvas.SetActive (true);
			Player.SetActive (false);
		} else {
			gameOverCanvas.SetActive (false);
		}

		if (EnemyHPSlider.value <= 0) {
			Destroy (Enemy);
		}
	}

	public void UpdatePlayerHP () {
		PlayerHPSlider.value -= 10;
	}





}
