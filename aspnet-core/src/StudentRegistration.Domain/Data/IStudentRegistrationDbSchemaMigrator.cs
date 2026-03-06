using System.Threading.Tasks;

namespace StudentRegistration.Data;

public interface IStudentRegistrationDbSchemaMigrator
{
    Task MigrateAsync();
}
