using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ManagerAudio").AddComponent<AudioManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private AudioSource audioSource;

    public AudioClip audioPrincipal;
    public AudioClip audioInGame;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;

        SceneManager.sceneLoaded += CambiarAudioSegunEscena;
        
        if (!audioSource.isPlaying)
        {
            ReproducirAudio(audioPrincipal);
        }
    }

    private void CambiarAudioSegunEscena(Scene escena, LoadSceneMode modo)
    {
        if (escena.name == "Cesar")
        {
            if (!audioSource.isPlaying || audioSource.clip != audioInGame)
            {
                ReproducirAudio(audioInGame);
            }
            
        }
    }

    private void ReproducirAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

