using System;
using System.IO;

namespace GradeScores {
    class Program {
		static void Main(string[] args) {
			String fileLocation = "";
			String fileExtension = "";

			if (args.Length != 1) {
				Console.WriteLine("Invalid parameters, run with: grade-scores <filepath>.");
				System.Environment.Exit(1);
			}

			fileLocation = args[0];
			fileExtension = Path.GetExtension(fileLocation);

			if (fileExtension != ".txt" && fileExtension != "") {
				Console.WriteLine("Input parameter must be a valid file or .txt file");
				System.Environment.Exit(3);
			}

			ReadFile rf = new ReadFile(fileLocation);
			rf.GenerateList();

			WriteFile wf = new WriteFile(rf.GetSortedList(), fileLocation, fileExtension);
			wf.GenerateOutputFile();

        }
    }
}
