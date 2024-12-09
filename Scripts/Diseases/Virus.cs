using System;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Diseases
{
    public class Virus : MonoBehaviour
    {
        public enum VirusType
        {
            Copid_23,
            Myrlik_09,
            Panpuk_77,
            Lapex_19,
            Lols_03
        }



        private const float SymptomCooldown = 10f;
        private const int MaxSymptoms = 3;

        public VirusType _virusType;
        
        private List<Symptom> symptomsList;
        private List<Symptom> activeSymptoms;
        private float cooldown;

        private void Awake()
        {
            _virusType = (VirusType)Random.Range(0, Enum.GetValues(typeof(VirusType)).Length);
            Debug.Log("Игрок заболел вирусом " + _virusType.ToString());
            
            activeSymptoms = new List<Symptom>();
            
            symptomsList = CreatePossibleSymptoms();
            cooldown = SymptomCooldown;
        }

        public void Update()
        {
            UpdateCooldown();
            Mutate();
        }

        private List<Symptom> CreatePossibleSymptoms()
        {
            List<Symptom> symptoms1;
            List<Symptom> symptoms2;

            switch (_virusType)
            {
                case VirusType.Copid_23:
                    symptoms1 = new List<Symptom>{new Symptom(Symptom.SymptomType.Dizziness), new Symptom(Symptom.SymptomType.UpsideDown), new Symptom(Symptom.SymptomType.HighVoice)};
                    symptoms2 = new List<Symptom>{new Symptom(Symptom.SymptomType.Slowness), new Symptom(Symptom.SymptomType.Shaking), new Symptom(Symptom.SymptomType.Fading)};
                    return ChooseRandomSymptomsList(symptoms1, symptoms2);
                
                case VirusType.Myrlik_09:
                    symptoms1 = new List<Symptom>{new Symptom(Symptom.SymptomType.LowStamina), new Symptom(Symptom.SymptomType.Diarrhea), new Symptom(Symptom.SymptomType.HighVoice)};
                    symptoms2 = new List<Symptom>{new Symptom(Symptom.SymptomType.Paralyze), new Symptom(Symptom.SymptomType.Hallucinations), new Symptom(Symptom.SymptomType.Radioactivity)};
                    return ChooseRandomSymptomsList(symptoms1, symptoms2);
                
                case VirusType.Panpuk_77:
                    symptoms1 = new List<Symptom>{new Symptom(Symptom.SymptomType.Paralyze), new Symptom(Symptom.SymptomType.Hallucinations), new Symptom(Symptom.SymptomType.GlowingSkin)};
                    symptoms2 = new List<Symptom>{new Symptom(Symptom.SymptomType.Rotation), new Symptom(Symptom.SymptomType.Fading), new Symptom(Symptom.SymptomType.DeepVoice)};
                    return ChooseRandomSymptomsList(symptoms1, symptoms2);
                
                case VirusType.Lapex_19:
                    symptoms1 = new List<Symptom>{new Symptom(Symptom.SymptomType.Slowness), new Symptom(Symptom.SymptomType.HearingLoss), new Symptom(Symptom.SymptomType.Radioactivity)};
                    symptoms2 = new List<Symptom>{new Symptom(Symptom.SymptomType.LowStamina), new Symptom(Symptom.SymptomType.HearingLoss), new Symptom(Symptom.SymptomType.Diarrhea)};
                    return ChooseRandomSymptomsList(symptoms1, symptoms2);

                
                case VirusType.Lols_03:
                    symptoms1 = new List<Symptom>{new Symptom(Symptom.SymptomType.Rotation), new Symptom(Symptom.SymptomType.Radioactivity), new Symptom(Symptom.SymptomType.Weakness)};
                    symptoms2 = new List<Symptom>{new Symptom(Symptom.SymptomType.Dizziness), new Symptom(Symptom.SymptomType.UpsideDown), new Symptom(Symptom.SymptomType.HearingLoss)};
                    return ChooseRandomSymptomsList(symptoms1, symptoms2);
            }

            return null;

        }

        private static List<Symptom> ChooseRandomSymptomsList(List<Symptom> symptoms1, List<Symptom> symptoms2)
        {
            List<List<Symptom>> possibleSymptoms = new List<List<Symptom>> { symptoms1, symptoms2 };
            return possibleSymptoms[Random.Range(0, possibleSymptoms.Count)];
        }

        //Добавить симптом
        private void Mutate()
        {
            if (CanAdd())
            {
                cooldown = SymptomCooldown;
                AddSymptom();
            }
        }

        private void AddSymptom()
        {
            //Выбираем случайный симптом из трёх возможных
            Symptom symptom = symptomsList[Random.Range(0, symptomsList.Count)];
            UpdateLists(symptom);
            InfectedPlayer.CastSymptomEffect(symptom);

        }
        
       
        

        private void UpdateLists(Symptom symptom)
        {
            activeSymptoms.Add(symptom);
            symptomsList.Remove(symptom);
        }

        //Проверка возможности добавить
        private bool CanAdd() =>
            CooldownIsUp() && (activeSymptoms.Count < MaxSymptoms);

        private void UpdateCooldown() =>
            cooldown -= Time.deltaTime;

        private bool CooldownIsUp() =>
            cooldown <= 0;
    }
}
