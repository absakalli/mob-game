using UnityEngine;

public class OutManager : MonoBehaviour
{
    private ChooseBird chooseBird;
    private MapManager mapManager;

    private void Awake()
    {
        mapManager = GameObject.FindObjectOfType<MapManager>();
        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipes")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Count")
        {
            mapManager.counts.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            chooseBird.clones.Remove(collision.gameObject);
            mapManager.BirdCountUpdate(chooseBird.clones.Count);
            Destroy(collision.gameObject);
        }
    }
}
