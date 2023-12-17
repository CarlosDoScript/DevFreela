using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetCommentsProjectById
{
    public class GetCommentsProjectByIdQuery : IRequest<List<CommentProjectViewModel>>
    {
        public GetCommentsProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
