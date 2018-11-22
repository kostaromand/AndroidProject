using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class EntryPointInfo
{
    public int leftPoint;
    public int rightPoint;

    public EntryPointInfo(int left, int right)
    {
        leftPoint = left;
        rightPoint = right;
    }
}