using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define.Sound;

public class SoundManager
{
    static AudioSource _bgmAudioSource;

    public static void PlayOneShot(string soundName)
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
        }

        GameObject go = new GameObject { name = $"Effect_{soundName}" };
        go.transform.SetParent(root.transform);

        AudioSource audioSource = go.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>($"Sounds/Effect/{soundName}");
        audioSource.clip = clip;
        audioSource.volume = PlayerPrefs.GetFloat(_effectVolume, 1);

        audioSource.PlayOneShot(clip);
    }

    public static void PlayBGM(AudioClip clip)
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
        }

        GameObject go = new GameObject { name = $"@Bgm_{clip.name}" };
        go.transform.SetParent(root.transform);

        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;

        _bgmAudioSource = audioSource;
        SetBgmVolume();

        _bgmAudioSource.Play();
    }

    public static void PlayBGM(string soundName)
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
        }

        AudioClip clip = Resources.Load<AudioClip>($"Sounds/Bgm/{soundName}");

        GameObject go = new GameObject { name = $"@Bgm_{clip.name}" };
        go.transform.SetParent(root.transform);

        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;

        _bgmAudioSource = audioSource;
        _bgmAudioSource.loop = true;
        SetBgmVolume();

        _bgmAudioSource.Play();
    }

    public static void BgmPause() => _bgmAudioSource.Pause();

    public static void BgmUnPause() => _bgmAudioSource.UnPause();

    public static void SetBgmVolume()
    {
        if (_bgmAudioSource != null)
            _bgmAudioSource.volume = PlayerPrefs.GetFloat(_bgmVolume, 1);
    }
}
