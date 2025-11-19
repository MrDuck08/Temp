using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioFade : MonoBehaviour
{
    private AudioSource source;
    GameManager gameManager;
    public float fadeInTargetVolume;
    public float fadeOutTargetVolume;
    public float fadeSpeed;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        
        gameManager = FindObjectOfType<GameManager>();

        fadeInTargetVolume = gameManager.volume;
    }
    public void StartFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine("DoFadeIn");
    }
    public void StartFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine("DoFadeOut");
    }
    private IEnumerator DoFadeIn()
    {
        while(source.volume != fadeInTargetVolume)
        {
            source.volume = Mathf.MoveTowards(source.volume, fadeInTargetVolume,
                fadeSpeed * Time.deltaTime);
            yield return null;
        }
        StopAllCoroutines();
    }
    private IEnumerator DoFadeOut()
    {
        while (source.volume != fadeOutTargetVolume)
        {
            source.volume = Mathf.MoveTowards(source.volume, fadeOutTargetVolume,
                fadeSpeed * Time.deltaTime);
            yield return null;
        }
        StopAllCoroutines();
    }
}