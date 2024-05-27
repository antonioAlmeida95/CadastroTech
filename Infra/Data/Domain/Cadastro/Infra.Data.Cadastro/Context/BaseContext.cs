using System.Linq;
using Infra.Data.Cadastro.Context.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Cadastro.Context;

public class BaseContext : DbContext, IBaseContext
{
    /// <inheritdoc />
    public IQueryable<T> GetQuery<T>(bool track) where T : class => track ? Set<T>() : Set<T>().AsNoTracking();
    
    /// <inheritdoc />
    public IQueryable<T> GetQuery<T>() where T : class => Set<T>().AsNoTracking();
}