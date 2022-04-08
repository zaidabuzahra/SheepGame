using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip ShootClip;
    public AudioClip SheepHitClip;
    public AudioClip SheepDropClip;

    private Vector3 CamerPosition;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        CamerPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip Clip)
    {
        AudioSource.PlayClipAtPoint(Clip, CamerPosition);
    }

    public void PlayShootClip()
    {
        PlaySound(ShootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(SheepHitClip);
    }

    public void PlaySheepDropClip()
    {
        PlaySound(SheepDropClip);
    }
}
