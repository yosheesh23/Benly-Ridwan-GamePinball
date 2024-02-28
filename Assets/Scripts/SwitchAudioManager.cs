using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudioManager : MonoBehaviour
{
    public GameObject sfxAudioSource;

    public void PlaySwitchSFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, spawnPosition,Quaternion.identity);
    }
}
