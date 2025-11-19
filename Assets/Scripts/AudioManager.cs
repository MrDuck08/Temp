using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource hoverSound;
    [SerializeField] AudioSource talkingSound;
    [SerializeField] AudioSource collectBugSound;
    
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
}
