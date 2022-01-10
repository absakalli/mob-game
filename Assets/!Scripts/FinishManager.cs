using DG.Tweening;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    ChooseBird chooseBird;
    public int finishCounter;
    private Vector3 screen, centerPos;
    Sequence anim;

    private void Awake()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        centerPos = new Vector3(screen.x - screen.x, screen.y - screen.y, 0);
        anim = DOTween.Sequence();
        chooseBird = GameManager.FindObjectOfType<ChooseBird>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            chooseBird.clones.Remove(collision.gameObject);
            finishCounter++;
            anim.Append(collision.gameObject.GetComponent<Transform>().DOLocalMove(
                    centerPos, 3f))
                    .Append(collision.gameObject.GetComponent<Transform>().DOScale(
                    new Vector3(0, 0, 0), 3f))
                    .Append(collision.gameObject.GetComponent<Transform>().DORotate(
                    new Vector3(0, 0, 45), 3f).OnComplete(EndSceen));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CountText")
        {
            Destroy(collision.gameObject);
        }
    }
    void EndSceen()
    {
        if (chooseBird.clones.Count == 0 && finishCounter != 0)
        {
            //win game panel
        }
    }
}
