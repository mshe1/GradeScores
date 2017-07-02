/**
 * An object that defines a single entry from an input file containing
 * a score, first name and surname.
 * 
 * Version: 1.0
 * Date: 01 July 2017
 */

using System;

namespace GradeScores {
	public class UserEntry {
		private String firstName;
		private String lastName;
		private int score;

		public UserEntry(String fn, String ln, int s) {
			firstName = fn;
			lastName = ln;
			score = s;
		}

		/// <summary>
		/// Returns the entry's first name.
		/// </summary>
		/// <returns>Entry's first name</returns>
		public String GetFirstName() {
			return firstName;
		}

		/// <summary>
		/// Returns the entry's surname.
		/// </summary>
		/// <returns>Entry's surname</returns>
		public String GetLastName() {
			return lastName;
		}

		/// <summary>
		/// Returns the entry's score.
		/// </summary>
		/// <returns>Entry's score.</returns>
		public int GetScore() {
			return score;
		}

		/// <summary>
		/// Returns the string representation of the object as it appears
		/// in the input file and will appear in the output file.
		/// </summary>
		/// <returns>String representation of an entry</returns>
		public String toString() {
			return lastName + ", " + firstName + ", " + score + "\r\n";
		}

		/// <summary>
		/// Checks if two entries are equal by comparing both names and score.
		/// </summary>
		/// <param name="otherUser">The entry being compared to this entry.</param>
		/// <returns>true if entries are equal, false otherwise</returns>
		public Boolean isEqual(UserEntry otherUser) {
			if(this.firstName != otherUser.GetFirstName()) {
				return false;
			}
			if(this.lastName != otherUser.GetLastName()) {
				return false;
			}
			if(this.score != otherUser.GetScore()) {
				return false;
			}
			return true;
		}
	}
}
