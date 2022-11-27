using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuType : MonoBehaviour
{

    [System.Serializable]
    public struct TypeSprite
    {
        public Type type;
        public Sprite sprite;
    };

    public TypeSprite[] typeSprites;

    private Type type;
    public Type TypeRef
    {
        get { return type; }
        set { SetType(value); }
    }

    private SpriteRenderer spriteRenderer;
    private Dictionary<Type, Sprite> typeSpriteDict;

    private void Awake()
    {
        spriteRenderer = transform.Find("pikachu").GetComponent<SpriteRenderer>();

        typeSpriteDict = new Dictionary<Type, Sprite>();

        for (int i = 0; i < typeSprites.Length; i++)
        {
            if (!typeSpriteDict.ContainsKey(typeSprites[i].type))
            {
                typeSpriteDict.Add(typeSprites[i].type, typeSprites[i].sprite);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetType(Type newType)
    {
        type = newType;
        if (typeSpriteDict.ContainsKey(newType))
        {
            spriteRenderer.sprite = typeSpriteDict[newType];    
        }
    }
}
