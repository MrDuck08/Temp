using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource hoverSound;
    [SerializeField] AudioSource talkingSound;
    [SerializeField] AudioSource collectBugSound;
    [SerializeField] private AudioFade mainMusic;
    [SerializeField] private AudioFade newMusic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverSound()
    {
        
        hoverSound.Play();
        
    }

    public void TalkingSound()
    {
        
        talkingSound.Play();
        
    }

    public void CollectBugSound()
    {
        
        collectBugSound.Play();
        
    }

    public void NewMusic()
    {

        mainMusic.StartFadeOut();

        newMusic.gameObject.GetComponent<AudioSource>().volume = 0;
        newMusic.gameObject.GetComponent<AudioSource>().Play();
        newMusic.StartFadeIn();
        
    }
}
