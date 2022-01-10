using UnityEngine;
using System.Collections.Generic;

public class ChooseBird : MonoBehaviour
{
    [SerializeField] private GameObject[] birds;
    [SerializeField] private GameObject birdPos;

    private Transform birdParent;
    private int birdLvl;

    public List<GameObject> clones = new List<GameObject>();
    public Vector3 screen, centerPos;
    public float radiusX, radiusY;
    public Vector3 pointPos;

    public enum panel { bird1, bird2, bird3, bird4, bird5, bird6 }
    public panel hangiKus;

    private void Start()
    {
        birdLvl = PlayerPrefs.GetInt("birdLvl");
        birdParent = birdPos.GetComponent<Transform>().transform;
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        centerPos = new Vector3(screen.x - screen.x * 2 + 4, screen.y - screen.y + 0.6f, 0);
    }
    private void BirdSet(int i)
    {
        if (i == 1)
        {
            hangiKus = panel.bird1;
        }
        else if (i == 2)
        {
            hangiKus = panel.bird2;
        }
        else if (i == 3)
        {
            hangiKus = panel.bird3;
        }
        else if (i == 4)
        {
            hangiKus = panel.bird4;
        }
        else if (i == 5)
        {
            hangiKus = panel.bird5;
        }
        else if (i == 6)
        {
            hangiKus = panel.bird6;
        }
    }
    public void ChoosedBird(int i)
    {
        birdLvl = PlayerPrefs.GetInt("birdLvl");
        BirdSet(i);
        switch (hangiKus)
        {
            case panel.bird1:
                PlayerPrefs.SetString("choosedBird", "bird1");
                break;
            case panel.bird2:
                PlayerPrefs.SetString("choosedBird", "bird2");
                break;
            case panel.bird3:
                PlayerPrefs.SetString("choosedBird", "bird3");
                break;
            case panel.bird4:
                PlayerPrefs.SetString("choosedBird", "bird4");
                break;
            case panel.bird5:
                PlayerPrefs.SetString("choosedBird", "bird5");
                break;
            case panel.bird6:
                PlayerPrefs.SetString("choosedBird", "bird6");
                break;
        }
        InstantiateBird(centerPos, birdLvl);
    }
    public void SetPosition(Vector3 centerPos, int birdLvl, int i)
    {
        float pointNum = (i * 1.0f) / birdLvl;
        float angle = pointNum * Mathf.PI * 2;
        float x = Mathf.Sin(angle) * radiusX;
        float y = Mathf.Cos(angle) * radiusY;
        pointPos = new Vector3(x, y) + centerPos;
    }
    public void InstantiateBird(Vector3 centerPos, int birdLvl)
    {
        centerPos = this.centerPos;
        GameObject clone;
        DestroyBird();
        if (PlayerPrefs.HasKey("choosedBird"))
        {
            if (PlayerPrefs.GetString("choosedBird") == "bird1")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[0], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
            else if (PlayerPrefs.GetString("choosedBird") == "bird2")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[1], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
            else if (PlayerPrefs.GetString("choosedBird") == "bird3")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[2], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
            else if (PlayerPrefs.GetString("choosedBird") == "bird4")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[3], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
            else if (PlayerPrefs.GetString("choosedBird") == "bird5")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[4], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
            else if (PlayerPrefs.GetString("choosedBird") == "bird6")
            {
                for (int i = 0; i < birdLvl; i++)
                {
                    SetPosition(centerPos, birdLvl, i);
                    clone = Instantiate(birds[5], pointPos, Quaternion.identity, birdParent);
                    clones.Add(clone);
                }
            }
        }
        else
        {
            for (int i = 0; i < birdLvl; i++)
            {
                SetPosition(centerPos, birdLvl, i);
                clone = Instantiate(birds[0], pointPos, Quaternion.identity, birdParent);
                clones.Add(clone);
            }
            PlayerPrefs.SetString("choosedBird", "bird1");
        }
    }
    public void DestroyBird()
    {
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        clones.Clear();
    }
}

