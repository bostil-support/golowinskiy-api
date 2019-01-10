using GolovinskyAPI.Models;

namespace GolovinskyAPI.Infrastructure.Administration
{
    public interface ITemplateRepository
    {
        bool UploadDatabaseFromtxt(UploadDBfromtxt upload);

    }
}