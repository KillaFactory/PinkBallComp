using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace FruitBombSelect
{
    public class Spacegen : MonoBehaviour
    {
        [PostProcessBuild(int.MaxValue)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
                return;

            List<string> paths = new(Directory.GetFiles(pathToBuiltProject, "*.h", SearchOption.AllDirectories)) { };
            paths.AddRange(Directory.GetFiles(pathToBuiltProject, "*.mm", SearchOption.AllDirectories));
            paths.AddRange(Directory.GetFiles(pathToBuiltProject, "*.c", SearchOption.AllDirectories));
            paths.AddRange(Directory.GetFiles(pathToBuiltProject, "*.cpp", SearchOption.AllDirectories));

            foreach (string file in paths)
            {
                string content = File.ReadAllText(file);

                content += GenerateRandomSpaces();
                File.WriteAllText(file, content);
            }

            Debug.Log("Post build process complete. Unique spaces added to files.");
        }

        private static string GenerateRandomSpaces()
        {
            int numberOfSpaces = Random.Range(1, 21);
            return new string(' ', numberOfSpaces);
        }
    }
}