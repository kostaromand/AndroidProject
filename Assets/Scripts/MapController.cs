using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MapController : MonoBehaviour
{
    public GameObject[] Cells;
    public Map MapInfo { get; private set; }
    public Vector2 SpriteSize;
    // Use this for initialization
    void Awake()
    {
        SpriteSize = new Vector2(1, 1);
        MapInfo = gameObject.GetComponent<Map>();
    }

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public Map CreateMap(ExitInfo exitInfo, MapSize mapSize, IMapGenerator generator)
    {
        var MapPrototype = generator.getMapPrototype(exitInfo, mapSize);
        float x = transform.position.x;
        float y = transform.position.y;
        for (int i = 0; i < mapSize.Horizontal; i++)
        {
            for (int j = 0; j < mapSize.Vertical; j++)
            {
                GameObject gameObject = Cells.First(g => g.name == MapPrototype[i][j].CellTypeName);
                Instantiate(gameObject, new Vector3(x + i * SpriteSize.x, y + j * SpriteSize.y), Quaternion.identity, transform);
            }
        }
        MapInfo.ExitInfo = exitInfo;
        MapInfo.MapSize = mapSize;
        MapInfo.Width = mapSize.Horizontal * SpriteSize.x;
        MapInfo.Height = mapSize.Vertical * SpriteSize.y;
        Debug.Log("Map Created");
        return MapInfo;
    }
}
