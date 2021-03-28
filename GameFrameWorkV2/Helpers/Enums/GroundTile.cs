using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Helpers.Enums
{
    public enum GroundTile
    {
        EmptyGround = '.',
        EdgeTopBottom = '_',
        EdgeSides = '|',
        EdgeEmpty = ' ',
        Enemy = 'G',
        Player = 'P',
        Item = 'I'
    }
}

