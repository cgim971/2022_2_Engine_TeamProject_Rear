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
        BALL,
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
        public static PlayerModeType GetPlayerModeType(int index)
        {
            switch (index)
            {
                case 0:
                    return PlayerModeType.CUBE;
                case 1:
                    return PlayerModeType.SHIP;
                case 2:
                    return PlayerModeType.UFO;
                case 3:
                    return PlayerModeType.WAVE;
                case 4:
                    return PlayerModeType.ROBOT;
                case 5:
                    return PlayerModeType.SPIDER;
                case 6:
                    return PlayerModeType.BALL;
            }
            return PlayerModeType.NONE;
        }
    }

    public static class Math
    {
        public static Vector3 VectorAbs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }
    }

    public static class Sound
    {
        public readonly static string _bgmVolume = "BGM_VOLUME";
        public readonly static string _effectVolume = "EFFECT_VOLUME";
    }
}

