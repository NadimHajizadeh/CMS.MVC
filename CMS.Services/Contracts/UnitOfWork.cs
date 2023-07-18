namespace CMS.Services.Contracts;

public interface UnitOfWork
{
    void Complete();
}