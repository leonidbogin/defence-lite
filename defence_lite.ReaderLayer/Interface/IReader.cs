using System;

namespace defence_lite.ReaderLayer.Interface
{
    public interface IReader
    {
        event Action<ReadRecord> ReadEvent;
        bool IsOpen { get; }
        bool TryOpen(string portName);
        void Close();
    }
}