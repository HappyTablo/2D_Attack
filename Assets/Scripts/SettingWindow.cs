using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
	private const string Mainvolume = "MainVolume";
	[SerializeField] private Slider _volume;
	[SerializeField] private Button _back;
	[SerializeField] private AudioMixer _mixer;

	private void OnEnable()
	{
		_back.onClick.AddListener(CloseSettingWindow);
		_volume.onValueChanged.AddListener(SetVolume);
	}

	private void SetVolume(float value) =>
		_mixer.SetFloat(Mainvolume, Mathf.Lerp(-80f, 0f, value));

	private void OnDisable() =>
		_back.onClick.RemoveListener(CloseSettingWindow);

	
	private void CloseSettingWindow() =>
		gameObject.SetActive(false);
}