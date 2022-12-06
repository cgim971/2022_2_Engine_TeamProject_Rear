using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class SoundManager : MonoBehaviour
{
    public static void PlayOnShot(SoundType soundType, string soundName)
    {
        GameObject go = new GameObject { name = $"{soundType}_{soundName}" };
        AudioSource audioSource = go.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>($"Sounds/{soundName}");
        audioSource.clip = clip;

        audioSource.PlayOneShot(clip);
    }

    public void Play()
    {

    }




}
