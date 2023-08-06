using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfacies;
using Notes.Domain;
namespace Notes.Application.Notes.Commands.CreateNode
{
    public class CreateNodeCommandhandler : IRequestHandler<CreateNodeCommand, Guid>
    {
        private readonly INoteDbContext _dbContext;
        public CreateNodeCommandhandler(INoteDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
