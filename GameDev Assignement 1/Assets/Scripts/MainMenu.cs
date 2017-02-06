using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string level01;

	public void LevelLoad01() {
		SceneManager.LoadScene (level01);
	}
}