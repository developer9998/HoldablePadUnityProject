using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[CustomEditor(typeof(Descriptor))]
//https://blog.theknightsofunity.com/use-customeditor-customize-script-inspector/

public class HoldableDescriptor : Editor
{
    private SerializedProperty Name;
    private SerializedProperty Author;
    private SerializedProperty Description;
    private SerializedProperty LeftHand;
    private SerializedProperty CustomColour;

    private SerializedProperty gunEnable;
    private SerializedProperty gunSounds;
    private SerializedProperty gunSpeed;
    private SerializedProperty gunCooldown;
    private SerializedProperty gunObject;
    private SerializedProperty audioMode;

    private SerializedProperty vibra;
    private SerializedProperty strenth;
    private SerializedProperty sTime;

    bool extraStuffsPanel;
    bool mainStuffPanel = true;
    private void OnEnable()
    {
        Name = serializedObject.FindProperty("Name");
        Author = serializedObject.FindProperty("Author");
        Description = serializedObject.FindProperty("Description");
        LeftHand = serializedObject.FindProperty("leftHand");
        CustomColour = serializedObject.FindProperty("customColours");
        gunEnable = serializedObject.FindProperty("gunEnabled");
        gunSounds = serializedObject.FindProperty("shootSound");

        gunSpeed = serializedObject.FindProperty("bulletSpeed");
        gunCooldown = serializedObject.FindProperty("bulletCooldown");
        gunObject = serializedObject.FindProperty("bulletObject");
        audioMode = serializedObject.FindProperty("audioMode");

        vibra = serializedObject.FindProperty("vibra");
        strenth = serializedObject.FindProperty("strenth");
        sTime = serializedObject.FindProperty("sTime");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Name, new GUIContent("Name"));
        EditorGUILayout.PropertyField(Author, new GUIContent("Author"));
        EditorGUILayout.PropertyField(Description, new GUIContent("Description"));
        EditorGUILayout.PropertyField(LeftHand, new GUIContent("Left Hand"));
        EditorGUILayout.PropertyField(CustomColour, new GUIContent("Custom Colours"));

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        EditorGUILayout.PropertyField(gunEnable, new GUIContent("Gun Mechanics"));

        if (gunEnable.boolValue == true)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(gunSpeed, new GUIContent("Ammo Speed"));
            EditorGUILayout.PropertyField(gunCooldown, new GUIContent("Ammo Cooldown"));
            EditorGUILayout.PropertyField(gunSounds, new GUIContent("Ammo Sound"));

            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(audioMode, new GUIContent("Looped"));
            EditorGUILayout.PropertyField(vibra, new GUIContent("Vibration"));

            if (vibra.boolValue == true)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(strenth, new GUIContent("Strength"));
                EditorGUILayout.PropertyField(sTime, new GUIContent("Duration"));

                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(gunObject, new GUIContent("Ammo Object"));

            EditorGUI.indentLevel--;
        }

        //EditorGUI.
        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();
    }

    public static void ExportHoldable(GameObject obj, string path)
    {
        GameObject selectedObject = obj;
        string assetBundleDirectoryTEMP = "Assets/ExportedHoldables";

        Descriptor descriptor = selectedObject.GetComponent<Descriptor>();

        if (!AssetDatabase.IsValidFolder("Assets/ExportedHoldables"))
        {
            AssetDatabase.CreateFolder("Assets", "ExportedHoldables");
        }

        string holdableName = descriptor.Name;
        string holdableAuthor = descriptor.Author;
        string holdableDescription = descriptor.Description;
        string holdableLHand = descriptor.leftHand.ToString();
        string holdableCustomColour = descriptor.customColours.ToString();

        string prefabPathTEMP = "Assets/ExportedHoldables/holdABLE.prefab";

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        PrefabUtility.SaveAsPrefabAsset(selectedObject.gameObject, prefabPathTEMP);
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPathTEMP);
        contentsRoot.name = "holdABLE";

        Text player_info = contentsRoot.AddComponent<Text>();
        string split = "$"; // splits each of the strings
        player_info.text = holdableName + split + holdableAuthor + split + holdableDescription + split + holdableLHand + split + holdableCustomColour;

        if (descriptor.gunEnabled == true)
        {
            GameObject soundObject = new GameObject();
            soundObject.name = "UsedBulletSoundEffect";
            soundObject.transform.SetParent(contentsRoot.transform, false);
            AudioSource soundSource = soundObject.AddComponent<AudioSource>();
            soundSource.volume = 0.15f;
            soundSource.clip = descriptor.shootSound;
            soundSource.playOnAwake = false;
            GameObject tempBullet = contentsRoot.GetComponent<Descriptor>().bulletObject;
            //if (contentsRoot.GetComponent<Descriptor>().bulletObject != null)
            //{
            //    DestroyImmediate(contentsRoot.GetComponent<Descriptor>().bulletObject);
            //}
            tempBullet.transform.SetParent(contentsRoot.transform, true);
            tempBullet.name = "UsedBulletGameObject";

            Text bulletInfo = tempBullet.AddComponent<Text>();
            string bulletInfoSplit = "$";
            bulletInfo.text = descriptor.bulletSpeed.ToString() + bulletInfoSplit + descriptor.bulletCooldown.ToString() + bulletInfoSplit + descriptor.audioMode.ToString();
            bulletInfo.enabled = false;
        }


        DestroyImmediate(contentsRoot.GetComponent<Descriptor>());
        if (File.Exists(prefabPathTEMP))
        {
            File.Delete(prefabPathTEMP);
        }

        string newprefabPath = "Assets/ExportedHoldables/" + contentsRoot.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, newprefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);
        AssetImporter.GetAtPath(newprefabPath).SetAssetBundleNameAndVariant("holdableAssetBundle", "");

        if (!Directory.Exists("Assets/ExportedHoldables"))
        {
            Directory.CreateDirectory(assetBundleDirectoryTEMP);
        }

        string asset_new = assetBundleDirectoryTEMP + "/" + holdableName;
        if (File.Exists(asset_new + ".holdable"))
        {
            File.Delete(asset_new + ".holdable");
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectoryTEMP, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        if (File.Exists(newprefabPath))
        {
            File.Delete(newprefabPath);
        }

        string asset_temporary = assetBundleDirectoryTEMP + "/holdableAssetBundle";
        string metafile = asset_temporary + ".meta";
        if (File.Exists(asset_temporary))
        {
            File.Move(asset_temporary, asset_new + ".holdable");
        }

        AssetDatabase.Refresh();
        Debug.ClearDeveloperConsole();

        string path1 = assetBundleDirectoryTEMP + "/" + holdableName + ".holdable";
        string path2 = path;

        if (!File.Exists(path2)) // add
        {
            File.Move(path1, path2);
        }
        else // replace
        {
            File.Delete(path2);
            File.Move(path1, path2);
        }

        string whichHand = holdableLHand == "true" ? "Left" : "Right";
        EditorUtility.DisplayDialog("Export Success", $"Your holdable was exported!", "OK");

        string holdablePath = path + "/";
        EditorUtility.RevealInFinder(holdablePath);

        if (AssetDatabase.IsValidFolder("Assets/ExportedHoldables"))
        {
            AssetDatabase.DeleteAsset("Assets/ExportedHoldables");
        }
    }
}
