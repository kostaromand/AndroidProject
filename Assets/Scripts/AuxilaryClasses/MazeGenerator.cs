using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using UnityEngine;



class MazeGenerator : IMapGenerator
{
    private class MazeCell
    {
        public bool Down = false;
        public bool Right = true;
        public int value = 0;
        public MazeCell(int level)
        {
            value = level;
        }
    }
    public MazeGenerator()
    {

    }

    private int DOWNCHANCES = 50;
    private int RIGHTCHANCES = 50;

    public Cell[,] getMapPrototype(EntryPointInfo exitInfo, MapSize mapSize)
    {
        int width = mapSize.Horizontal;
        int height = mapSize.Vertical;
        MazeCell[,] mazeCells = MazeCellsGenerator( (int)Math.Floor((mapSize.Horizontal - 1.0) / 2.0), (int)Math.Floor((mapSize.Vertical - 1.0) / 2.0));
        Cell[,] Map = MapFromMaze(mazeCells, height, width);
        Map[0,exitInfo.leftPoint] = new Cell(CellType.Road);
        Map[width - 1,exitInfo.rightPoint] = new Cell(CellType.Road);
        Map = FindTheWay(Map, height, width,exitInfo);
        return Map;
    }

    private Cell[,] FindTheWay(Cell[,] Map, int _height, int _width, EntryPointInfo exitInfo)
    {
        int res = 0;
        for (int i = 0; i < _height; i++)
        {
            if (exitInfo.leftPoint + i < _height && Map[1, exitInfo.leftPoint + i].Type == CellType.Road)
            {
                res = i;
                break;
            }
            if (exitInfo.leftPoint - i >= 0 && Map[1, exitInfo.leftPoint - i].Type == CellType.Road)
            {
                res = -i;
                break;
            }
        }
        while (res != 0)
        {
            Map[0, exitInfo.leftPoint + res] = new Cell(CellType.Road);
            res = res + (-res / Math.Abs(res));
        }
        for (int i = 0; i < _height; i++)
        {
            if (exitInfo.rightPoint + i < _height && Map[_width-2, exitInfo.rightPoint + i].Type == CellType.Road)
            {
                res = i;
                break;
            }
            if (exitInfo.rightPoint - i >= 0 && Map[_width - 2, exitInfo.rightPoint - i].Type == CellType.Road)
            {
                res = -i;
                break;
            }
        }
        while (res != 0)
        {
            Map[_width - 1, exitInfo.rightPoint + res] = new Cell(CellType.Road);
            res = res + (-res / Math.Abs(res));
        }
        return Map;
    }

    private Cell[,] MapFromMaze(MazeCell[,] _mazeCells, int _width, int _height)
    {
        int width = _width;
        int height = _height;
        int mazeheight = (height - 1) / 2;
        int mazeWidth = (width - 1) / 2;
        MazeCell[,] mazeCells = _mazeCells;
        Cell[,] Map = new Cell[height, width];
        for (int i = 0; i < mazeheight; i++)
        {
            for (int g = 0; g < mazeWidth; g++)
            {
                Map[i * 2 + 1,g * 2 + 1] = new Cell(CellType.Road);
                Map[i * 2 + 1,g * 2 + 2] = new Cell(mazeCells[i,g].Right ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2,g * 2 + 1] = new Cell(mazeCells[i,g].Down ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2,g * 2 + 2] = new Cell(CellType.Wall);
            }
        }
        for (int i = 0; i < height; i++)
        {
            Map[i,0] = new Cell(CellType.Wall);
        }
        for (int i = 0; i < width; i++)
        {
            Map[0,i] = new Cell(CellType.Wall);
        }
        return Map;
    }

    private MazeCell[,] MazeCellsGenerator(int _height, int _width)
    {
        int height = _height;
        int width = _width;
        int level = 1;
        MazeCell[,] mazeCells = new MazeCell[height,width];
        for (int i = 0; i < height; i++)
        {
            for (int g = 0; g < width; g++)
            {
                if (mazeCells[i,g] == null)
                {
                    mazeCells[i,g] = new MazeCell(level++);
                }
            }
            for (int g = 0; g < width - 1; g++)
            {
                if (mazeCells[i,g].value != mazeCells[i,g + 1].value)
                {
                    int randValue = UnityEngine.Random.Range(0,100);
                    if (randValue < RIGHTCHANCES)
                    {
                        int value = Math.Min(mazeCells[i,g].value, mazeCells[i,g + 1].value);
                        mazeCells[i,g].value = value;
                        mazeCells[i,g + 1].value = value;
                        
                    }
                    else
                    {
                        mazeCells[i,g].Right = false;
                    }
                }
                else
                {
                    mazeCells[i,g].Right = false;
                }
            }
            for (int g = 0; g < width; g++)
            {
                int value = mazeCells[i,g].value;
                while (g< width && mazeCells[i,g].Right){
                    mazeCells[i,g].value = value;
                    g++;
                }
                if(g!= width)
                    mazeCells[i,g].value = value;
            }
            if (i != height - 1)
            {//Если не последняя строчка
                for (int g = 0; g < width; g++)
                {
                    bool down = false;
                    while (g < width - 1 && mazeCells[i,g].value == mazeCells[i,g + 1].value)
                    {
                        if (UnityEngine.Random.Range(0, 100) < DOWNCHANCES)
                        {
                            if (!down)
                                down = !down;
                            mazeCells[i,g].Down = true;
                        }
                        g++;
                    }
                    if (!down || (down && UnityEngine.Random.Range(0, 100) < DOWNCHANCES))
                        mazeCells[i,g].Down = true;
                }
                for (int g = 0; g < width; g++)
                {
                    if (mazeCells[i,g].Down)
                        mazeCells[i + 1,g] = new MazeCell(mazeCells[i,g].value);
                }
            }
            else
            {
                int value = mazeCells[i,0].value;
                for (int g = 0; g < width - 1; g++)
                {
                    if (mazeCells[i,g].value != mazeCells[i,g + 1].value)
                    {
                        mazeCells[i,g].Right = true;
                    }
                    mazeCells[i,g].Down = false;
                }
            }

        }
        for (int i = 0; i < height; i++)
        {
            mazeCells[i,width-1].Right = false;
        }
        return mazeCells;
    }
}

