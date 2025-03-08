using AutoMapper;
using LoginBackend.Application.Interfaces;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases
{
    public class AddStudentUseCase : IAddStudentUseCase
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repository;

        public AddStudentUseCase(IStudentRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handler(AddStudentRequest request)
        {
            var newId = await _repository.Add(_mapper.Map<Student>(request));

            if (newId == 0)
                throw new Exception("Student not add. Occurred an error adding student");

            return newId;
        }
    }
}
