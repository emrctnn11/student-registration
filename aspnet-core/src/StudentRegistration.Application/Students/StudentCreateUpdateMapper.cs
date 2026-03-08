using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace StudentRegistration.Students;

[Mapper]
public partial class StudentCreateUpdateMapper : MapperBase<CreateUpdateStudentDto, Student>
{
    public override partial Student Map(CreateUpdateStudentDto source);

    public override void Map(CreateUpdateStudentDto source, Student destination)
    {
        destination.FirstName = source.FirstName;
        destination.LastName = source.LastName;
        destination.NationalId = source.NationalId;
        destination.Province = source.Province;
        destination.District = source.District;
        destination.DepartmentId = source.DepartmentId;
    }
}