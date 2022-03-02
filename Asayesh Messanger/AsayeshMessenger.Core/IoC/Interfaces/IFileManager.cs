
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{

    public interface IFileManager
    {
        /// <summary>
        /// Write the text to the soecified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, append the text to the file</param>
        /// <returns></returns>
        Task WriteTextToFileAsync(string text, string path, bool append= false);

        string NormalizePath(string path);

        string ResolvePath(string path);
    }
}
