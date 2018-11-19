using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BasicMapGenerator : IMapGenerator
{
    public BasicMapGenerator() { }

    public CellType[][] getMapPrototype(ExitInfo exitInfo, MapSize mapSize)
    {
        int width = mapSize.Horizontal;
        int height = mapSize.Vertical;
        CellType[][] cellMatrix = new CellType[width][];
        for(int i = 0;i< width;i++)
        {
            cellMatrix[i] = new CellType[height];
            for (int j = 0; j < height; j++)
            {
                cellMatrix[i][j] = new CellType("Road");
            }
        }
        return cellMatrix;
    }
}

