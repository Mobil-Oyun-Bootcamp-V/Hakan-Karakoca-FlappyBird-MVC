
using UnityEditor;
using UnityEngine;

namespace Player.Scripts
{
   public class PlayerController
   {
      private PlayerView _view;
      private PlayerModel _model;
      
      private bool isFly = true; 
      private AudioSource[] _audioSources;
      public PlayerController(PlayerView view)
      {
         _model = new PlayerModel();
         _view = view;

         _view.OnJump = Jump;
         _view.OnPlayAnimation = BirdAnimation;
         _view.OnBackground = BackgroundPlay;
         _view.OnObstackleReset = ObstackleReset;
      }
      private void Jump()
      {
         _model.Rigidbody2D.velocity = Vector2.zero;
         _model.Rigidbody2D.AddForce(new Vector2(0, 200));
         _audioSources[0].Play();
         if (_model.Rigidbody2D.velocity.y>0)
         {
            _model.Transform.eulerAngles = new Vector3(0, 0, 45);
         }
         else
         {
            _model.Transform.eulerAngles = new Vector3(0, 0, -45);
         }
      }

      private void BirdAnimation()
      {
         
         float tempTime = 0;
         tempTime += Time.deltaTime;
         if (tempTime>0.2f)
         {
            tempTime = 0;
            if (isFly)
            {
               
               _view.SpriteRenderer.sprite = _model.Sprites[_model.SpriteCount];
               _model.SpriteCount++;
               if (_model.SpriteCount == _model.Sprites.Length)
               {
                  _model.SpriteCount--;
                  isFly = false;
               }
            }
            else
            {
               _model.SpriteCount--;
               _view.SpriteRenderer.sprite = _model.Sprites[_model.SpriteCount];
               if (_model.SpriteCount == 0)
               {
                  _model.SpriteCount++;
                  isFly = true;
               }
            }
         }
      }
      private void BackgroundPlay()
      {
       
         if (background1.transform.position.x <= -backgroundLength)
         {
            background1.transform.position += new Vector3(backgroundLength * 2, 0);
         }
         if (background2.transform.position.x <= -backgroundLength)
         { 
            background2.transform.position += new Vector3(backgroundLength * 2, 0);
         }

         //---------------------------------------------------------------------
            
            
         tempTime += Time.deltaTime;
         if (tempTime > 2f)
         {
            tempTime = 0;
            float Yeksenim = UnityEngine.Random.Range(1.5f, 7.5f);
            obstackles[counter].transform.position = new Vector3(8, Yeksenim);
            counter++;
            if (counter >= obstackles.Length)
            { 
               counter = 0;
            }
            
         }
        
      }
      public void ObstackleReset()
      {
         for (int i = 0; i < obstackles.Length; i++)
         {
            obstackles[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            b1Physic.velocity = Vector2.zero;
            b2Physic.velocity = Vector2.zero;
         }
        
      }
   }
}
