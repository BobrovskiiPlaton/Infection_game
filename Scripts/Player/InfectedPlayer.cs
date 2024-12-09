using System;
using System.Collections;
using System.Collections.Generic;
using Diseases;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Random = UnityEngine.Random;

namespace Player
{
    public class InfectedPlayer : MonoBehaviour
    {
        private static string symptomText;
        [SerializeField] private TextMeshProUGUI msg;
        private string virusName;
        
        private static AudioClip music;
        private static AudioClip fartSound;
        private static Image fade;
        private static AudioSource audioSource;
        private static Light _light;

        private static Transform _playerTransform;
        private static PlayerController _playerController;
        private static CameraController _cameraController;


        private void Awake()
        {
            virusName = GetComponent<Virus>()._virusType.ToString();
            symptomText = virusName;
            _cameraController = GetComponentInChildren<CameraController>();
            _playerTransform = gameObject.transform;
            _playerController = gameObject.GetComponent<PlayerController>();

            _light = GetComponentInChildren<Light>();
            
            fade = GameObject.Find("Fade").GetComponent<Image>();
            audioSource = GetComponent<AudioSource>();
            BackgroundMusic();
        }

        private void Update()
        {
            ShowMsg();
        }

        public static void CastSymptomEffect(Symptom symptom)
        {
            switch (symptom._symptomType)
            {

                case Symptom.SymptomType.Fading:
                {
                    symptomText = "Затемнение";
                    MakeFade(fade);
                    break;
                }
                case Symptom.SymptomType.HearingLoss:
                {
                    symptomText = "Потеря слуха";
                    audioSource.mute = true;
                    break;
                }
                case Symptom.SymptomType.DeepVoice:
                {
                    symptomText = "Низкий голос";
                    break;
                }
                case Symptom.SymptomType.HighVoice:
                {
                    symptomText = "Высокий голос";
                    break;
                };
                case Symptom.SymptomType.Shaking:
                {
                    symptomText = "Тряска";
                    ShakeCamera();
                    break;
                };
                case Symptom.SymptomType.Dizziness:
                {
                    symptomText = "Пьяная походка";
                    break;
                };
                case Symptom.SymptomType.Hallucinations:
                {
                    symptomText = "Галюцинации";
                    break;
                };
                case Symptom.SymptomType.Radioactivity:
                {
                    symptomText = "Радиоактивные следы от игрока B";
                    break;
                };
                case Symptom.SymptomType.LowStamina:
                {
                    symptomText = "Низкая выносливость";
                    break;
                };
                case Symptom.SymptomType.Weakness:
                {
                    symptomText = "Слабость";
                    Destroy(GameObject.Find("InteractionPoint"));
                    break;
                };
                case Symptom.SymptomType.GlowingSkin:
                {
                    symptomText = "Светящаяся кожа";
                    _light.enabled = true;
                    break;
                };
                case Symptom.SymptomType.Paralyze:
                {
                    symptomText ="Игрок парализован";
                    break;
                };
                case Symptom.SymptomType.UpsideDown:
                {
                    symptomText = "Смена гравитации";
                    PlayerUpsideDown();
                    break;
                };
                case Symptom.SymptomType.Rotation:
                {
                    symptomText =("Поворот камеры на 90");
                    _cameraController.cameraTwisted = true;
                    break;
                };
                case Symptom.SymptomType.Slowness:
                {
                    symptomText = "Замедление";
                    _playerController._speed -= 3;
                    break;
                };
                case Symptom.SymptomType.Diarrhea:
                {
                    symptomText = "Диарея";
                    Farting();
                    break;
                };
            }

        }

        private static void Farting()
        {
            fartSound = Resources.Load<AudioClip>("Audio/fart_echo-94308");
            audioSource.PlayOneShot(fartSound);
        }

        private void BackgroundMusic()
        {
            music = Resources.Load<AudioClip>("Audio/sound-k-117217");
            audioSource.clip = music;
            audioSource.loop = true;
            audioSource.Play();
        }

        private static void PlayerUpsideDown()
        {
            _cameraController.cameraUpsideDown = true;
            _playerTransform.localScale = new Vector3(_playerTransform.localScale.x,
                _playerTransform.localScale.y * (-1), _playerTransform.localScale.z);
            
        }

        private static void MakeFade(Image fade)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 0.995f);
        }

        private static void ShakeCamera()
        {
            Camera.main.DOShakePosition(3f, 0.1f, 10, 90f, false, ShakeRandomnessMode.Full).SetLoops(-1);
        }


        private void ShowMsg()
        {
            msg.text = symptomText;
        }
    }
}
