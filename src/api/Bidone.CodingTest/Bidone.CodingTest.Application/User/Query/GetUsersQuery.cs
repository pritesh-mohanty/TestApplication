using Bidone.CodingTest.Application.Common.Interfaces;
using Bidone.CodingTest.Application.Configurations;
using Bidone.CodingTest.Domain.Model;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidone.CodingTest.Application.User.Query
{
    public class GetUsersQuery : IRequest<IEnumerable<Domain.Model.User>>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<Domain.Model.User>>
    {
        private readonly IFileStorageService _fileContext;
        private readonly FileStorageOptions _fileOptions;

        public GetUsersQueryHandler(IFileStorageService fileContext, IOptions<FileStorageOptions> fileOptions)
        {
            _fileContext = fileContext;
            _fileOptions = fileOptions.Value;
        }

        public async Task<IEnumerable<Domain.Model.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _fileContext.ReadOutputFile(_fileOptions.FileLocation);
        }
    }
}
