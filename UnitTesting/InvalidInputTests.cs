using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTesting {
	[TestClass]
	public class InvalidInputTests {

		[TestMethod]
		public void TestInvalidScore() {
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\invalidScore.txt");
			} catch (InvalidDataException ide) {
				Assert.AreEqual(ide.Message, "Score must be a valid integer, value: abd");
			}
		}

		[TestMethod]
		public void TestInvalidName() {
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\invalidName.txt");
			} catch(InvalidDataException ide) {
				Console.WriteLine(ide.Message);
				Assert.AreEqual(ide.Message, "First names and surnames cannot be empty");
			}
		}

		[TestMethod]
		public void TestInvalidSurname() {
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\invalidSurname.txt");
			} catch(InvalidDataException ide) {
				Assert.AreEqual(ide.Message, "First names and surnames cannot be empty");
			}
		}

		[TestMethod]
		public void TestInvalidNumberOfInputs() {
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\invalidInputCount.txt");
			} catch(InvalidDataException ide) {
				Assert.AreEqual(ide.Message, "Input file has invalid data, must be in the format <Surname>, <First Name>, Score");
			}
		}

		[TestMethod]
		public void TestInvalidFile() {
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\doesnotexist");
			} catch (FileNotFoundException fnfe) {
				Assert.AreEqual(fnfe.Message, "Could not find input file at: c:/transmaxtest/doesnotexist");
			}
		}

		[TestMethod]
		public void TestFileWrite() {
			Boolean reachedException = false;
			try {
				GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\manyPeople.txt");
				rf.GenerateList();
				GradeScores.WriteFile wf = new GradeScores.WriteFile(rf.GetSortedList(), "tests\\manyPeople.txt", ".txt");
				wf.GenerateOutputFile();
			} catch (IOException ioe) { 
				reachedException = true;
			}
			Assert.IsTrue(!reachedException);
		}
	}
}
