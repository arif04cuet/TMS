using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msi.UtilityKit
{
    public static class FileUtilities
    {

        public static StringBuilder ReadAllJsonFile(string filesDirectoryPath)
        {
            FileStream file = null;
            StreamReader reader = null;
            StringBuilder jsonDataSB = null;
            string jsonDataTemp;
            Directory.EnumerateFiles(filesDirectoryPath, "*.json", SearchOption.TopDirectoryOnly).ToList().ForEach(filePath =>
            {
                jsonDataTemp = string.Empty;
                file = File.OpenRead(filePath);
                reader = new StreamReader(file);

                var fileName = Path.GetFileNameWithoutExtension(filePath);
                jsonDataTemp = string.Format("\"{0}\" : {1}", fileName, reader.ReadToEnd());

                if (jsonDataSB == null)
                {
                    jsonDataSB = new StringBuilder();
                    jsonDataSB.AppendLine(jsonDataTemp);
                }
                else
                {
                    jsonDataSB.Append(",").AppendLine(jsonDataTemp);
                }
            });
            return jsonDataSB;
        }

        public static async Task<byte[]> ToBytesAsync(string path)
        {
            using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var fileBytes = new byte[fileStream.Length];
                await fileStream.ReadAsync(fileBytes, 0, (int)fileStream.Length);
                return fileBytes;
            }
        }

        public static async Task<string> WriteFileAsync(string directoryPath, string baseFileName, string extension, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("The content cannot be null, empty or white-space.", nameof(content));
            }
            return await WriteFileAsync(directoryPath, baseFileName, extension, Encoding.Unicode.GetBytes(content));
        }

        public static async Task<string> WriteFileAsync(string directoryPath, string baseFileName, string extension, byte[] encodedContent)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException("The directory path cannot be null, empty or white-space.", nameof(directoryPath));
            }

            if (directoryPath.Intersect(Path.GetInvalidPathChars()).Any())
            {
                throw new ArgumentException("The directory path cannot contain invalid characters.", nameof(directoryPath));
            }

            if (string.IsNullOrWhiteSpace(baseFileName))
            {
                throw new ArgumentException("The base file name cannot be null, empty or white-space.", nameof(baseFileName));
            }

            if (baseFileName.Intersect(Path.GetInvalidFileNameChars()).Any())
            {
                throw new ArgumentException("The base file name cannot contain invalid characters.", nameof(baseFileName));
            }

            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentException("The extension cannot be null, empty or white-space.", nameof(extension));
            }

            if (extension.All(char.IsLetterOrDigit) == false)
            {
                throw new ArgumentException("The extension cannot contain invalid characters.", nameof(extension));
            }

            if (encodedContent == null)
            {
                throw new ArgumentException("The encoded content cannot be null.", nameof(encodedContent));
            }

            if (encodedContent.Length == 0)
            {
                throw new ArgumentException("The encoded content cannot be empty.", nameof(encodedContent));
            }

            using (var fileStream = CreateFileStream(directoryPath, baseFileName, extension))
            {
                await fileStream.WriteAsync(encodedContent, 0, encodedContent.Length);
                return Path.GetFileNameWithoutExtension(fileStream.Name);
            }
        }

        public static FileStream CreateFileStream(string directoryPath, string baseFileName, string extension)
        {
            string fullFilePath;
            var baseFilePath = Path.Combine(directoryPath, baseFileName);
            var fullFilePathElements = new[] { baseFilePath, "(", null, ").", extension };
            int number = 0;

            do
            {
                fullFilePathElements[2] = (++number).ToString();

                fullFilePath = string.Concat(fullFilePathElements);
            }
            while (File.Exists(fullFilePath));

            return new FileStream(fullFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, true);
        }

        /// <summary>
        /// Generates a unique directory name in the temporary folder.  
        /// Caller must delete when finished. 
        /// </summary>
        /// <param name="createDirectory"></param>
        public static string GetTemporaryDirectory(bool createDirectory = true)
        {
            string temporaryDirectory = Path.Combine(Path.GetTempPath(), "Temporary" + Guid.NewGuid().ToString("N"));

            if (createDirectory)
            {
                Directory.CreateDirectory(temporaryDirectory);
            }

            return temporaryDirectory;
        }

        /// <summary>
        /// Generates a unique temporary file name with a given extension in the temporary folder.
        /// File is guaranteed to be unique.
        /// Extension may have an initial period.
        /// File will NOT be created.
        /// May throw IOException.
        /// </summary>
        public static string GetTemporaryFileName(string extension)
        {
            return GetTemporaryFile(null, extension, false);
        }

        /// <summary>
        /// Generates a unique temporary file name with a given extension in the temporary folder.
        /// If no extension is provided, uses ".tmp".
        /// File is guaranteed to be unique.
        /// Caller must delete it when finished.
        /// </summary>
        public static string GetTemporaryFile()
        {
            return GetTemporaryFile(".tmp");
        }

        /// <summary>
        /// Generates a unique temporary file name with a given extension in the temporary folder.
        /// File is guaranteed to be unique.
        /// Extension may have an initial period.
        /// Caller must delete it when finished.
        /// May throw IOException.
        /// </summary>
        public static string GetTemporaryFile(string extension)
        {
            return GetTemporaryFile(null, extension);
        }

        /// <summary>
        /// Creates a file with unique temporary file name with a given extension in the specified folder.
        /// File is guaranteed to be unique.
        /// Extension may have an initial period.
        /// If folder is null, the temporary folder will be used.
        /// Caller must delete it when finished.
        /// May throw IOException.
        /// </summary>
        public static string GetTemporaryFile(string directory, string extension, bool createFile = true)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new ArgumentNullException("The directory cannot be null, empty or white-space.", nameof(directory));
            }

            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentNullException("The extension cannot be null, empty or white-space.", nameof(extension));
            }

            if (extension[0] != '.')
            {
                extension = '.' + extension;
            }

            directory = directory ?? Path.GetTempPath();

            Directory.CreateDirectory(directory);

            string file = Path.Combine(directory, $"tmp{Guid.NewGuid():N}{extension}");

            if(!File.Exists(file))
            {
                throw new Exception("Guid should be unique");
            }

            if (createFile)
            {
                File.WriteAllText(file, string.Empty);
            }

            return file;
        }

        public static void CopyDirectory(string source, string dest)
        {
            Directory.CreateDirectory(dest);

            DirectoryInfo sourceInfo = new DirectoryInfo(source);
            foreach (var fileInfo in sourceInfo.GetFiles())
            {
                string destFile = Path.Combine(dest, fileInfo.Name);
                fileInfo.CopyTo(destFile);
            }
            foreach (var subdirInfo in sourceInfo.GetDirectories())
            {
                string destDir = Path.Combine(dest, subdirInfo.Name);
                CopyDirectory(subdirInfo.FullName, destDir);
            }
        }


    }
}
