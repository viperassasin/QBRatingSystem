using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QBRatingSystem.Dependencies;
using QBRatingSystem.ViewModels;

namespace QBRatingViewModelTest
{
    [TestClass]
    public class QBViewModelTest
    {
        enum StatColumn
        {
            PassAttemps, PassCompletions, PassYards, PassTouchdowns, PassInterceptions
        }

        private const decimal ProUpper = 158.3M;
        private Dictionary<StatColumn, int?> statsDictionary = new Dictionary<StatColumn, int?>()
        {
            {StatColumn.PassAttemps,105 },
            {StatColumn.PassCompletions,105 },
            {StatColumn.PassYards,1500 },
            {StatColumn.PassTouchdowns,25 },
            {StatColumn.PassInterceptions,3 }
        };
        private decimal? nflRating;
        private decimal? cflRating;
        private decimal? ncaaRating;

        QBRatingViewModel nflQBViewModel = new QBRatingViewModel(new NationalFootballLeagueQB());
        QBRatingViewModel cflQbRatingViewModel = new QBRatingViewModel(new CanadianFootbalLeagueQB());
        QBRatingViewModel ncaaQqRatingViewModel = new QBRatingViewModel(new NationalCollegiateAthleticAssociationQB());


        private void CheckProperties(QBRatingViewModel quarterbackViewModel)
        {
            Assert.AreEqual(statsDictionary[StatColumn.PassCompletions], quarterbackViewModel.PassAttemps);
            Assert.AreEqual(statsDictionary[StatColumn.PassAttemps], quarterbackViewModel.PassCompletions);
            Assert.AreEqual(statsDictionary[StatColumn.PassYards], quarterbackViewModel.PassYards);
            Assert.AreEqual(statsDictionary[StatColumn.PassTouchdowns], quarterbackViewModel.PassTouchdowns);
            Assert.AreEqual(statsDictionary[StatColumn.PassInterceptions], quarterbackViewModel.PassInterceptions);
        }

        private void SetQBStats(params QBRatingViewModel[] viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                viewModel.PassAttemps = statsDictionary[StatColumn.PassAttemps];
                viewModel.PassCompletions = statsDictionary[StatColumn.PassCompletions];
                viewModel.PassYards = statsDictionary[StatColumn.PassYards]; ;
                viewModel.PassTouchdowns = statsDictionary[StatColumn.PassTouchdowns]; ;
                viewModel.PassInterceptions = statsDictionary[StatColumn.PassInterceptions];
            }
        }

        private void SetNewDictionaryValues(int attepmps = 0, int completions = 0, int yards = 0, int touchdowns = 0, int interceptions = 0)
        {
            statsDictionary[StatColumn.PassAttemps] = attepmps;
            statsDictionary[StatColumn.PassCompletions] = completions;
            statsDictionary[StatColumn.PassYards] = yards;
            statsDictionary[StatColumn.PassTouchdowns] = touchdowns;
            statsDictionary[StatColumn.PassInterceptions] = interceptions;
        }

        [TestMethod]
        public void TestLeaguePropertiesAndDiff()
        {
            TestNFLQB();
            TestCFLQB();
            TestNCAAQB();
            TestCFLNFLSame();
            TestCFLNFLNCAADifferent();
        }


        public void TestCFLNFLSame()
        {
            Assert.AreEqual(nflRating, cflRating);
        }

        public void TestCFLNFLNCAADifferent()
        {
            Assert.AreNotEqual(nflRating, ncaaRating);
            Assert.AreNotEqual(cflRating, ncaaRating);
        }


        public void TestNFLQB()
        {
            SetQBStats(nflQBViewModel);
            CheckProperties(nflQBViewModel);
            Assert.AreEqual(146.43M, nflQBViewModel.GetPasserRating());
            this.nflRating = nflQBViewModel.GetPasserRating();
        }

        public void TestCFLQB()
        {
            SetQBStats(cflQbRatingViewModel);
            CheckProperties(cflQbRatingViewModel);
            Assert.AreEqual(146.43M, cflQbRatingViewModel.GetPasserRating());
            this.cflRating = cflQbRatingViewModel.GetPasserRating();
            TestCFLNFLSame();
        }
        public void TestNCAAQB()
        {

            SetQBStats(ncaaQqRatingViewModel);
            CheckProperties(ncaaQqRatingViewModel);
            Assert.AreEqual(292.86M, ncaaQqRatingViewModel.GetPasserRating());
            this.ncaaRating = ncaaQqRatingViewModel.GetPasserRating();
            TestCFLNFLNCAADifferent();
        }

        [TestMethod]
        public void TestQBLowerLimit()
        {
            SetNewDictionaryValues(100, 30, 300, 0, 10);

            SetQBStats(nflQBViewModel, cflQbRatingViewModel);
            Assert.AreEqual(0, nflQBViewModel.GetPasserRating());
            Assert.AreEqual(0, nflQBViewModel.GetPasserRating());

            SetNewDictionaryValues(10, 10, -990, 0, 0);
            SetQBStats(ncaaQqRatingViewModel);
            Assert.AreEqual(-731.6M, ncaaQqRatingViewModel.GetPasserRating());
        }


        [TestMethod]
        public void TestQBUpperLimits()
        {
            SetNewDictionaryValues(100, 78, 1250, 12, 0);
            SetQBStats(nflQBViewModel, cflQbRatingViewModel);
            Assert.AreEqual(ProUpper, nflQBViewModel.GetPasserRating());
            Assert.AreEqual(ProUpper, cflQbRatingViewModel.GetPasserRating());

            SetNewDictionaryValues(10, 10, 990, 10, 0);
            SetQBStats(ncaaQqRatingViewModel);
            Assert.AreEqual(1261.6M, ncaaQqRatingViewModel.GetPasserRating());
        }

        [TestMethod]
        public void TestNulls()
        {
            SetNewDictionaryValues(100, 100, 100, 100, 100);
            var enumArray = (StatColumn[])Enum.GetValues(typeof(StatColumn));
            foreach (var stat in enumArray)
            {
                SetDictionaryValueToNull(stat, nflQBViewModel, cflQbRatingViewModel, ncaaQqRatingViewModel);
            }
        }

        private void SetDictionaryValueToNull(StatColumn stat, params QBRatingViewModel[] qBRatingViewModels)
        {
            int? temp = statsDictionary[stat];
            statsDictionary[stat] = null;
            SetQBStats(qBRatingViewModels);
            foreach (var qbViewModel in qBRatingViewModels)
            {
                Assert.ThrowsException<InvalidOperationException>(() => qbViewModel.GetPasserRating());
            }
            statsDictionary[stat] = temp;
        }
    }
}
