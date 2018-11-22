using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MapObject;
    public GameObject playerObject;
    Player player;
    Map lastMap;
    Vector2 startVector;
    MapSize defaultMapSize = new MapSize(16, 10);
    IMapGenerator generator;
    // Use this for initialization
    void Start()
    {
        startVector = transform.position;
        generator = new BasicMapGenerator(); //<----------------- Здесь меняем генератор
        player = playerObject.GetComponent<Player>();
        AddNewMap();
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
            startPos = Random.Range(0, mapSize.Horizontal + 1);
        }
        else
        {
            startPos = lastMap.entryPointInfo.rightPoint;
        }
        endPos = Random.Range(0, mapSize.Horizontal + 1);
        entryPointInfo = new EntryPointInfo(startPos, endPos);
        MapController mapController = newMap.GetComponent<MapController>();
        lastMap = mapController.CreateMap(entryPointInfo, mapSize, generator);
        startVector += new Vector2(lastMap.Width, 0);
    }
}
