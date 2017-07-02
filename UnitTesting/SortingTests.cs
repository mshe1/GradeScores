using GradeScores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTesting {
	[TestClass]
	public class SortingTests {

		private Boolean compareUserLists(List<UserEntry> listOne, List<UserEntry> listTwo) {
			if(listOne.Count != listTwo.Count) {
				return false;
			}
			for(int i = 0; i < listOne.Count; i++) {
				if(!listOne[i].isEqual(listTwo[i])) {
					return false;
				}
			}
			return true;
		}

		[TestMethod]
		public void TestEmptyList() {
			GradeScores.ReadFile rf = new GradeScores.ReadFile("tests\\empty.txt");
			rf.GenerateList();
			List<GradeScores.UserEntry> emptyList = new List<GradeScores.UserEntry>();
			Assert.IsTrue(compareUserLists(rf.GetSortedList(), emptyList));
			GradeScores.WriteFile wf = new GradeScores.WriteFile(rf.GetSortedList(),
				"tests\\empty.txt", ".txt");
			wf.GenerateOutputFile();
		}

		[TestMethod]
		public void TestSinglePerson() {
			List<UserEntry> tempList = new List<UserEntry>();
			tempList.Add(new UserEntry("TERESSA", "BUNDY", 88));
			ReadFile rf = new ReadFile("tests\\onePerson.txt");
			rf.GenerateList();
			Boolean compareLists = compareUserLists(tempList, rf.GetSortedList());
			Assert.IsTrue(compareLists);
		}

		[TestMethod]
		public void TestTwoPeople() {
			List<UserEntry> tempList = new List<UserEntry>();
			tempList.Add(new UserEntry("TERESSA", "BUNDY", 88));
			tempList.Add(new UserEntry("ALLAN", "ANDY", 70));
			ReadFile rf = new ReadFile("tests\\twoPeople.txt");
			rf.GenerateList();
			Boolean compareLists = compareUserLists(tempList, rf.GetSortedList());
			Assert.IsTrue(compareLists);
		}

		[TestMethod]
		public void TestFourPeople() {
			List<UserEntry> tempList = new List<UserEntry>();
			tempList.Add(new UserEntry("TERESSA", "BUNDY", 88));
			tempList.Add(new UserEntry("MADISON", "GEORGE", 87));
			tempList.Add(new UserEntry("FRANCIS", "SMITH", 85));
			tempList.Add(new UserEntry("ALLAN", "ANDY", 70));
			ReadFile rf = new ReadFile("tests\\fourPeople.txt");
			rf.GenerateList();
			Boolean compareLists = compareUserLists(tempList, rf.GetSortedList());
			Assert.IsTrue(compareLists);
		}

		[TestMethod]
		public void TestSameScore() {
			List<UserEntry> tempList = new List<UserEntry>();
			tempList.Add(new UserEntry("TERESSA", "BUNDY", 88));
			tempList.Add(new UserEntry("MADISON", "GEORGE", 88));
			tempList.Add(new UserEntry("FRANCIS", "SMITH", 85));
			tempList.Add(new UserEntry("ALLAN", "ANDY", 70));
			ReadFile rf = new ReadFile("tests\\sameScore.txt");
			rf.GenerateList();
			Boolean compareLists = compareUserLists(tempList, rf.GetSortedList());
			Assert.IsTrue(compareLists);
		}

		[TestMethod]
		public void TestSameScoreSameName() {
			List<UserEntry> tempList = new List<UserEntry>();
			tempList.Add(new UserEntry("MADISON", "BUNDY", 88));
			tempList.Add(new UserEntry("TERESSA", "BUNDY", 88));
			tempList.Add(new UserEntry("FRANCIS", "SMITH", 85));
			tempList.Add(new UserEntry("ALLAN", "ANDY", 70));
			ReadFile rf = new ReadFile("tests\\sameScoreSameName.txt");
			rf.GenerateList();
			Boolean compareLists = compareUserLists(tempList, rf.GetSortedList());
			Assert.IsTrue(compareLists);
		}
	}
}
