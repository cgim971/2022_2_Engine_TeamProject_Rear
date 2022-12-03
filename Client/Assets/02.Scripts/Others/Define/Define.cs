using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Define
{
    public enum DirType
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        FORWARD,
        BACKWARD,
        END
    }

    public static class Gravity
    {
        public static Vector3 GetGravity(DirType gravityType)
        {
            switch (gravityType)
            {
                case DirType.UP: return Vector3.up;
                case DirType.DOWN: return Vector3.down;
                case DirType.LEFT: return Vector3.left;
                case DirType.RIGHT: return Vector3.right;
                case DirType.FORWARD: return Vector3.forward;
                case DirType.BACKWARD: return Vector3.back;
            }
            return Vector3.zero;
        }
    }

    public static class Direction
    {
        public static Vector3 GetDirection(DirType dirType)
        {
            switch (dirType)
            {
                case DirType.UP: return Vector3.up;
                case DirType.DOWN: return Vector3.down;
                case DirType.LEFT: return Vector3.left;
                case DirType.RIGHT: return Vector3.right;
                case DirType.FORWARD: return Vector3.forward;
                case DirType.BACKWARD: return Vector3.back;
            }
            return Vector3.zero;
        }
    }
}

