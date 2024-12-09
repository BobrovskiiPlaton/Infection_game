using UnityEngine;

namespace Diseases
{
    public class Symptom
    {
        public enum SymptomType
        {
            Fading,         //Потемнение в глазах
            HearingLoss,    //Потеря слуха
            DeepVoice,      //Грубый голос
            HighVoice,      //Писклявый голос
            Shaking,        //Тряска конечностей
            Dizziness,      //Пьяная походка
            Hallucinations, //Галлюцинации
            Radioactivity,  //Радиоактивные следы
            LowStamina,     //Низкая выносливость
            Weakness,       //Низкая грузоподъёмность
            GlowingSkin,    //Игрок светится фосфором
            Paralyze,       //Паралич игрока(отключение микрофона)
            UpsideDown,     //Смена гравитации у игрока
            Rotation,       //Поворот камеры на 90
            Slowness,       //Медленная скорость, нет спринта
            Diarrhea        //Звуки диареи
        }

        public SymptomType _symptomType;

        public Symptom(SymptomType symptomType)
        {
            _symptomType = symptomType;
        }

        
    }
}