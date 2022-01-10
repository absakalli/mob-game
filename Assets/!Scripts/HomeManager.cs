using DG.Tweening;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private GameObject coin, gameLogo, player, pointer, canvas, holdnmove;
    [SerializeField] private GameObject[] buttons;

    Sequence anim;
    ChooseBird chooseBird;

    private void Start()
    {
        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
        anim = DOTween.Sequence();
        anim.Append(pointer.GetComponent<Transform>().DOLocalMoveY(-190, 1.5f))
            .Append(pointer.GetComponent<Transform>().DOLocalMoveY(145, 1.5f))
            .SetLoops(-1);
        holdnmove.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        buttons[0].GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        buttons[1].GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        buttons[2].GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        buttons[3].GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        buttons[4].GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        gameLogo.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        coin.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        player.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        chooseBird.InstantiateBird(chooseBird.centerPos, PlayerPrefs.GetInt("birdLvl"));
    }
    public void Click()
    {
        if (Input.GetMouseButton(0))
        {
            anim.Kill();
            canvas.SetActive(false);
        }
    }
}
