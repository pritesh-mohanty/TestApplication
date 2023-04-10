using Bidone.CodingTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidone.CodingTest.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        void BuildOutputFile(Domain.Model.User records, string fileName);
        IEnumerable<Domain.Model.User> ReadOutputFile(string fileName);
    }
}
