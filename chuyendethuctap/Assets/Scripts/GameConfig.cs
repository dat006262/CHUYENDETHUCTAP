using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public GameObject GamePlayParent;
    public Sprite spriteInGame;
    public int spriteGameSize = 50;
    public float jumpColor;
    public OpenGamePlayBtn nowGameButton;
    public OpenGamePlayBtn drawGameButton;
    public static GameConfig Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
