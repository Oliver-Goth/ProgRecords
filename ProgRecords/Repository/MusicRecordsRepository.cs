using ProgRecords.Class;

namespace ProgRecords.Repository
{
    public class MusicRecordsRepository
    {
        public List<MusicRecord> Records { get; set; }
        private int _nextId = 0;


        public MusicRecordsRepository()
        {
            Records = new List<MusicRecord>() {
            new MusicRecord() { Title = "Whistle", Artist = "PittBull", Duration = 340, Id = _nextId++, PublicationYear = 2012 },
            new MusicRecord() { Title = "love me harder", Artist = "Ariana grande", Duration = 280, Id = _nextId++, PublicationYear = 2017 },
            new MusicRecord() { Title = "give it to me", Artist = "The nothern Boys", Duration = 275, Id = _nextId++, PublicationYear = 2014 }};
        }

        public List<MusicRecord> Get(string? title = null, string? sortBy = null, int year = 0 )
        {
            List<MusicRecord> SortedList = new List<MusicRecord>(Records);
            if (title != null)
            {
                SortedList.Where(x => x.Title != null && x.Title.Contains(title));
            }
            if (year > 1000)
            {
                SortedList.Where(x => x.PublicationYear > (year - 5) && x.PublicationYear < (year + 5));
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "title":
                        SortedList = SortedList.OrderBy(x => x.Title).ToList();
                        break;
                    case "artist":
                        SortedList = SortedList.OrderBy(x => x.Artist).ToList(); 
                        break;
                    case "publisyear":
                        SortedList = SortedList.OrderBy(x => x.PublicationYear).ToList();
                        break;
                }
            }
            return SortedList;
        }
        public MusicRecord GetById(int id) 
        {
            return Records[id];
        }

        public void Add(MusicRecord newRecord)
        {
            if (newRecord == null) throw new ArgumentException("record is null");
            newRecord.Id = _nextId++;
            Records.Add(newRecord);
        }
    }
}
