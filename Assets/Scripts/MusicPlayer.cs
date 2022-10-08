using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource music;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button switchButton;

    public static MusicPlayer Instance { get { return instance; } }
    private static MusicPlayer instance;

    private bool isPlaying;

    void Start()
    {
        isPlaying = true;
        music = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        StartCoroutine(MusicPlay());
    }


    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }


    public void SwitchButton()
    {
        if (volumeSlider.isActiveAndEnabled)
        {
            volumeSlider.enabled = false;
            volumeSlider.gameObject.SetActive(false);
        }
        else
        {
            volumeSlider.enabled = true;
            volumeSlider.gameObject.SetActive(true);
        }
    }


    IEnumerator MusicPlay()
    {
        yield return null;

        while (isPlaying)
        {

            music.clip = clips[UnityEngine.Random.Range(0, clips.Count)];
            music.Play();

            while (music.isPlaying)
            {
                yield return null;
            }
        }
    }


    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }
}

