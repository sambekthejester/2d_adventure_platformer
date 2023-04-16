using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udemy3.Abstracts.Movements
{
    public interface IStopEdge
    {
        bool IsRightDirection { get; }
        bool ReachEdge();
    }

}