using System.Threading.Tasks;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext.Repositories
{
  /// <summary>
  /// Represents the _UnitOfWork_ repository
  /// </summary>
  public class UnitOfWork
  {
    private readonly AccountContext _context;

    public virtual Repository<AccountModel> Account { get; }
    public virtual Repository<ProfileModel> Profile { get; }

    public UnitOfWork(AccountContext context)
    {
      _context = context;

      Account = new Repository<AccountModel>(context);
      Profile = new Repository<ProfileModel>(context);
    }

    /// <summary>
    /// Represents the _UnitOfWork_ `Commit` method
    /// </summary>
    /// <returns></returns>
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
  }
}
