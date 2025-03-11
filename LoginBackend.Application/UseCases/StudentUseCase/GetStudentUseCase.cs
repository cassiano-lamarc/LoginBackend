using AutoMapper;
using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Responses.Students;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class GetStudentUseCase : StudentBaseUseCase, IGetStudentUseCase
{
    private readonly IMapper _mapper;
   
    public GetStudentUseCase(IMapper mapper, IStudentRepository repository): base (repository)
    {
        _mapper = mapper;
    }

    public async Task<List<GetStudentResponse>> Handler()
        => _mapper.Map<List<GetStudentResponse>>(await _repository.Get());
}
