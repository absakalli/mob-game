using UnityEngine;

public class InManager : MonoBehaviour
{
    private ChooseBird chooseBird;
    private MapManager mapManager;
    private MoveManager moveManager;
    public CountManager countManager1;
    public CountManager countManager2;

    private void Awake()
    {
        moveManager = FindObjectOfType<MoveManager>();
        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
        mapManager = GameObject.FindObjectOfType<MapManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            mapManager.WriteCountChange(countManager1, countManager2, chooseBird.clones.Count);
            moveManager.hasEntered = true;
            Destroy(gameObject);
        }
    }
}
