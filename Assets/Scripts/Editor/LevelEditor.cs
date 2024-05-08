using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

public class LevelEditor : EditorWindow
{
    private LevelData levelData;

    private SpriteRenderer background;
    [SerializeField] private List<DifferenceSpritesEditor> differenceSprites = new();
    [SerializeField] private List<SpriteRenderer> bothSprites = new();
    private string levelDataName = "LevelData[number]";

    [MenuItem("Level/Level Editor")]
    public static void Init()
    {
        var wnd = GetWindow<LevelEditor>();
        wnd.titleContent = new GUIContent("Level Editor");
    }

    private void OnGUI()
    {
        ScriptableObject scriptableObj = this;
        SerializedObject serialObj = new SerializedObject(scriptableObj);
        SerializedProperty differenceSerialProp = serialObj.FindProperty("differenceSprites");
        SerializedProperty bothSpritesSerialProp = serialObj.FindProperty("bothSprites");

        EditorGUILayout.Space(20);
        GUILayout.Label("Background");
        background = (SpriteRenderer)EditorGUILayout.ObjectField(background, typeof(SpriteRenderer), true);

        EditorGUILayout.Space(20);
        GUILayout.Label("Difference Sprites");
        EditorGUILayout.PropertyField(differenceSerialProp, true);

        EditorGUILayout.Space(10);
        GUILayout.Label("Both Level Sprites");
        EditorGUILayout.PropertyField(bothSpritesSerialProp, true);

        EditorGUILayout.Space(10);
        levelDataName = EditorGUILayout.TextField("Level Data Name: ", levelDataName);

        EditorGUILayout.Space(10);
        if (GUILayout.Button(new GUIContent("Create Level"), GUILayout.MinWidth(100), GUILayout.MinHeight(40), GUILayout.Width(40), GUILayout.Height(40), GUILayout.ExpandWidth(true)))
        {
            CreateLevel();
        }

        serialObj.ApplyModifiedProperties();
    }

    private void CreateLevel()
    {
        if(levelDataName == "")
        {
            Debug.Log("Level Data name is empty!");
            return;
        }

        levelData = CreateInstance<LevelData>();
        if (!FillLevelData())
        {
            Destroy(levelData);
            return;
        }

        AssetDatabase.CreateAsset(levelData, "Assets/Resources/LevelData/" + levelDataName + ".asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        
        Selection.activeObject = levelData;

        Debug.Log("Create Level");
    }

    private bool FillLevelData()
    {
        if (levelData.differences == null) levelData.differences = new();
        if (levelData.bothLevelSprites == null) levelData.bothLevelSprites = new();


        if(background.sprite == null)
        {
            Debug.LogError("Background has both null references!");
            return false;
        }
        levelData.background = SpriteRendererToData(background);


        levelData.differences.Clear();
        for (int i = 0;i < differenceSprites.Count;++i)
        {
            if(differenceSprites[i].sprite1 == null && differenceSprites[i].sprite2 == null)
            {
                Debug.LogError("Difference Sprites, index[i] has both null references!");
                return false;
            }

            levelData.differences.Add(new DifferenceData(SpriteRendererToData(differenceSprites[i].sprite1), SpriteRendererToData(differenceSprites[i].sprite2)));
        }


        levelData.bothLevelSprites.Clear();
        for (int i = 0;i < bothSprites.Count;++i)
        {
            if (bothSprites[i] == null)
            {
                Debug.LogError("Both Sprites, index[i] has null reference!");
                return false;
            }

            levelData.bothLevelSprites.Add(SpriteRendererToData(bothSprites[i]));
        }

        return true;
    }

    private SpriteData SpriteRendererToData(SpriteRenderer spriteRenderer) 
        => (spriteRenderer != null && spriteRenderer.sprite != null) ? new SpriteData(spriteRenderer.sprite, spriteRenderer.transform.localPosition, spriteRenderer.sortingOrder) : null;

}

[Serializable]
public class DifferenceSpritesEditor
{
    public SpriteRenderer sprite1, sprite2;
}