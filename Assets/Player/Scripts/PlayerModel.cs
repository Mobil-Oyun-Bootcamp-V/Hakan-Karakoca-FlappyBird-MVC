
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerModel
    {
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
       
        private int spriteCount =0;
        private Sprite[] _sprites;
        private Transform _transform;
        public Sprite[] Sprites
        {
            get => _sprites;
            set => _sprites = value;
            
        }
        public Transform Transform {
            get => _transform;
            set => _transform = value;
        }

        public int SpriteCount
        {
            get => spriteCount;
            set => spriteCount = value;
        }

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
            set => _rigidbody2D = value;
        }

        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }
       
        void Start()
        {
            
        }
    }
}
