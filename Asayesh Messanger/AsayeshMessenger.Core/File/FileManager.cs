
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{

    public class FileManager:IFileManager
    {
        public string NormalizePath(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return path.Replace('/', '\\').Trim();
            else
                return path.Replace('\\', '/').Trim();
        }

        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Write the text to the soecified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, append the text to the file</param>
        /// <returns></returns>
        public async Task WriteTextToFileAsync(string text, string path, bool append = false)
        {
            // TODO: Add exception catching

            path = NormalizePath(path);
            path = ResolvePath(path);

            await AsyncAwaiter.AwaitAsync(nameof(FileManager) + path, async () =>
              {
                  // TODO: Add IoC.Task.Run

                  await IoC.Task.Run(() =>
                  {
                      using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                          fileStream.Write(text);
                  });
              });
        }
    }
}
