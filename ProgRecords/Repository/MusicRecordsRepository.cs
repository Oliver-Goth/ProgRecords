using ProgRecords.Class;

namespace ProgRecords.Repository
{
    public class MusicRecordsRepository
    {
        public List<MusicRecord> Records { get; set; }


        public MusicRecordsRepository()
        {
            Records = new List<MusicRecord>() {
            new MusicRecord() { Title = "man", Artist = "him", Duration = 200, Id = 1, PublicationYear = 2002 },
            new MusicRecord() { Title = "woman", Artist = "her", Duration = 400, Id = 2, PublicationYear = 2003 },
            new MusicRecord() { Title = "trans", Artist = "them", Duration = 400, Id = 2, PublicationYear = 2003 }};
        }

        public List<MusicRecord> Get()
        {
            return Records;
        }
    }
}
