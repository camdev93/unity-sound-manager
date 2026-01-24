using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    public string id;
    public string path;
}

[System.Serializable]
public class ISoundData
{
    public List<SoundData> sounds = new List<SoundData>();
}

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string jsonPath = Path.Combine(Application.dataPath, "Scripts/Audio/SoundData.json");
        string jsonContent = File.ReadAllText(jsonPath);
        ISoundData soundData = JsonUtility.FromJson<ISoundData>(jsonContent);
        
        soundData.sounds.Add(new SoundData { id = "Footstep", path = "Assets/Audio/Footstep.wav" });
        soundData.sounds.Add(new SoundData { id = "Click", path = "Assets/Audio/Click.wav" });
        
        string updatedJson = JsonUtility.ToJson(soundData, true);
        File.WriteAllText(jsonPath, updatedJson);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
