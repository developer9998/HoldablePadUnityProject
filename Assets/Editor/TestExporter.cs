using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CreateObject : EditorWindow
{
    private Descriptor[] notes;

    [MenuItem("Holdable Pad/Holdable Exporter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CreateObject), false, "Holdable Exporter", false);
    }

    private void OnFocus()
    {
        notes = FindObjectsOfType<Descriptor>();
    }

    public Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {
        var window = GetWindow(typeof(CreateObject), false, "Holdable Exporter", false);

        int ScrollSpace = (16 + 20) + (16 + 17 + 17 + 20 + 20);
        foreach (var note in notes)
        {
            if (note != null)
            {
                ScrollSpace += (16 + 17 + 17 + 20 + 20);
            }
        }

        float currentWindowWidth = EditorGUIUtility.currentViewWidth;
        float windowWidthIncludingScrollbar = currentWindowWidth;
        if (window.position.size.y >= ScrollSpace)
        {
            windowWidthIncludingScrollbar += 30;
        }
        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, EditorGUIUtility.currentViewWidth, window.position.size.y), scrollPosition, new Rect(0, 0, EditorGUIUtility.currentViewWidth - 20, ScrollSpace), false, false);

        GUILayout.Label("Notes", EditorStyles.boldLabel, GUILayout.Height(16));
        GUILayout.Space(20);

        foreach (Descriptor note in notes)
        {
            if (note != null)
            {
                GUILayout.Label("GameObject : " + note.gameObject.name, EditorStyles.boldLabel, GUILayout.Height(16));
                note.Name = EditorGUILayout.TextField("Name:", note.Name, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(17));
                note.Author = EditorGUILayout.TextField("Author:", note.Author, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(17));
                note.Description = EditorGUILayout.TextField("Description:", note.Description, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(17));

                if (GUILayout.Button("Export " + note.Name, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(20)))
                {
                    GameObject noteObject = note.gameObject;
                    if (noteObject != null && note != null)
                    {
                        if (note.Name != "")
                        {
                            if (note.Author != "")
                            {
                                if (note.Description != "")
                                {
                                    EditorUtility.SetDirty(note);

                                    foreach (Collider collider in noteObject.GetComponentsInChildren<Collider>())
                                    {
                                        Destroy(collider);
                                    }

                                    BuildAssetBundle(note.gameObject);
                                }
                                else
                                {
                                    EditorUtility.DisplayDialog("Build Failed", "Please include a description in your Descriptor component.", "OK");
                                }
                            }
                            else
                            {
                                EditorUtility.DisplayDialog("Build Failed", "Please include an author in your Descriptor component.", "OK");
                            }
                        }
                        else
                        {
                            EditorUtility.DisplayDialog("Build Failed", "Please include a name in your Descriptor component.", "OK");
                        }
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Build Failed", "GameObject could not be found.", "OK");
                    }
                }
                GUILayout.Space(20);
            }
        }
        GUI.EndScrollView();
    }


    static public void BuildAssetBundle(GameObject obj)
    {
        var selectedObject = obj;
        Descriptor descriptor = selectedObject.GetComponent<Descriptor>();

        if (!AssetDatabase.IsValidFolder("Assets/ExportedHoldables"))
        {
            AssetDatabase.CreateFolder("Assets", "ExportedHoldables");
        }

        string holdableName = descriptor.Name;
        string holdableAuthor = descriptor.Author;
        string holdableDescription = descriptor.Description;
        string holdableLHand = descriptor.leftHand.ToString();
        //string empty = "";
        //bool includedName = holdableName != empty;
        //bool includedAuthor = holdableAuthor != empty;
        //bool includedDescription = holdableDescription != empty;

        //if (!includedName)
        //{
        //    EditorUtility.DisplayDialog("Build Failed", "Please include a name in your Descriptor component.", "OK");
        //    return;
        //}
        //else if (!includedAuthor)
        //{
        //    EditorUtility.DisplayDialog("Build Failed", "Please include an author in your Descriptor component.", "OK");
        //    return;
        //}
        //else if (!includedDescription)
        //{
        //    EditorUtility.DisplayDialog("Build Failed", "Please include a description in your Descriptor component.", "OK");
        //    return;
        //}

        string prefabPath = "Assets/ExportedHoldables/holdABLE.prefab";

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        PrefabUtility.SaveAsPrefabAsset(selectedObject.gameObject, prefabPath);
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPath);
        contentsRoot.name = "holdABLE";

        Text player_info = contentsRoot.AddComponent<Text>();
        string split = "$"; // splits each of the strings
        player_info.text = holdableName + split + holdableAuthor + split + holdableDescription + split + holdableLHand;

        Object.DestroyImmediate(contentsRoot.GetComponent<Descriptor>());
        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
        }

        string newprefabPath = "Assets/ExportedHoldables/" + contentsRoot.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, newprefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);
        AssetImporter.GetAtPath(newprefabPath).SetAssetBundleNameAndVariant("holdableAssetBundle", "");

        string assetBundleDirectory = "Assets/ExportedHoldables";
        if (!Directory.Exists("Assets/ExportedHoldables"))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        string asset_new = assetBundleDirectory + "/" + holdableName;
        if (File.Exists(asset_new + ".holdable"))
        {
            File.Delete(asset_new + ".holdable");
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        if (File.Exists(newprefabPath))
        {
            File.Delete(newprefabPath);
        }

        string asset_manifest = assetBundleDirectory + "/holdableAssetBundle.manifest";
        Debug.Log(asset_manifest);
        if (File.Exists(asset_manifest))
        {
            File.Delete(asset_manifest);
        }

        string folder_manifest = assetBundleDirectory;
        if (File.Exists(folder_manifest))
        {
            File.Delete(folder_manifest);

            File.Delete(folder_manifest + ".manifest");
        }

        string asset_temporary = assetBundleDirectory + "/holdableAssetBundle";
        string metafile = asset_temporary + ".meta";
        if (File.Exists(asset_temporary))
        {

            File.Move(asset_temporary, asset_new + ".holdable");
            Debug.Log(metafile);
        }

        AssetDatabase.Refresh();
        Debug.ClearDeveloperConsole();

        string whichHand = holdableLHand == "true" ? "left" : "right";
        EditorUtility.DisplayDialog("Build Success", $"{holdableName} was successfully built! ({whichHand} hand)", "OK");
    }
}