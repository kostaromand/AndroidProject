using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BasicMapGenerator : IMapGenerator
{
    public BasicMapGenerator() { }

    public Cell[][] getMapPrototype(EntryPointInfo exitInfo, MapSize mapSize)
    {
        int width = mapSize.Horizontal;
        int height = mapSize.Vertical;
        Cell[][] cellMatrix = new Cell[width][];
        for(int i = 0;i< width;i++)
        {
            cellMatrix[i] = new Cell[height];
            for (int j = 0; j < height; j++)
            {
                cellMatrix[i][j] = new Cell(CellType.Road);
            }
        }
        return cellMatrix;
    }
}

