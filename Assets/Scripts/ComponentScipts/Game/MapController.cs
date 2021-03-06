﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MapController : MonoBehaviour
{
    public GameObject[] Cells;
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
                GameObject gameObject = Cells.First(g => g.name == MapPrototype[i,j].getTypeName());
                Instantiate(gameObject, new Vector3(x + i * SpriteSize.x, y + j * SpriteSize.y), Quaternion.identity, transform);
            }
        }
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
        List<Item> createdItems = new List<Item>();
        int maxAmountItems = Random.Range(0, Items.Length);
        for (int i = 0; i < maxAmountItems; i++)
        {
            int ver = 0;
            int hor = 0;
            int randomItem = 0;
            do
            {
                ver = Random.Range(0,mapSize.Horizontal-1);
                hor = Random.Range(0, mapSize.Vertical-1);
            }
            while (MapPrototype[ver,hor].Type == CellType.Wall);
            do {
                randomItem = Random.Range(0, Items.Length);
            }
            while (createdItems.Contains(Items[randomItem]));
            createdItems.Add(Items[randomItem]);
            Instantiate(Items[randomItem], new Vector3(x + ver * SpriteSize.x, y + hor * SpriteSize.y), Quaternion.identity, transform);
        }
    }
}