using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace StudentRegistration.Students;

[Mapper]
public partial class StudentMapper : TwoWayMapperBase<Student, StudentDto>
{
    [MapperIgnoreSource(nameof(Student.ExtraProperties))]
    [MapperIgnoreSource(nameof(Student.ConcurrencyStamp))]
    [MapperIgnoreSource(nameof(Student.Department))]
    public override partial StudentDto Map(Student source);

    public override void Map(Student source, StudentDto destination)
    {
        var result = Map(source);
        destination.Id = result.Id;
        destination.FirstName = result.FirstName;
        destination.LastName = result.LastName;
        destination.NationalId = result.NationalId;
        destination.Province = result.Province;
        destination.District = result.District;
        destination.DepartmentId = result.DepartmentId;
    }

    [MapperIgnoreTarget(nameof(Student.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(Student.ExtraProperties))]
    [MapperIgnoreTarget(nameof(Student.IsDeleted))]
    [MapperIgnoreTarget(nameof(Student.DeleterId))]
    [MapperIgnoreTarget(nameof(Student.DeletionTime))]
    [MapperIgnoreTarget(nameof(Student.LastModificationTime))]
    [MapperIgnoreTarget(nameof(Student.LastModifierId))]
    [MapperIgnoreTarget(nameof(Student.CreationTime))]
    [MapperIgnoreTarget(nameof(Student.CreatorId))]
    [MapperIgnoreTarget(nameof(Student.Id))]
    [MapperIgnoreTarget(nameof(Student.Department))]
    [MapperIgnoreSource(nameof(StudentDto.DepartmentName))]
    public override partial Student ReverseMap(StudentDto source);

    public override void ReverseMap(StudentDto source, Student destination)
    {
        destination.FirstName = source.FirstName;
        destination.LastName = source.LastName;
        destination.NationalId = source.NationalId;
        destination.Province = source.Province;
        destination.District = source.District;
        destination.DepartmentId = source.DepartmentId;
    }
}