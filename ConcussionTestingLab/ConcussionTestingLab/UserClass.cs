using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcussionTestingLab
{
    class UserClass
    {
        public class User
        {
            public string userID;
            public string userName;
        } // User

        public class TestScores
        {
            public DateTime curDate;
            public double concentrationScore;
            public double memoryScore;
            public double reactionTimeScore;
        } // TestScores

        public class ConcentrationTest
        {
            public double timeSpent;
            public int correctAnswer;
            public int wrongAnswer;
            public int totalAnswer;
            public double score;
        } // ConcentrationTest

        public class MemoryTest
        {
            public double timeSpent;
            public int correctAnswers;
            public int wrongAnswers;
            public int totalAnswers;
            public double score;
        } // MemoryTest

        public static List<User> userList = new List<User>();
        public static List<TestScores> testScoreList = new List<TestScores>();
        public static List<ConcentrationTest> concentrationList = new List<ConcentrationTest>();
        public static List<MemoryTest> memoryList = new List<MemoryTest>();
    }
}
