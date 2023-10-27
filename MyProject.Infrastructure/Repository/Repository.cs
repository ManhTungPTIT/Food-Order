using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;


namespace MyProject.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext Context;
    private DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        this.Context = context;
        _entities = this.Context.Set<T>();
    }
}

