using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public interface IMapGenerator
{
    CellType[][] getMapPrototype(ExitInfo exitInfo, MapSize mapSize);
}