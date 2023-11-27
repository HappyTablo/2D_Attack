using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuWindow : MonoBehaviour
{
	private const string SceneName = "Game";
	[SerializeField] private Button _playButton;
	[SerializeField] private Button _settingsButton;
	[SerializeField] private Button _quitButton;
	[SerializeField] private GameObject _settingWindow;

	private void Start()
	{
		_playButton.onClick.AddListener(LoadGameScene);
		_settingsButton.onClick.AddListener(OpenSettingsWindow);
		_quitButton.onClick.AddListener(Quit);
	}

	private void LoadGameScene() =>
		SceneManager.LoadScene(SceneName);

	private void OpenSettingsWindow() =>
		_settingWindow.SetActive(true);

	private void Quit() =>
		Application.Quit();

	private void OnDestroy()
	{
		_playButton.onClick.RemoveListener(LoadGameScene);
		_settingsButton.onClick.RemoveListener(OpenSettingsWindow);
		_quitButton.onClick.RemoveListener(Quit);
	}

}