using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject birdLvlText, coinLvlText, birdLvlCoin, coinLvlCoin, playerCoin;
    [SerializeField] private GameObject birdDisableImg, coinDisableImg;
    [SerializeField] private Button birdUpButton, coinUpButton;

    ChooseBird chooseBird;
    MapManager mapManager;

    int b, c = 1;
    int blvlCoin, clvlCoin;
    public int coin;

    void Start()
    {
        //PlayerPrefs.SetInt("birdLvl", 10);
        //PlayerPrefs.SetInt("coin", 0);

        chooseBird = GameObject.FindObjectOfType<ChooseBird>();
        mapManager = GameObject.FindObjectOfType<MapManager>();
        LoadLevels();
        if (!PlayerPrefs.HasKey("birdLvl"))
        {
            PlayerPrefs.SetInt("birdLvl", 1);
        }
        if (!PlayerPrefs.HasKey("coinLvl"))
        {
            PlayerPrefs.SetInt("coinLvl", 1);
        }
        if (!PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", 0);
        }
    }
    public void BirdLvlUp()
    {
        b++;
        PlayerPrefs.SetInt("birdLvl", b);
        birdLvlText.GetComponent<TMPro.TextMeshProUGUI>().text = b + " lvl";
        coin = int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) - blvlCoin;
        playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text = coin.ToString();
        PlayerPrefs.SetInt("coin", coin);
        playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text = coin.ToString();
        Debug.Log("centerpos: " + chooseBird.centerPos);
        Debug.Log("pointpos: " + chooseBird.pointPos);
        chooseBird.InstantiateBird(chooseBird.centerPos, PlayerPrefs.GetInt("birdLvl"));
        mapManager.BirdCountUpdate(PlayerPrefs.GetInt("birdLvl"));
        LvlCoin();
        CoinControl();
    }
    public void CoinLvlUp()
    {
        c++;
        PlayerPrefs.SetInt("coinLvl", c);
        coinLvlText.GetComponent<TMPro.TextMeshProUGUI>().text = c + " lvl";
        coin = int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) - clvlCoin;
        playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text = coin.ToString();
        PlayerPrefs.SetInt("coin", coin);
        LvlCoin();
        CoinControl();
    }
    void LoadLevels()
    {
        birdLvlText.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("birdLvl") + " lvl";
        coinLvlText.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("coinLvl") + " lvl";
        playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("coin").ToString();
        b = PlayerPrefs.GetInt("birdLvl");
        c = PlayerPrefs.GetInt("coinLvl");
        LvlCoin();
        CoinControl();
    }
    void LvlCoin()
    {
        blvlCoin = b * 100;
        clvlCoin = c * 100;
        birdLvlCoin.GetComponent<TMPro.TextMeshProUGUI>().text = blvlCoin + " Coin";
        coinLvlCoin.GetComponent<TMPro.TextMeshProUGUI>().text = clvlCoin + " Coin";
    }
    void CoinControl()
    {
        if (int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) >= blvlCoin &&
            int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) >= clvlCoin)
        {
            birdUpButton.interactable = true;
            coinUpButton.interactable = true;
            birdDisableImg.SetActive(false);
            coinDisableImg.SetActive(false);
        }
        else if (int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) >= blvlCoin &&
           int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) < clvlCoin)
        {
            birdUpButton.interactable = true;
            coinUpButton.interactable = false;
            birdDisableImg.SetActive(false);
            coinDisableImg.SetActive(true);
        }
        else if (int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) < blvlCoin &&
          int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) >= clvlCoin)
        {
            birdUpButton.interactable = false;
            coinUpButton.interactable = true;
            birdDisableImg.SetActive(true);
            coinDisableImg.SetActive(false);
        }
        else if (int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) < blvlCoin &&
          int.Parse(playerCoin.GetComponent<TMPro.TextMeshProUGUI>().text) < clvlCoin)
        {
            birdUpButton.interactable = false;
            coinUpButton.interactable = false;
            birdDisableImg.SetActive(true);
            coinDisableImg.SetActive(true);
        }

    }
}
