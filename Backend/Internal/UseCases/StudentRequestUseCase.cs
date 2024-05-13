using Hackaton_DW_2024.Infrastructure.Repositories.Api;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;

namespace Hackaton_DW_2024.Internal.UseCases;

public class StudentRequestUseCase
{
    StudentRepository _studentRepository;
    InstituteStructureRepository _instituteStructureRepository;
    DocFileRepository _docFileRepository;

    public StudentRequestUseCase(
        StudentRepository studentRepository, 
        InstituteStructureRepository instituteStructureRepository, 
        DocFileRepository docFileRepository)
    {
        _studentRepository = studentRepository;
        _instituteStructureRepository = instituteStructureRepository;
        _docFileRepository = docFileRepository;
    }

    public void SendRequest(int userId)
    {
        var studentDetails = _studentRepository.GetStudentDetailsByUserId(userId);
        var groupDetails = _instituteStructureRepository.GetGroupDetails(studentDetails.Group.Id);
        _docFileRepository.GenerateDoc(studentDetails, groupDetails);
    }
}