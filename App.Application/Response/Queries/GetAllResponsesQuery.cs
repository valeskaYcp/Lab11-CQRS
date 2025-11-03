using App.Application.Response.DTOs;
using MediatR;

namespace App.Application.Response.Queries;
public class GetAllResponsesQuery : IRequest<IEnumerable<ResponseDto>>
{
    
}