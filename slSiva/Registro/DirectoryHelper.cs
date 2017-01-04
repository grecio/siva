using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Registro
{
    public static class DirectoryHelper
    {   
        public static IEnumerable<string> GetFiles(string path,
                            string searchPatternExpression = "",
                            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            Regex reSearchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);
            return Directory.EnumerateFiles(path, "*", searchOption)
                            .Where(file =>
                                     reSearchPattern.IsMatch(Path.GetExtension(file))).OrderByDescending(item => item);
        }
                
        public static IEnumerable<string> GetFiles(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return searchPatterns.AsParallel()
                   .SelectMany(searchPattern =>
                          Directory.EnumerateFiles(path, searchPattern, searchOption)).OrderByDescending(item => item);
        }
    }
}
