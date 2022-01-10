using TMPro;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    private int birdCount;
    private ChooseBird chooseBird;
    private MapManager mapManager;
    private MoveManager moveManager;
    private TextMeshProUGUI countText;
    public Vector3 screen;

    public enum countType { plus, minus, multi }
    countType type;
    int count;

    private void Awake()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        countText = GetComponentInChildren<TextMeshProUGUI>();
        moveManager = FindObjectOfType<MoveManager>();
        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
        mapManager = GameObject.FindObjectOfType<MapManager>();
        birdCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird" && moveManager.hasEntered)
        {
            birdCount = chooseBird.clones.Count;
            moveManager.hasEntered = false;
            Vector3 centerPos = new Vector3(screen.x - screen.x * 2 + 4, screen.y - screen.y + 0.6f, 0);
            centerPos.y = transform.position.y;
            CollisionCount(centerPos);
        }
    }
    public void InitCount(countType type, int count)
    {
        this.type = type;
        this.count = count;
        switch (type)
        {
            case countType.plus:
                countText.text = "+" + count;
                break;
            case countType.minus:
                countText.text = "-" + Mathf.Abs(count);
                break;
            case countType.multi:
                countText.text = "x" + count;
                break;
            default:
                break;
        }
    }
    void CollisionCount(Vector3 centerPos)
    {
        switch (type)
        {
            case countType.plus:
                birdCount = birdCount + count;
                break;
            case countType.minus:
                birdCount = birdCount - Mathf.Abs(count);
                break;
            case countType.multi:
                birdCount = birdCount * count;
                break;
            default:
                break;
        }
        chooseBird.InstantiateBird(centerPos, birdCount);
        mapManager.BirdCountUpdate(birdCount);
    }
}
