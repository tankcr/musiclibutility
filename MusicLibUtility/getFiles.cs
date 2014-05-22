using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace MusicLibUtility
{
    public class RecursiveFileSearch
    {
        public List<FileInfo> Files = new List<FileInfo>();
        public System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        public List<FileInfo> WalkDirectoryTree(System.IO.DirectoryInfo rootDir)
        {
            List<FileInfo> files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                FileInfo[] currentFiles = rootDir.GetFiles("*.*");    
                files.AddRange(currentFiles);
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we 
                    // want to open, delete or modify the file, then 
                    // a try-catch block is required here to handle the case 
                    // where the file has been deleted since the call to TraverseTree().
                    Console.WriteLine(fi.FullName);
                    Files.Add(fi);
                }

                // Now find all the subdirectories under this directory.
                subDirs = rootDir.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    files.AddRange(WalkDirectoryTree(dirInfo));
                    
                }
            }
            return files;
        }
    }
}