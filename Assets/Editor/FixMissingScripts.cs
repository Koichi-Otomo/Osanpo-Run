using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class FixMissingScripts : EditorWindow
{
    [MenuItem("Tools/Fix Missing Scripts")]
    public static void ShowWindow()
    {
        GetWindow<FixMissingScripts>("Fix Missing Scripts");
    }

    void OnGUI()
    {
        GUILayout.Label("Missing Script Fixer", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Fix All Scenes"))
        {
            FixAllScenes();
        }
        
        if (GUILayout.Button("Fix Current Scene"))
        {
            FixCurrentScene();
        }
    }

    static void FixAllScenes()
    {
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
        int fixedCount = 0;
        
        foreach (string guid in sceneGuids)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(guid);
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            
            int removed = RemoveMissingScriptsInScene();
            if (removed > 0)
            {
                EditorSceneManager.SaveScene(scene);
                fixedCount += removed;
                Debug.Log($"Fixed {removed} missing scripts in {scenePath}");
            }
        }
        
        Debug.Log($"Total fixed: {fixedCount} missing scripts");
        AssetDatabase.Refresh();
    }
    
    static void FixCurrentScene()
    {
        int removed = RemoveMissingScriptsInScene();
        if (removed > 0)
        {
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            Debug.Log($"Fixed {removed} missing scripts in current scene");
        }
        else
        {
            Debug.Log("No missing scripts found in current scene");
        }
    }

    static int RemoveMissingScriptsInScene()
    {
        GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        int removedCount = 0;

        foreach (GameObject go in gameObjects)
        {
            Component[] components = go.GetComponents<Component>();
            
            for (int i = components.Length - 1; i >= 0; i--)
            {
                if (components[i] == null)
                {
                    Debug.Log($"Removing missing script from: {go.name}");
                    GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
                    removedCount++;
                    break; // GameObjectUtility removes all missing scripts at once
                }
            }
        }
        
        return removedCount;
    }
}
