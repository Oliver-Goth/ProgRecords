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
            MusicRecord record = new MusicRecord();

            List<MusicRecord> item = repository.Get();
            Assert.AreEqual(item.Count(), 3);
        }
    }
}