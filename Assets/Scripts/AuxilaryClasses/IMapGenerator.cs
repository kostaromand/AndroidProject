using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public interface IMapGenerator
{
    Cell[,] getMapPrototype(EntryPointInfo exitInfo, MapSize mapSize);
}