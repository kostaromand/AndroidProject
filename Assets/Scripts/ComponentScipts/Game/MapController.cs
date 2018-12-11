using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MapController : MonoBehaviour
{
    public GameObject Background;
    public GameObject[] Walls;
    public Item[] Items;
    public Map MapInfo { get; private set; }
    public static Vector2 SpriteSize = new Vector2(1, 1);
    // Use this for initialization
    void Awake()
    {
        MapInfo = gameObject.GetComponent<Map>();
    }

    public Map CreateMap(EntryPointInfo entryPointInfo, MapSize mapSize, IMapGenerator generator)
    {
        var MapPrototype = generator.getMapPrototype(entryPointInfo, mapSize);
        float x = transform.position.x;
        float y = transform.position.y;
        for (int i = 0; i < mapSize.Horizontal; i++)
        {
            for (int j = 0; j < mapSize.Vertical; j++)
            {
                string tag = MapPrototype[i, j].getTypeName();
                if (tag == "Wall")
                {
                    var gameObject = (from wall in Walls where wall.tag == tag select wall).ToArray()[Random.Range(0, Walls.Length)];
                    Instantiate(gameObject, new Vector3(x + i * SpriteSize.x, y + j * SpriteSize.y), Quaternion.identity, transform);
                }
            }
        }
        Instantiate(Background, new Vector3(x, 0), Quaternion.identity, transform);
        CreateItems(MapPrototype,mapSize);
        MapInfo.mapPrototype = MapPrototype;
        MapInfo.entryPointInfo = entryPointInfo;
        MapInfo.MapSize = mapSize;
        MapInfo.Width = mapSize.Horizontal * SpriteSize.x;
        MapInfo.Height = mapSize.Vertical * SpriteSize.y;
        return MapInfo;
    }

    private void CreateItems(Cell[,] MapPrototype, MapSize mapSize)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        int maxAmountItems = Random.Range(0, Items.Length);
        Dictionary<Item, List<int>> createdItems = new Dictionary<Item, List<int>>();
        for (int i = 0; i < maxAmountItems; i++)
        {
            List<int> temp;
            int ver = 0;
            int hor = 0;
            int randomItem = 0;
            do
            {
                randomItem = Random.Range(0, Items.Length);
            }
            while (createdItems.Keys.Contains(Items[randomItem]));
            do
            {
                temp = new List<int>();
                ver = Random.Range(0,mapSize.Horizontal-1);
                hor = Random.Range(0, mapSize.Vertical-1);
                temp.Add(ver);
                temp.Add(hor);
            }
            while (MapPrototype[ver,hor].Type == CellType.Wall || createdItems.Values.Contains(temp));
            createdItems.Add(Items[randomItem], temp);
            Instantiate(Items[randomItem], new Vector3(x + ver * SpriteSize.x, y + hor * SpriteSize.y), Quaternion.identity, transform);
        }
    }
}