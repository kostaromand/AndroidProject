using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Cell
{
    public CellType Type { get; private set; }
    public Cell(CellType cellType)
    {
        Type = cellType;
    }

    public string getTypeName()
    {
        return Type.ToString();
    }
}
