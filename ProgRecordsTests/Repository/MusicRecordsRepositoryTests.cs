using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgRecords.Class;
using ProgRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgRecords.Repository.Tests
{
    [TestClass()]
    public class MusicRecordsRepositoryTests
    {
        [TestMethod()]
        public void MusicRecordsRepository_Test()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();

            Assert.IsInstanceOfType(repository, typeof(MusicRecordsRepository));
            Assert.AreEqual(repository.Records.Count(), 3);
        }

        [TestMethod()]
        public void Get_Test()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();

            List<MusicRecord> item = repository.Get();
            Assert.AreEqual(item.Count(), 3);
        }

        [TestMethod()]
        public void Get_Test_title()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();

            List<MusicRecord> Sorteditem = repository.Get(title: "whistle");
            Assert.AreEqual(Sorteditem.First().Title, "Whistle");
        }

        [TestMethod()]
        public void Get_Test_year()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();

            List<MusicRecord> Sorteditem = repository.Get(year: 2014);
            Console.WriteLine(Sorteditem.First());
            Assert.IsTrue(Sorteditem[0].PublicationYear > (2014 - 5) && Sorteditem[0].PublicationYear < (2014 + 5));
        }

        [TestMethod()]
        public void Get_Test_sort()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();
            List<MusicRecord> expectedResult = repository.Records.OrderBy(x => x.Title).ToList();

            List<MusicRecord> Sorteditem = repository.Get(sortBy:"title");
            Assert.AreEqual(Sorteditem[0].Title, "give it to me");
            Assert.AreEqual(Sorteditem[1].Title, "love me harder");
            Assert.AreEqual(Sorteditem[2].Title, "Whistle");
        }

        [TestMethod()]
        public void add_new_record()
        {
            MusicRecordsRepository repository = new MusicRecordsRepository();
            List<MusicRecord> oldList = repository.Get();

            MusicRecord newRecord = new MusicRecord() { Title = "new", Artist = "new", Duration = 999, Id =0, PublicationYear = 2077 };
            repository.Add(newRecord);
            List<MusicRecord> newList = repository.Get();

            Assert.IsTrue(newList.Count > oldList.Count);
            Assert.AreEqual(newList.Last().Title, "new");
        }
    }
}