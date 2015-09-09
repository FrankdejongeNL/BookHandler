using System.IO;
using Newtonsoft.Json;

namespace BookLibrary.DAL
{
    /// <summary>
    /// Handles all changes to the JSON based data file
    /// </summary>
    public class JSONDataHandler
    {
    
        private const string FileLocation = @"";

        /// <summary>
        /// Private Function to load JSON data into the book list
        /// </summary>
        public static string LoadJSONData()
        {
            return File.ReadAllText(FileLocation);
        }

        /// <summary>
        /// Saves all the bookList back into the json data.
        /// </summary>
        public static void SaveJSONData(object jsonData)
        {
            File.WriteAllText(FileLocation, JsonConvert.SerializeObject(jsonData));
        }
    }
}
