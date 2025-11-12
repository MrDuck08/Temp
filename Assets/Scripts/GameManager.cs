using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bugAmountText;

    int numberOfBugs = 0;
    [SerializeField] int howManyBuggsToWin = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddBuggs(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBuggs(int buggs)
    {
        numberOfBugs += buggs;

        bugAmountText.text = numberOfBugs.ToString();

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
}
