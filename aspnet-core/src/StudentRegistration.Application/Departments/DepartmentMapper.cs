using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace StudentRegistration.Departments;

[Mapper]
public partial class DepartmentMapper : TwoWayMapperBase<Department, DepartmentDto>
{
    [MapperIgnoreSource(nameof(Department.ExtraProperties))]
    [MapperIgnoreSource(nameof(Department.ConcurrencyStamp))]
    public override partial DepartmentDto Map(Department source);

    public override void Map(Department source, DepartmentDto destination)
    {
        var result = Map(source);
        destination.Id = result.Id;
        destination.Name = result.Name;
        destination.Quota = result.Quota;
    }

    [MapperIgnoreTarget(nameof(Department.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(Department.ExtraProperties))]
    [MapperIgnoreTarget(nameof(Department.IsDeleted))]
    [MapperIgnoreTarget(nameof(Department.DeleterId))]
    [MapperIgnoreTarget(nameof(Department.DeletionTime))]
    [MapperIgnoreTarget(nameof(Department.LastModificationTime))]
    [MapperIgnoreTarget(nameof(Department.LastModifierId))]
    [MapperIgnoreTarget(nameof(Department.CreationTime))]
    [MapperIgnoreTarget(nameof(Department.CreatorId))]
    [MapperIgnoreTarget(nameof(Department.Id))]
    public override partial Department ReverseMap(DepartmentDto source);

    public override void ReverseMap(DepartmentDto source, Department destination)
    {
        destination.Name = source.Name;
        destination.Quota = source.Quota;
    }
}