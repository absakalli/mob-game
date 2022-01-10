using DG.Tweening;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject birdPanel, scorePanel, settingsPanel, playerPanel, avatarPanel, renamePanel;
    [SerializeField] private GameObject birdPanelImg, scorePanelImg, settingsPanelImg, playerPanelImg, avatarPanelImg, renamePanelImg;

    public enum panel { bird, score, settigs, player, avatarChange, nameChange }
    public panel hangiPanel;

    private void PanelSet(int i)
    {
        if (i == 0)
        {
            hangiPanel = panel.bird;
        }
        else if (i == 1)
        {
            hangiPanel = panel.score;
        }
        else if (i == 2)
        {
            hangiPanel = panel.settigs;
        }
        else if (i == 3)
        {
            hangiPanel = panel.player;
        }
        else if (i == 4)
        {
            hangiPanel = panel.avatarChange;
        }
        else if (i == 5)
        {
            hangiPanel = panel.nameChange;
        }
    }
    public void PanelOpen(int i)
    {
        PanelSet(i);
        switch (hangiPanel)
        {
            case panel.bird:
                birdPanel.SetActive(true);
                birdPanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                birdPanelImg.GetComponent<Transform>().DOScale(Vector3.one, 0.3f);
                break;
            case panel.score:
                scorePanel.SetActive(true);
                scorePanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                scorePanelImg.GetComponent<Transform>().DOScale(Vector3.one, 0.3f);
                break;
            case panel.settigs:
                settingsPanel.SetActive(true);
                settingsPanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                settingsPanelImg.GetComponent<Transform>().DOScale(Vector3.one, 0.3f);
                break;
            case panel.player:
                playerPanel.SetActive(true);
                playerPanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                playerPanelImg.GetComponent<Transform>().DOScale(Vector3.one, 0.3f);
                break;
            case panel.avatarChange:
                avatarPanel.SetActive(true);
                avatarPanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                avatarPanelImg.GetComponent<Transform>().DOScale(Vector3.one, 0.3f);
                break;
            case panel.nameChange:
                renamePanel.SetActive(true);
                renamePanelImg.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                renamePanelImg.GetComponent<Transform>().DOScale(new Vector3(1, 0.5f, 1), 0.3f);
                break;
        }
    }
    public void PanelClose()
    {
        switch (hangiPanel)
        {
            case panel.bird:
                birdPanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
                birdPanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.3f);
                birdPanel.SetActive(false);
                break;
            case panel.score:
                scorePanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                scorePanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.5f);
                scorePanel.SetActive(false);
                break;
            case panel.settigs:
                settingsPanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                settingsPanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.5f);
                settingsPanel.SetActive(false);
                break;
            case panel.player:
                playerPanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                playerPanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.5f);
                playerPanel.SetActive(false);
                break;
            case panel.avatarChange:
                avatarPanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                avatarPanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.5f);
                avatarPanel.SetActive(false);
                hangiPanel = panel.player;
                break;
            case panel.nameChange:
                renamePanelImg.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                renamePanelImg.GetComponent<Transform>().DOScale(Vector3.zero, 0.5f);
                renamePanel.SetActive(false);
                hangiPanel = panel.player;
                break;
        }
    }
}
