using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
		// Return the size, in bytes, of the given file
		public static long GetFileSize(string filePath)
		{
			return new FileInfo(filePath).Length;
		}

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
            long bites = 0;

            // Creates an array of all files within the directory
            string[] files = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);

            // For each file within the directory it calls the GetFileSize function and adds the result to the bites variable
            foreach (string file in files)
            {
                bites += GetFileSize(file);
            }
            return bites;
		}

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{
            // Creates an array of all files within the directory
            string[] fileCount = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);

            // Returns the length of the variable
            return fileCount.Length;
		}

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            // Creates an array of all subDirectories within the directory
            string[] dirCount = Directory.GetDirectories(directory);
            int dirNum = 0;

            // Counts up for every file in the array
            foreach (string dir in dirCount)
            {
                dirNum += 1;
            }
            return dirNum;
        }

        // Get the path and size (in bytes) of the smallest file below the given directory
        public static Tuple<string, long> GetSmallestFile(string directory)
        {
            // Creates an array of all files within the directory
            string[] files = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);
            
            // Creates a variable with the maximum possible value
            long size = long.MaxValue;
            string smallestFile = "";
            Tuple<string, long> smallFile;

            // Checks whether each file is smaller and if so makes it the new compared to variable
            foreach (string file in files)
            {
                if (size > GetFileSize(file))
                {
                    smallestFile = file;
                    size = GetFileSize(file);
                }
            }
            
            smallFile = new Tuple<string, long>(smallestFile, size);

            return smallFile;
        }

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
            // Creates an array of all files within the directory
            string[] files = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);
            long size = 0;
            string longestFile = "";
            Tuple<string, long> longFile;

            // Checks whether each file is longer and if so makes it the new compared to variable
            foreach (string file in files)
            {
                if (size < GetFileSize(file))
                {
                    longestFile = file;
                    size = GetFileSize(file);
                }
            }

            longFile = new Tuple<string, long>(longestFile, size);

            return longFile;
        }

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
            // Creates an array of all files within the directory
            string[] files = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);
            List<string> correctFiles = new List<string>();

            // Checks each file in the array to the size inputted
            foreach (string file in files)
            {
                if (size == GetFileSize(file))
                {
                    correctFiles.Add(file);
                }
            }
            return correctFiles;
        }
	}
}
