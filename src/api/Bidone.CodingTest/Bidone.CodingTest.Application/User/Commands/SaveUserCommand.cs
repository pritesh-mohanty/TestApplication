using Bidone.CodingTest.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bidone.CodingTest.Domain.Model;
using Bidone.CodingTest.Application.Configurations;
using System.IO;
using Microsoft.Extensions.Options;

namespace Bidone.CodingTest.Application.User.Commands
{
    public class SaveUserCommand : IRequest<Unit>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, Unit>
    {
        private readonly IFileStorageService _fileContext;
        private readonly FileStorageOptions _fileOptions;

        public SaveUserCommandHandler(IFileStorageService fileContext, IOptions<FileStorageOptions> fileOptions)
        {
            _fileContext = fileContext;
            _fileOptions = fileOptions.Value;
        }

        public async Task<Unit> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Model.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _fileContext.BuildOutputFile(entity, _fileOptions.FileLocation);
            //Can return created entity id instead
            return await Task.FromResult(Unit.Value);
        }
    }
}
