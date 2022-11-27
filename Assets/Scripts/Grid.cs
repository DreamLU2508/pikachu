using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int xGrid;
    public int yGrid;


    public GameObject prefabs;
    private List<Vector2Int> listVector2;

    public GamePikachu[,] pikachu;

    private int maxPikachu = 4;
    private int count = 0;
    private Type type;
    private Dictionary<Type, int> dictCountPikachu;

    private void Awake()
    {
        listVector2 = new List<Vector2Int>();

        for (int x = 0; x < xGrid; x++)
        {
            for (int y = 0; y < yGrid; y++)
            {
                listVector2.Add(new Vector2Int(x, y));
            }
        }

        dictCountPikachu = new Dictionary<Type, int>();
        foreach (Type foo in System.Enum.GetValues(typeof(Type)))
        {
            dictCountPikachu.Add(foo, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        pikachu = new GamePikachu[xGrid, yGrid];

        int numLoop = xGrid*yGrid/2;
        do
        {
            type = (Type)Random.Range(0, dictCountPikachu.Count);
            if (dictCountPikachu[type] < maxPikachu)
            {
                dictCountPikachu[type] += 2;
                for (int j = 0; j < 2; j++)
                {
                    int index = Random.Range(0, listVector2.Count);
                    int x = listVector2[index].x;
                    int y = listVector2[index].y;

                    GameObject newPikachu = (GameObject)Instantiate(prefabs, GetWorldPosition(x, y), Quaternion.identity);
                    newPikachu.name = "Pikachu(" + x + ", " + y + ")";
                    newPikachu.transform.parent = transform;

                    pikachu[x, y] = newPikachu.GetComponent<GamePikachu>();
                    pikachu[x, y].Init(x, y, this);

                    if (pikachu[x, y].IsTyped())
                    {
                        pikachu[x, y].PikachuTypeComponent.SetType(type);
                    }
                    listVector2.RemoveAt(index);
                }
                count++;
            }
        }while (count < numLoop);

    }

        Vector2 GetWorldPosition (int x, int y)
    {
        return new Vector2 (transform.position.x - xGrid/2.0f + x, transform.position.y - yGrid/2.0f + y);
    }
}
