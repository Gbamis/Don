using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gbamis
{

    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
    public class PlayerData_SO : ScriptableObject
    {
        public EventData_SO eventData_SO;

        [Header("PLAYER DATA")]
        public string File_Name="";

        [HideInInspector]
        public Vector3 butterfly_current_position;
        public bool butterfly_is_free;
        [HideInInspector]
        public Vector3 player_current_position;
        [HideInInspector]
        public Vector3 tapLocation;

        
        [Range(0,100)]
        public float player_health;
        public float player_coin_count;


        public void save(){
            string jsonEncoded = JsonUtility.ToJson(this);
            string filePath = Application.persistentDataPath + '/'+File_Name;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            bf.Serialize(file,jsonEncoded);
            file.Close();
        }
        public void load(){
            string filePath = Application.persistentDataPath + '/'+File_Name;
            if(File.Exists(filePath)){
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open(filePath,FileMode.Open);
                string content = bf.Deserialize(fs).ToString();
                Debug.Log(content);
            }
        }

    }
    

}