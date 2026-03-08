using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace StudentRegistration.Departments;

[Mapper]
public partial class DepartmentCreateUpdateMapper : MapperBase<CreateUpdateDepartmentDto, Department>
{
    public override partial Department Map(CreateUpdateDepartmentDto source);

    public override void Map(CreateUpdateDepartmentDto source, Department destination)
    {
        destination.Name = source.Name;
        destination.Quota = source.Quota;
    }
}