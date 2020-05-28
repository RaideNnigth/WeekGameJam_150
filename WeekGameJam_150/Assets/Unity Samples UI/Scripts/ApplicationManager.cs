using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

	private void Awake()
	{
		FindObjectOfType<AudioManager>().Play("Main Menu Song");
	}

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void StartGame()
	{

		SceneManager.LoadScene(1);
	}
}
