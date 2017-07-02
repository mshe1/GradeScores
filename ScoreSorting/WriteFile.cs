/**
 * A class for handling writing a sorted list of entries to an equivalent file
 * with the suffix "-graded".
 * 
 * Version: 1.0
 * Date: 01 July 2017
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace GradeScores {
	public class WriteFile {
		private List<UserEntry> userList;
		String filepath;
		String fileExtension;

		public WriteFile(List<UserEntry> sortedList, String filepath, String fileExtension) {
			this.userList = sortedList;
			this.filepath = filepath;
			this.fileExtension = fileExtension;
		}

		/// <summary>
		/// Attempts to create and write to a file with the same name and location
		/// as the input file with the suffix "-graded".
		/// </summary>
		public void GenerateOutputFile() {
			try {
				//Create output path using known filepath and file extension length
				String outputPath = filepath.Insert(filepath.Length - fileExtension.Length, "-graded");
				System.IO.StreamWriter outputFile = new System.IO.StreamWriter(outputPath);
				for (int i = 0; i < userList.Count; i++) {
					//Write each entry to output file using UserEntry's correctly formatted
					//toString method.
					outputFile.Write(userList[i].toString());
					//Print each entry to console
					Console.Write(userList[i].toString());
				}
				outputFile.Close();
				//Print message to inform user program has finished running
				String fileName = Path.GetFileName(filepath);
				String outputName = fileName.Insert(fileName.Length - fileExtension.Length, "-graded");
				Console.WriteLine("Finished: created "+outputName);

			} catch(Exception e) {
				Console.WriteLine("Could not create output file at: "+filepath);
				Console.WriteLine(e.ToString());
				System.Environment.Exit(4);
			}
		}

	}
}
