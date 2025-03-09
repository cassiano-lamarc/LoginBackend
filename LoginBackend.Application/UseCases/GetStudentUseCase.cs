using AutoMapper;
using LoginBackend.Application.Interfaces;
using LoginBackend.Application.Responses;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases;

public class GetStudentUseCase : IGetStudentUseCase
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;
   
    public GetStudentUseCase(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<GetStudentResponse>> Handler()
        => _mapper.Map<List<GetStudentResponse>>(await _repository.Get());
}
