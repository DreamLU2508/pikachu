using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePikachu : MonoBehaviour
{
    private int x;
    private int y;
    private Grid grid;

    public int X { get { return x; } }
    public int Y { get { return y; } }

    public Grid GridRef { get { return grid; } }

    private PikachuType pikachuTypeComponent;
    public PikachuType PikachuTypeComponent
    {
        get { return pikachuTypeComponent; }
    }

    private void Awake()
    {
        pikachuTypeComponent = GetComponent<PikachuType>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int _x, int _y, Grid _grid)
    {
        x = _x;
        y = _y;
        grid = _grid;
    }

    public bool IsTyped()
    {
        return pikachuTypeComponent != null;
    }
}
