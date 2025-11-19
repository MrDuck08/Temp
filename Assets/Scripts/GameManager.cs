
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameObject intance;
    
    GameObject bugAmountText;

    int numberOfBugs = 0;
    [SerializeField] private int howManyBuggsToWin = 5;

    public float volume = 1;
    
    new List<AudioSource> audioSourceObjList2 = new List<AudioSource>();
    AudioSource[] audioSourceObjList;

    [SerializeField] Slider volumeSlider;

    DialogueScript dialogueScript;
    
    private void Awake()
    {

        if (intance == null)
        {
            
            intance = this.gameObject;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {

            intance.GetComponent<GameManager>().StartFake(); 
 
            Destroy(gameObject);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        audioSourceObjList = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        audioSourceObjList2.AddRange(audioSourceObjList);

        for (int i = 0; i < audioSourceObjList2.Count; i++)
        {

            audioSourceObjList2[i].volume = volume;

        }

        bugAmountText = GameObject.Find("BugText");
        
        AddBuggs(0);
    }

    public void StartFake()
    {

        bugAmountText = GameObject.Find("BugText");

        AddBuggs(0);

        audioSourceObjList2.Clear();
        
        audioSourceObjList = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        audioSourceObjList2.AddRange(audioSourceObjList);

        for (int i = 0; i < audioSourceObjList2.Count; i++)
        {

            audioSourceObjList2[i].volume = volume;

        }
        
    }

    public void AddBuggs(int buggs)
    {
        numberOfBugs += buggs;
        
        bugAmountText.GetComponent<TextMeshProUGUI>().text = numberOfBugs.ToString(); 

        if(numberOfBugs == 3)
        {

            dialogueScript = FindObjectOfType<DialogueScript>();

            dialogueScript.StartDialogue();

        }
    }

    public void CheckIfWin()
    { 

        if(numberOfBugs == howManyBuggsToWin)
        {

            ChangeScene(2);

        }

    }
    
    public void ChangeScene(int whatScene)
    {
        
        SceneManager.LoadScene(whatScene);
        
    }

    public void ChangeVolume()
    {

         volume = volumeSlider.value;
        
        for (int i = 0; i < audioSourceObjList2.Count; i++)
        {

            audioSourceObjList2[i].volume = volume;

        }

    }
}
