using UnityEngine;

public class GameManager : MonoBehaviour
{
    ChooseBird chooseBird;
    FinishManager finishManager;

    private void Awake()
    {
        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
        finishManager = GameObject.FindObjectOfType<FinishManager>();
    }
    void GameLose()
    {
        if (chooseBird.clones.Count == 0 && finishManager.finishCounter == 0)
        {
            //lose game panel
        }
    }
}
