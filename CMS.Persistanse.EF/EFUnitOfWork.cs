﻿using CMS.Services.Contracts;

namespace CMS.Persistanse.EF;

public class EFUnitOfWork : UnitOfWork
{
    private readonly EFDataContext _context;

    public EFUnitOfWork(EFDataContext context)
    {
        _context = context;
    }
    public void Complete()
    {
        _context.SaveChanges();
    }
}