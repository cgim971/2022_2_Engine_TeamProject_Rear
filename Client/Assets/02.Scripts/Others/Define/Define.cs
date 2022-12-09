using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Define
{
    public enum PlayerModeType
    {
        NONE,
        CUBE,
        SHIP,
        UFO,
        WAVE,
        ROBOT,
        SPIDER,
        END
    }

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

    public enum SoundType
    {
        BGM,
        EFFECT,
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
        public static DirType GetReverseGravityType(DirType gravityType)
        {
            switch(gravityType)
            {
                case DirType.UP: return DirType.DOWN;
                case DirType.DOWN: return DirType.UP;
                case DirType.LEFT: return DirType.RIGHT;
                case DirType.RIGHT: return DirType.LEFT;
                case DirType.FORWARD: return DirType.BACKWARD;
                case DirType.BACKWARD: return DirType.FORWARD;
            }
            return DirType.NONE;
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
        public static DirType GetReverseDirType(DirType gravityType)
        {
            switch (gravityType)
            {
                case DirType.UP: return DirType.DOWN;
                case DirType.DOWN: return DirType.UP;
                case DirType.LEFT: return DirType.RIGHT;
                case DirType.RIGHT: return DirType.LEFT;
                case DirType.FORWARD: return DirType.BACKWARD;
                case DirType.BACKWARD: return DirType.FORWARD;
            }
            return DirType.NONE;
        }
    }

    public static class Player
    {

    }
}

