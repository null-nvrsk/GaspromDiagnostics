using System.Collections.Generic;

namespace GaspromDiagnostics.Services
{
    public interface IFileService
    {
        List<Object>? Open(string filename);
        void Save(string filename, List<Object> objects);
    }
}
