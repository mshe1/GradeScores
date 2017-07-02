/**
 * A class for handling reading a file and generating a list 
 * + sorted list of the data in the file. Ensures data is valid and 
 * and in the correct format.
 * 
 * Version: 1.0
 * Date: 01 July 2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace GradeScores {
	public class ReadFile {
		List<UserEntry> userList;
		List<UserEntry> sortedList;
		String filepath;

		public ReadFile(String filepath) {
			userList = new List<UserEntry>();
			this.filepath = filepath;
		}

		/// <summary>Takes a filepath and generates a list of user entries.
		///	Sorts the generated list by score, first name, then surname. </summary>
		public void GenerateList() {
			try {
				//Read all lines in input file and construct array of all entries
				String[] lines = System.IO.File.ReadAllLines(filepath);
				foreach (String line in lines) {
					//Split each entry by ", " to create an entry for each name and score.
					String[] userLine = Regex.Split(line, ", ");
					//Use CheckEntry method to ensure each input line is valid.
					if(CheckEntry(userLine)) {
						int score;
						int.TryParse(userLine[2], out score);
						UserEntry newEntry = new UserEntry(userLine[1], userLine[0], score);
						userList.Add(newEntry);
					}
				}
			} catch (FileNotFoundException e) {
				Console.WriteLine("Could not find input file at: " + filepath);
				Console.WriteLine(e.ToString());
				throw;
			}
			//Use SortList method to sort the list by score, surname, then first name.
			SortList();
		}

		/// <summary>
		/// Sorts the generated list by score, surname then first name using LINQ. 
		/// Stores the sorted list as a list of UserEntry. </summary>
		private void SortList() {
			if (userList.Count != 0) {
				sortedList = userList.OrderByDescending(user => user.GetScore()).
					ThenBy(user => user.GetLastName()).
					ThenBy(user => user.GetFirstName()).
					ToList();
			} else {
				sortedList = new List<UserEntry>();
			}
		}

		/// <summary>
		/// Takes a separates string from the input file and ensures all data in 
		/// entry is valid. </summary>
		/// <param name="user">A separated string containing a first name, 
		/// surname and score.</param>
		/// <returns>True if all data is valid, false otherwise.</returns>
		private Boolean CheckEntry(String[] user) {
			int testInt;
			try {
				if (user.Length != 3) {
					throw new InvalidDataException("Input file has invalid data, must be in the format<Surname>, < First Name >, Score");
				}
				if (String.IsNullOrWhiteSpace(user[0]) || String.IsNullOrWhiteSpace(user[1])) {
					throw new InvalidDataException("First names and surnames cannot be empty");
				}
				if (!int.TryParse(user[2], out testInt)) {
					throw new InvalidDataException("Score must be a valid integer, value: " + user[2]);
				}
				return true;
			} catch (InvalidDataException ide) {
				Console.WriteLine(ide.ToString());
				System.Environment.Exit(4);
			}
			return true;
		}

		/// <summary>
		/// Returns the list once sorted. </summary>
		/// <returns>Sorted list if generated, empty list otherwise.</returns>
		public List<UserEntry> GetSortedList() {
			if (sortedList.Count != 0) {
				return sortedList;
			} else {
				List<UserEntry> emptyList = new List<UserEntry>();
				return emptyList;
			}
		}
	}
}
