using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MapObject;
    public GameObject playerObject;
    private Player player;
    Map lastMap;
    Vector2 startVector;
    MapSize defaultMapSize = new MapSize(16, 10);
    IMapGenerator generator;
    // Use this for initialization
    void Start()
    {
        startVector = transform.position;
        generator = new BasicMapGenerator();
        player = playerObject.GetComponent<Player>();
        addNewMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastMap != null)
        {
            var startX = lastMap.transform.position.x;
            if (player.transform.position.x > startX)
                addNewMap();
        }
    }
    public void addNewMap()
    {
        GameObject newMap = Instantiate(MapObject, startVector, Quaternion.identity, transform);
        MapSize mapSize = new MapSize(defaultMapSize.Horizontal, defaultMapSize.Vertical);
        ExitInfo exitInfo;
        if (lastMap == null)
        {
            int startPos = Random.Range(0, mapSize.Horizontal + 1);
            int endPos = Random.Range(0, mapSize.Horizontal + 1);
            exitInfo = new ExitInfo(startPos, endPos);
        }
        else
        {
            exitInfo = lastMap.ExitInfo;
        }
        MapController mapController = newMap.GetComponent<MapController>();
        lastMap = mapController.CreateMap(exitInfo, mapSize, generator);
        Debug.Log("Map Created");
        startVector += new Vector2(lastMap.Width, 0);
    }
}
