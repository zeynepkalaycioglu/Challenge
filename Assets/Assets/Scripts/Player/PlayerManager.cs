using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     public PlayerState playerState;
        public LevelState levelState;

        public enum PlayerState
        {
            Stop,
            Move,
            Win
        }
        public enum LevelState
        {
            NotFinished,
            Finished
        }
}
