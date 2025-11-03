using App.Application.Response.DTOs;
using App.Domain.Response.Interfaces;
using AutoMapper;
using MediatR;

namespace App.Application.Response.Queries;

public class GetAllResponsesQueryHandler : IRequestHandler<GetAllResponsesQuery, IEnumerable<ResponseDto>>
{
    private readonly IResponseRepository _responseRepository;
    private readonly IMapper _mapper;

    public GetAllResponsesQueryHandler(IResponseRepository responseRepository, IMapper mapper)
    {
        _responseRepository = responseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ResponseDto>> Handle(GetAllResponsesQuery request, CancellationToken cancellationToken)
    {
        var responses = await _responseRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ResponseDto>>(responses);
    }
}