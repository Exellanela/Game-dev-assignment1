using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanges: MonoBehaviour {

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	public string mainMenu;
	public string restart;


	void Update() {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			isPaused = !isPaused;
		}
	}


	public void Resume() {
		isPaused = false;
	}


	public void Quit() {
		SceneManager.LoadScene (mainMenu);
	}


	public void Restart() {
		SceneManager.LoadScene (restart);
	}

}
