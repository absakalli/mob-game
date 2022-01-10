using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerNameText, playerScoreText, nameTextPanel, scoreTextPanel;
    [SerializeField] private Image playerIconGame, playerIconPanel;
    [SerializeField] private Sprite[] icons;
    [SerializeField] private GameObject playerName;

    int kayitliKisiSayisi = 10;
    int playerScore;

    public enum panel { pic, pic1, pic2, pic3, pic4, pic5, pic6 }
    public panel hangiavatar;
    void Start()
    {
        if (!PlayerPrefs.HasKey("playerName"))
        {
            playerNameText.GetComponent<TMPro.TextMeshProUGUI>().text = "Mob-" + kayitliKisiSayisi;
            nameTextPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Mob-" + kayitliKisiSayisi;
        }
        else
        {
            WriteName();
        }
        if (!PlayerPrefs.HasKey("playerScore"))
        {
            playerScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "0";
            scoreTextPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "0";
        }
        else
        {
            playerScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = playerScore.ToString();
            scoreTextPanel.GetComponent<TMPro.TextMeshProUGUI>().text = playerScore.ToString();
        }
        if (!PlayerPrefs.HasKey("choosedAvatar"))
        {
            playerIconGame.sprite = icons[0];
            playerIconPanel.sprite = icons[0];
        }
        else
        {
            WriteAvatar();
        }
    }
    public void ChangeName()
    {
        PlayerPrefs.SetString("playerName", playerName.GetComponent<TMP_InputField>().text);
        WriteName();
    }
    void WriteName()
    {
        playerNameText.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("playerName");
        nameTextPanel.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("playerName");
    }
    private void AvatarSet(int i)
    {
        if (i == 0)
        {
            hangiavatar = panel.pic;
        }
        else if (i == 1)
        {
            hangiavatar = panel.pic1;
        }
        else if (i == 2)
        {
            hangiavatar = panel.pic2;
        }
        else if (i == 3)
        {
            hangiavatar = panel.pic3;
        }
        else if (i == 4)
        {
            hangiavatar = panel.pic4;
        }
        else if (i == 5)
        {
            hangiavatar = panel.pic5;
        }
        else if (i == 6)
        {
            hangiavatar = panel.pic6;
        }
    }
    public void ChangeAvatar(int i)
    {
        AvatarSet(i);
        switch (hangiavatar)
        {
            case panel.pic:
                PlayerPrefs.SetInt("choosedAvatar", 0);
                break;
            case panel.pic1:
                PlayerPrefs.SetInt("choosedAvatar", 1);
                break;
            case panel.pic2:
                PlayerPrefs.SetInt("choosedAvatar", 2);
                break;
            case panel.pic3:
                PlayerPrefs.SetInt("choosedAvatar", 3);
                break;
            case panel.pic4:
                PlayerPrefs.SetInt("choosedAvatar", 4);
                break;
            case panel.pic5:
                PlayerPrefs.SetInt("choosedAvatar", 5);
                break;
            case panel.pic6:
                PlayerPrefs.SetInt("choosedAvatar", 6);
                break;
        }
    }
    public void WriteAvatar()
    {
        if (PlayerPrefs.GetInt("choosedAvatar") == 0)
        {
            playerIconGame.sprite = icons[0];
            playerIconPanel.sprite = icons[0];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 1)
        {
            playerIconGame.sprite = icons[1];
            playerIconPanel.sprite = icons[1];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 2)
        {
            playerIconGame.sprite = icons[2];
            playerIconPanel.sprite = icons[2];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 3)
        {
            playerIconGame.sprite = icons[3];
            playerIconPanel.sprite = icons[3];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 4)
        {
            playerIconGame.sprite = icons[4];
            playerIconPanel.sprite = icons[4];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 5)
        {
            playerIconGame.sprite = icons[5];
            playerIconPanel.sprite = icons[5];
        }
        else if (PlayerPrefs.GetInt("choosedAvatar") == 6)
        {
            playerIconGame.sprite = icons[6];
            playerIconPanel.sprite = icons[6];
        }
    }
}
