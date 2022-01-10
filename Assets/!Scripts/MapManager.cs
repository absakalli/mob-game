using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] kenar, ic;
    [SerializeField] private GameObject outPreV, outPreH, outPreH1, finish, counter, pipesPos;
    [SerializeField] private GameObject birdCountChange;
    [SerializeField] private GameObject birdCountText;

    List<GameObject> objects = new List<GameObject>();
    List<GameObject> outs = new List<GameObject>();
    public List<GameObject> counts = new List<GameObject>();
    GameObject counterClone;

    System.Random _random = new System.Random();
    private Vector3 screen, centerPos;

    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        centerPos = new Vector3(screen.x - screen.x * 2 + 6, screen.y - screen.y + 0.3f, 0);
        InstantiateFrame();
        InstantiateMap();
        BirdCountUpdate(PlayerPrefs.GetInt("birdLvl"));
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            MoveMap();
            if (counterClone != null)
            {
                counterClone.SetActive(true);
            }
        }
    }
    void InstantiateFrame()
    {
        GameObject clone;
        clone = Instantiate(outPreV, new Vector3(screen.x - screen.x * 2 - 0.7f, 0, 0), Quaternion.identity);
        outs.Add(clone);
        clone = Instantiate(outPreH, new Vector3(0, screen.y - screen.y * 2 + 1.3f, 0), Quaternion.identity);
        outs.Add(clone);
        clone = Instantiate(outPreH, new Vector3(0, screen.y - 0.1f, 0), Quaternion.identity);
        outs.Add(clone);
        clone = Instantiate(outPreH1, new Vector3(screen.x - screen.x * 2, screen.y - 0.5f, 0), Quaternion.identity);
        clone = Instantiate(outPreH1, new Vector3(screen.x - screen.x * 2, screen.y - screen.y * 2 + 1.7f, 0), Quaternion.identity);
        for (int i = 0; i < 30; i++)
        {
            int random = _random.Next(0, 11);
            clone = Instantiate(kenar[random]
                , new Vector3(screen.x - screen.x * 2 + (4.92f * i), screen.y - 0.5f, 0)
                , Quaternion.Euler(0, 0, -90)
                , pipesPos.GetComponent<Transform>());
            objects.Add(clone);
            clone = Instantiate(kenar[random]
                , new Vector3(screen.x - screen.x * 2 + (4.92f * i), screen.y - screen.y * 2 + 1.7f, 0)
                , Quaternion.Euler(180, 0, -90)
                , pipesPos.GetComponent<Transform>());
            objects.Add(clone);
        }
    }
    void InstantiateMap() //Geliþtirilmesi gerekiyor
    {
        GameObject clone;
        counterClone = Instantiate(counter
            , centerPos
            , Quaternion.Euler(0, 0, -90));
        for (int i = 1; i <= 15; i++)
        {
            if (i % 4 == 0)
            {
                clone = Instantiate(birdCountChange
                    , new Vector3(screen.x - screen.x + (9.84f * (i - 1)), screen.y - screen.y + 0.6f, 0)
                    , Quaternion.identity);
                counts.Add(clone);
                clone.GetComponentInChildren<InManager>().transform.position = new Vector3(screen.x - screen.x + (9.84f * (i - 2.5f)), 0, 0);
            }
            else if (i == 15)
            {
                /*clone = Instantiate(finish
                    , new Vector3(screen.x - screen.x + (9.84f * (i - 1)), screen.y - screen.y, 0)
                    , Quaternion.identity);
                objects.Add(clone);*/
                clone = Instantiate(finish
                    , new Vector3(screen.x - screen.x + 3, screen.y - screen.y, 0)
                    , Quaternion.identity);
                objects.Add(clone);
            }
            else
            {
                clone = Instantiate(ic[_random.Next(0, 5)]
                     , new Vector3(screen.x - screen.x + (9.84f * (i - 1)), screen.y - _random.Next(4, 8), 0)
                     , Quaternion.identity
                     , pipesPos.GetComponent<Transform>());
                objects.Add(clone);
            }
        }
    }
    public void MoveMap()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
            }
        }
        foreach (GameObject count in counts)
        {
            if (count != null)
            {
                count.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
            }
        }
    }
    public void WriteCountChange(CountManager count1, CountManager count2, int birdCount)
    {
        if (birdCount > 0 && birdCount < 10)
        {
            int random = _random.Next(6, 11);
            int random1 = _random.Next(6, 11);
            while (random == random1)
            {
                random1 = _random.Next(6, 11);
            }
            count1.InitCount(CountManager.countType.multi, random);
            count2.InitCount(CountManager.countType.multi, random1);
        }
        if (birdCount >= 10 && birdCount < 30)
        {
            int random = _random.Next(4, 7);
            int random1 = _random.Next(4, 7);
            int random2 = _random.Next(0, 100);
            while (random == random1)
            {
                random1 = _random.Next(4, 7);
            }
            if (random2 < 25)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else if (random2 >= 25 && random2 < 50)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
            else if (random2 >= 50 && random2 < 75)
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
        }
        else if (birdCount >= 30 && birdCount < 50)
        {
            int random = _random.Next(2, 5);
            int random1 = _random.Next(2, 5);
            int random2 = _random.Next(0, 100);
            while (random == random1)
            {
                random1 = _random.Next(2, 5);
            }
            if (random2 < 25)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else if (random2 >= 25 && random2 < 50)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
            else if (random2 >= 50 && random2 < 75)
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
        }
        else if (birdCount >= 50 && birdCount < 100)
        {
            int random = _random.Next(2, 4);
            int random1 = _random.Next(2, 4);
            int random2 = _random.Next(0, 100);
            while (random == random1)
            {
                random1 = _random.Next(2, 4);
            }
            if (random2 < 25)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else if (random2 >= 25 && random2 < 50)
            {
                count1.InitCount(CountManager.countType.multi, random);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
            else if (random2 >= 50 && random2 < 75)
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.multi, random1);
            }
            else
            {
                count1.InitCount(CountManager.countType.plus, random * 10);
                count2.InitCount(CountManager.countType.plus, random1 * 10);
            }
        }
        else if(birdCount >= 100)
        {
            int random = _random.Next(-3, 0);
            int random1 = _random.Next(-3, 0);
            while (random == random1)
            {
                random1 = _random.Next(-3, 0);
            }
            count1.InitCount(CountManager.countType.minus, random * 10);
            count2.InitCount(CountManager.countType.minus, random1 * 10);
        }
    }
    public void BirdCountUpdate(int birdCount)
    {
        counterClone.GetComponentInChildren<TMPro.TextMeshPro>().text = birdCount.ToString();
    }
}
