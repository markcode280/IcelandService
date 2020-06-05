using System;
using System.Collections.Generic;
using System.Text;

namespace IcelandService.Services
{
    public interface IFileService
    {
        void save(object text, string fileLocation);
        List<T> upload<T>(string path, string splitCharacter) where T: new();
    }
}
