using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Player.Scripts
{
   public class PlayerView: MonoBehaviour
   {
      public UnityAction OnGameStart;
      public UnityAction OnGameOver;
      public UnityAction OnJump;
      public UnityAction OnPlayAnimation;
      public UnityAction OnBackground;
      public UnityAction OnObstackleReset;
      

      private void OnTriggerEnter(Collider other)
      {
         if (other.gameObject.tag == "Score")
         {
            score++;
            skorText.text = "SCORE : " + score;
            //ses ekleme
           _audioSources[1].Play();
         }

         if (other.gameObject.tag == "Obstackle")
         {
            _audioSources[2].Play();
            OnGameOver?.Invoke();
            
            if (score>highScore)
            { 
               highScore = score;
               PlayerPrefs.SetInt("highSkorLog",highScore);
            }
            //ana menü dön
            //ana menü yükleme yerinde yapılacak
            //PlayerPrefs.SetInt("skorLog",skor);
         }
         
      }

      private void PrepareGame()
      {
         if (Input.GetMouseButtonDown(0))
         {
            OnGameStart?.Invoke();
         }
      }

      private void Jump()
      {
         if (Input.GetMouseButtonDown(0))
         {
            OnJump?.Invoke();
         }
      }

      private void PlayAnimation()
      {
         OnPlayAnimation?.Invoke();
      }
      private void BackgroundPlay()
      {
         OnBackground?.Invoke();
      }
      private void ObstackleReset()
      {
         OnObstackleReset?.Invoke();
      }
      private void Update()
      {
         switch (GameManager.gameManager.CurrentGameStates)
         {
            case GameManager.GameStates.Prepare:
               PrepareGame();
               break;
            case GameManager.GameStates.InGame:
               PlayAnimation();
               BackgroundPlay();
               Jump();
               break;
            case GameManager.GameStates.EndGame:
               ObstackleReset();
               break;
         }
      }
   }
}

