using System;
using System.IO;
using UnityEditor;

namespace Features.CodeGeneration.Core {
    public class CodeGenerator : ICodeGenerator {
        private string _name;
        private string _path;
        
        public ICodeGenerator SetName(string name) {
            _name = name;
            return this;
        }

        public ICodeGenerator SetPath(string path) {
            _path = path;
            return this;
        }

        public void GenerateClass(string content) {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
                throw new Exception("Empty name or path");
            
            string filePath = Path.Combine(_path, _name + ".cs");
            string classNamespace = GetNamespace();

            if (Directory.Exists(_path) is false)
                Directory.CreateDirectory(_path);

            using (StreamWriter writer = new(filePath)) {
                InsertHeader(writer);

                int tabulationCount = 0;
                bool generateNamespace = string.IsNullOrEmpty(classNamespace) is false;
                if(generateNamespace) {
                    writer.WriteLine("namespace " + classNamespace);
                    OpenBlock(writer, tabulationCount);
                    tabulationCount++;
                }
                
                WriteLine(writer, "public class " + _name, tabulationCount);
                OpenBlock(writer, tabulationCount);
                tabulationCount++;
                
                WriteLine(writer, content);
                
                tabulationCount--;
                CloseBlock(writer, tabulationCount);
                tabulationCount--;
                if (generateNamespace)
                    CloseBlock(writer, tabulationCount);

                writer.Close();
            }
            
            ClearParameters();
            AssetDatabase.Refresh();
        }

        public void GenerateInterface(string content) {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
                throw new Exception("Empty name or path");
            
            string filePath = Path.Combine(_path, _name + ".cs");
            string classNamespace = GetNamespace();

            if (Directory.Exists(_path) is false)
                Directory.CreateDirectory(_path);

            using (StreamWriter writer = new(filePath)) {
                InsertHeader(writer);

                int tabulationCount = 0;
                bool generateNamespace = string.IsNullOrEmpty(classNamespace) is false;
                if(generateNamespace) {
                    writer.WriteLine("namespace " + classNamespace);
                    OpenBlock(writer, tabulationCount);
                    tabulationCount++;
                }
                
                WriteLine(writer, "public interface I" + _name, tabulationCount);
                OpenBlock(writer, tabulationCount);
                tabulationCount++;
                
                WriteLine(writer, content);
                
                tabulationCount--;
                CloseBlock(writer, tabulationCount);
                tabulationCount--;
                if (generateNamespace)
                    CloseBlock(writer, tabulationCount);

                writer.Close();
            }
            
            ClearParameters();
            AssetDatabase.Refresh();
        }

        public void GenerateStruct(string content) {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
                throw new Exception("Empty name or path");
            
            string filePath = Path.Combine(_path, _name + ".cs");
            string classNamespace = GetNamespace();

            if (Directory.Exists(_path) is false)
                Directory.CreateDirectory(_path);

            using (StreamWriter writer = new(filePath)) {
                InsertHeader(writer);

                int tabulationCount = 0;
                bool generateNamespace = string.IsNullOrEmpty(classNamespace) is false;
                if(generateNamespace) {
                    writer.WriteLine("namespace " + classNamespace);
                    OpenBlock(writer, tabulationCount);
                    tabulationCount++;
                }
                
                WriteLine(writer, "public struct " + _name, tabulationCount);
                OpenBlock(writer, tabulationCount);
                tabulationCount++;
                
                WriteLine(writer, content);
                
                tabulationCount--;
                CloseBlock(writer, tabulationCount);
                tabulationCount--;
                if (generateNamespace)
                    CloseBlock(writer, tabulationCount);

                writer.Close();
            }
            
            ClearParameters();
            AssetDatabase.Refresh();
        }

        public void GenerateEnum(string[] elements, bool isNumbered = true, int offset = 0, int step = 1) {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
                throw new Exception("Empty name or path");
            
            string filePath = Path.Combine(_path, _name + ".cs");
            string classNamespace = GetNamespace();

            if (Directory.Exists(_path) is false)
                Directory.CreateDirectory(_path);

            using (StreamWriter writer = new(filePath)) {
                InsertHeader(writer);

                int tabulationCount = 0;
                bool generateNamespace = string.IsNullOrEmpty(classNamespace) is false;
                if(generateNamespace) {
                    writer.WriteLine("namespace " + classNamespace);
                    OpenBlock(writer, tabulationCount);
                    tabulationCount++;
                }
                
                WriteLine(writer, "public enum " + _name, tabulationCount);
                OpenBlock(writer, tabulationCount);
                tabulationCount++;
                
                int enumElementNumber = offset;
                foreach (string enumElement in elements) {
                    string enumElementLine = enumElement + (isNumbered ? " = " + enumElementNumber : string.Empty) + ",";
                    WriteLine(writer, enumElementLine, tabulationCount);
                    enumElementNumber += step;
                }
                
                tabulationCount--;
                CloseBlock(writer, tabulationCount);
                tabulationCount--;
                if (generateNamespace)
                    CloseBlock(writer, tabulationCount);

                writer.Close();
            }

            ClearParameters();
            AssetDatabase.Refresh();
        }

        private string GetNamespace() {
            string[] splitAssetsPath = _path.Split("Assets/");
            return splitAssetsPath.Length == 2 ? splitAssetsPath[1].Replace("/", ".") : string.Empty;
        }

        private void InsertHeader(StreamWriter writer) {
            writer.WriteLine("//generated code");
            writer.WriteLine();
        }

        private void OpenBlock(StreamWriter writer, int tabulationCount = 0) {
            string openBlockString = "{";
            for (int tabulationIndex = 0; tabulationIndex < tabulationCount; tabulationIndex++)
                openBlockString = openBlockString.Insert(0, "    ");
            
            writer.WriteLine(openBlockString);
        }

        private void CloseBlock(StreamWriter writer, int tabulationCount = 0) {
            string closeBlockString = "}";
            for (int tabulationIndex = 0; tabulationIndex < tabulationCount; tabulationIndex++)
                closeBlockString = closeBlockString.Insert(0, "    ");
            
            writer.WriteLine(closeBlockString);
        }

        private void WriteLine(StreamWriter writer, string line, int tabulationCount = 0) {
            for (int tabulationIndex = 0; tabulationIndex < tabulationCount; tabulationIndex++)
                line = line.Insert(0, "    ");
            
            writer.WriteLine(line);
        }

        private void ClearParameters() {
            _name = string.Empty;
            _path = string.Empty;
        }
    }
}
