using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class MazeGenerator : IMapGenerator
{
    private class MazeCell
    {
        public bool Down = false;
        public bool Right = false;
        public int value = 0;
        public MazeCell(int level)
        {
            value = level;
        }
    }
    //readonly int height = 9;
    //readonly int width = 17;
    public MazeGenerator()
    {

    }

    private int DOWNCHANCES = 60;
    private int RIGHTCHANCES = 60;

    public Cell[][] getMapPrototype(EntryPointInfo exitInfo, MapSize mapSize)
    {
        int width = mapSize.Horizontal;
        int height = mapSize.Vertical;
        //MazeCell[][] mazeCells = MazeCellsGenerator((int)Math.Floor((mapSize.Vertical - 1.0) / 2.0), (int)Math.Floor((mapSize.Horizontal - 1.0) / 2.0));
        //Cell[][] Map = MapFromMaze(mazeCells, width, height);
        MazeCell[][] mazeCells = MazeCellsGenerator( (int)Math.Floor((mapSize.Horizontal - 1.0) / 2.0), (int)Math.Floor((mapSize.Vertical - 1.0) / 2.0));
        Cell[][] Map = MapFromMaze(mazeCells, height, width);
        Map[0][exitInfo.leftPoint] = new Cell(CellType.Road);
        Map[width - 1][exitInfo.rightPoint] = new Cell(CellType.Road);
        Map = FindTheWay(Map, height, width,exitInfo.leftPoint);
        return Map;
    }

    private Cell[][] FindTheWay(Cell[][] Map,int _height,int _width,int input)
    {
        int res = 0;
        if (Map[1][input].Type==CellType.Road)
        {
            return Map;
        }
        else
        {
            for(int i = 1; i < _height / 2; i++)
            {
                if (input + i < _height && Map[1][input + i].Type == CellType.Road)
                {
                    res = i;
                    break;
                }
                if(input - i >= 0 && Map[1][input- i].Type == CellType.Road)
                {
                    res = -i;
                    break;
                }
            }
        }
        if (res > 0)
        {
            for (int i = res; i >= 0; i--)
            {
                Map[0][input + i] = new Cell(CellType.Road);
            }
        }
        else
        {
            for (int i = res; i <= 0; i++)
            {
                Map[0][input + i] = new Cell(CellType.Road);
            }
        }
        return Map;
    }

    private Cell[][] MapFromMaze(MazeCell[][] _mazeCells, int _width, int _height)
    {
        int width = _width;
        int height = _height;
        int mazeheight = (height - 1) / 2;
        int mazeWidth = (width - 1) / 2;
        MazeCell[][] mazeCells = _mazeCells;
        Cell[][] Map = new Cell[height][];
        for (int i = 0; i < height; i++)
        {
            Map[i] = new Cell[width];
        }
        for (int i = 0; i < mazeheight; i++)
        {
            for (int g = 0; g < mazeWidth; g++)
            {
                Map[i * 2 + 1][g * 2 + 1] = new Cell(CellType.Road);
                Map[i * 2 + 1][g * 2 + 2] = new Cell(mazeCells[i][g].Right ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2][g * 2 + 1] = new Cell(mazeCells[i][g].Down ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2][g * 2 + 2] = new Cell(CellType.Wall);
                if (!mazeCells[i][g].Down && !mazeCells[i][g].Right)
                {
                    int e = 3;
                }
            }
        }
        for (int i = 0; i < height; i++)
        {
            Map[i][0] = new Cell(CellType.Wall);
        }
        for (int i = 0; i < width; i++)
        {
            Map[0][i] = new Cell(CellType.Wall);
        }
        //Map = Transp(Map,width,height);
        return Map;
    }

    private Cell[][] Transp(Cell[][] Map, int _width, int _height)
    {
        int width = _width;
        int height = _height;
        Cell[][] TranspMap = new Cell[width][];
        for (int i = 0; i < width; i++)
        {
            TranspMap[i] = new Cell[height];
        }
        for (int i = 0; i < width; i++)
        {
            for (int g = 0; g < height; g++)
            {
                TranspMap[i][g] = Map[g][i];
            }
        }
        return TranspMap;
    }

    private MazeCell[][] MazeCellsGenerator(int _height, int _width)
    {
        int height = _height;
        int width = _width;
        int level = 1;
        MazeCell[][] mazeCells = new MazeCell[height][];
        Random random = new Random();
        for (int i = 0; i < height; i++)
        {
            mazeCells[i] = new MazeCell[width];
        }
        for (int i = 0; i < height; i++)
        {
            for (int g = 0; g < mazeCells[i].Length; g++)
            {
                if (mazeCells[i][g] == null)
                {
                    mazeCells[i][g] = new MazeCell(level++);
                }
            }
            for (int g = 0; g < mazeCells[i].Length - 1; g++)
            {
                if (mazeCells[i][g].value != mazeCells[i][g + 1].value)
                {
                    int randValue = random.Next(100);
                    if (randValue < RIGHTCHANCES)
                    {
                        int value = Math.Min(mazeCells[i][g].value, mazeCells[i][g + 1].value);
                        mazeCells[i][g].value = value;
                        mazeCells[i][g + 1].value = value;
                        mazeCells[i][g].Right = true;
                    }
                }
            }
            if (i != height - 1)
            {//Если не последняя строчка
                for (int g = 0; g < mazeCells[i].Length; g++)
                {
                    bool down = false;
                    while (g < mazeCells[i].Length - 1 && mazeCells[i][g].value == mazeCells[i][g + 1].value)
                    {
                        if (random.Next(100) < DOWNCHANCES)
                        {
                            if (!down)
                                down = !down;
                            mazeCells[i][g].Down = true;
                        }
                        g++;
                    }
                    if (!down)
                        mazeCells[i][g].Down = true;
                    if(!mazeCells[i][g].Down && !mazeCells[i][g].Right)
                    {
                        int e = 3;
                    }
                }
                for (int g = 0; g < mazeCells[i].Length; g++)
                {
                    if (mazeCells[i][g].Down)
                        mazeCells[i + 1][g] = new MazeCell(mazeCells[i][g].value);
                }
            }
            else
            {
                int value = mazeCells[i][0].value;
                mazeCells[i][mazeCells[i].Length-1].value=value;
                mazeCells[i][mazeCells[i].Length - 1].Right = false;
                for (int g = 0; g < mazeCells[i].Length-1; g++)
                {
                    mazeCells[i][g].value = value;
                    mazeCells[i][g].Right = true;
                }
            }
        }
        return mazeCells;
    }
}

