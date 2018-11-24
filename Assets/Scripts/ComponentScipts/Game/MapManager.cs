﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MapObject;
    DeathWall deathWall;
    Player player;
    List<Map> Maps;
    Map lastMap;
    Vector2 startVector;
    MapSize defaultMapSize = new MapSize(16, 10);
    IMapGenerator generator;
    // Use this for initialization
    void Start()
    {
        Maps = new List<Map>();
        startVector = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) + ((Vector3)MapController.SpriteSize / 2);
        generator = new BasicMapGenerator(); //<----------------- Здесь меняем генератор
        player = FindObjectOfType<Player>();
        deathWall = FindObjectOfType<DeathWall>();
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
        DestroyMapByDeathWall();
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
        Maps.Add(lastMap);
        startVector += new Vector2(lastMap.Width, 0);
    }
}