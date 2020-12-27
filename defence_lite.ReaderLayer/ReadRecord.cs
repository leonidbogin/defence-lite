using System;

namespace defence_lite.ReaderLayer
{
    public class ReadRecord
    {
        public string CardNumber { get; set; }
        public DateTime ReadTime { get; set; }

        public ReadRecord()
        {
            
        }

        public ReadRecord(string cardNumber)
        {
            CardNumber = cardNumber;
            ReadTime = DateTime.Now;
        }
        
        public ReadRecord(string cardNumber, DateTime readTime)
        {
            CardNumber = cardNumber;
            ReadTime = readTime;
        }
    }
}