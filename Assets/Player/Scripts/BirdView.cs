using System.Collections;
using System.Collections.Generic;
using Player.Scripts;
using UnityEngine;


public class BirdView : MonoBehaviour
{
    public Sprite[] sprites;
    private PlayerModel _model;
    void Start()
    {
        _model.Sprites = sprites;
    }
}
