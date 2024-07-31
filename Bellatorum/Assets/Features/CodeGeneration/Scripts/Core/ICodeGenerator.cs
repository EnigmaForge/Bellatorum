namespace Features.CodeGeneration.Core {
    public interface ICodeGenerator {
        /// <summary>
        /// Set file name without .cs
        /// </summary>
        /// <param name="name">File name</param>
        /// <returns></returns>
        public ICodeGenerator SetName(string name);
        
        /// <summary>
        /// Set path to file folder
        /// </summary>
        /// <param name="path">Folder path</param>
        /// <returns></returns>
        public ICodeGenerator SetPath(string path);
        
        /// <summary>
        /// Generate empty class
        /// </summary>
        /// <param name="content">class content</param>
        public void GenerateClass(string content);
        
        /// <summary>
        /// Generate empty interface
        /// </summary>
        /// <param name="content">interface content</param>
        public void GenerateInterface(string content);
        
        /// <summary>
        /// Generate empty struct
        /// </summary>
        /// <param name="content">struct content</param>
        public void GenerateStruct(string content);
        
        /// <summary>
        /// Generate enum
        /// </summary>
        /// <param name="elements">Enum elements</param>
        /// <param name="isNumbered">Flag for enable numerate enum elements</param>
        /// <param name="offset">Offset at start number. Start number is 0</param>
        /// <param name="step">Step to increase element number</param>
        public void GenerateEnum(string[] elements, bool isNumbered = true, int offset = 0, int step = 1);
    }
}