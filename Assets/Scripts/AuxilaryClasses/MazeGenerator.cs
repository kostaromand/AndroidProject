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

    public Cell[][] getMapPrototype(EntryPointInfo exitInfo, MapSize mapSize)
    {
        int width = mapSize.Horizontal;
        int height = mapSize.Vertical;
        MazeCell[][] mazeCells = MazeCellsGenerator((mapSize.Vertical - 1) / 2, (mapSize.Horizontal - 1) / 2);
        Cell[][] Map = MapFromMaze(mazeCells, width, height);
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
        for (int i = 0; i < mazeheight; i++)
        {
            for (int g = 0; g < mazeWidth; g++)
            {
                Map[i * 2 + 1][g * 2 + 1] = new Cell(CellType.Road);
                Map[i * 2 + 1][g * 2 + 2] = new Cell(mazeCells[i][g].Right ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2][g * 2 + 1] = new Cell(mazeCells[i][g].Down ? CellType.Road : CellType.Wall);
                Map[i * 2 + 2][g * 2 + 2] = new Cell(CellType.Wall);
            }
        }
        for (int i = 0; i < height; i++)
        {
            Map[0][i] = new Cell(CellType.Wall);
        }
        for (int i = 0; i < width; i++)
        {
            Map[i][0] = new Cell(CellType.Wall);
        }
        return null;
    }

    private MazeCell[][] MazeCellsGenerator(int _height, int _width)
    {
        int height = _height;
        int width = _width;
        int level = 1;
        MazeCell[][] mazeCells = new MazeCell[height][];
        MazeCell[] currentMazeCells = new MazeCell[width];
        Random random = new Random();
        for (int i = 0; i < height; i++)
        {
            MazeCell[] newMazeCell = new MazeCell[width];
            for (int g = 0; g < currentMazeCells.Length; g++)
            {
                if (mazeCells[i][g] == null)
                {
                    mazeCells[i][g] = new MazeCell(level++);
                }
            }
            for (int g = 0; g < mazeCells[i].Length - 1; g++)
            {
                if (mazeCells[i][g] != mazeCells[i][g + 1])//Возможно как внизу условие переделать
                {
                    if (random.Next(100) < 50)
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
                for (int g = 0; g < mazeCells[i].Length - 1; g++)
                {
                    bool down = false;
                    while (g < mazeCells[i].Length - 1 && mazeCells[i][g] == mazeCells[i][g + 1])
                    {
                        if (random.Next(100) < 50)
                        {
                            if (!down)
                                down = !down;
                            mazeCells[i][g].Down = true;
                        }
                        g++;
                    }
                    if (!down)
                        mazeCells[i][g].Down = true;
                }
                for (int g = 0; g < mazeCells[i].Length; g++)
                {
                    if (mazeCells[i][g].Down)
                        mazeCells[i + 1][g] = new MazeCell(mazeCells[i][g].value);
                }
            }
        }
        return mazeCells;
    }
}

