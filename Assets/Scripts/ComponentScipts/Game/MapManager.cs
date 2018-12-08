using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MapObject;
    DeathWallController deathWall;
    PlayerController player;
    List<Map> Maps;
    Map lastMap;
    Vector2 startVector;
    MapSize defaultMapSize = new MapSize(17, 11);
    IMapGenerator generator;
    // Use this for initialization
    void Start()
    {
        Maps = new List<Map>();
        startVector = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) + ((Vector3)MapController.SpriteSize / 2);
        generator = new MazeGenerator(); //<----------------- Здесь меняем генератор
        player = FindObjectOfType<PlayerController>();
        deathWall = FindObjectOfType<DeathWallController>();
        AddNewMap();
        LocatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastMap != null)
        {
            var startX = lastMap.transform.position.x;
            if (player.transform.position.x > startX)
                AddNewMap();
        }
        DestroyMapByDeathWall();
    }

    void LocatePlayer()
    {
        int x,y;
        var map = Maps[0];
        do
        {
            x = map.MapSize.Horizontal/2;
            y = Random.Range(1, map.MapSize.Vertical);
        }
        while (map.mapPrototype[x,y].Type == CellType.Wall);
        player.transform.position = new Vector3(map.transform.position.x + x, map.transform.position.y + y);
    }

    void DestroyMapByDeathWall()
    {
        float wallCoordX = deathWall.transform.position.x;
        Maps.FindAll(x => x.transform.position.x + x.Width < wallCoordX).ForEach(x => { Destroy(x.gameObject); Maps.Remove(x);Debug.Log("Destroyed"); });
    }

    public void AddNewMap()
    {
        GameObject newMap = Instantiate(MapObject, startVector, Quaternion.identity, transform);
        MapSize mapSize = new MapSize(defaultMapSize.Horizontal, defaultMapSize.Vertical);
        EntryPointInfo entryPointInfo;
        int startPos;
        int endPos;
        if (lastMap == null)
        {
            startPos = Random.Range(2, mapSize.Vertical-1);
        }
        else
        {
            startPos = lastMap.entryPointInfo.rightPoint;
        }
        endPos = Random.Range(2, mapSize.Vertical-1);
        entryPointInfo = new EntryPointInfo(startPos, endPos);
        MapController mapController = newMap.GetComponent<MapController>();
        lastMap = mapController.CreateMap(entryPointInfo, mapSize, generator);
        Maps.Add(lastMap);
        startVector += new Vector2(lastMap.Width, 0);
    }
}
