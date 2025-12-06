using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    [Header("Game FX")]
    [SerializeField] private AudioClip destroyHeliPlane; // helicopter + plane
    [SerializeField] private AudioClip destroyTroop;
    [SerializeField] private AudioClip destroyParachute;
    [SerializeField] private AudioClip turretFire;
    [SerializeField] private AudioClip planeBombDrop;
    [SerializeField] private AudioClip gameOver;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.PlayOneShot(clip);
    }

    // read-only getters so other scripts can still pass the clips to PlaySound()
    public AudioClip DestroyHeliPlane => destroyHeliPlane;
    public AudioClip DestroyTroop => destroyTroop;
    public AudioClip DestroyParachute => destroyParachute;
    public AudioClip TurretFire => turretFire;
    public AudioClip PlaneBombDrop => planeBombDrop;
    public AudioClip GameOver => gameOver;

}
