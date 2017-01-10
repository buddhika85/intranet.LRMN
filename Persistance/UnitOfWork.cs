using Persistance.DomainModel;
using System;

namespace Persistance
{
    // Allows transaction handling 
    // Mainly allows connected classes/entities to be committed as a single transaction
    public class UnitOfWork : IDisposable
    {
        #region FIELDS
        ApplicationDbContext _context;
        bool disposed;
        #endregion FIELDS

        // contructor
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            disposed = false;
        }

        // clean and release the resouces
        public void Dispose()
        {
            if (disposed == false)
            {
                _context.Dispose();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #region REPOSITORIES

        // all the table/entity specific repositories as instances       
        GenericRepository<ContactType> contactTypeRepository;
        GenericRepository<ApplicationUser> applicationUserRepository;

        // add more repositories below
        // ...
        // ..

        // properties to return table/entity specific repository instances
        public GenericRepository<ContactType> ContactTypeRepository
        {
            get
            {
                if (contactTypeRepository == null)
                {
                    contactTypeRepository = new GenericRepository<ContactType>(_context);
                }
                return contactTypeRepository;
            }
        }
        public GenericRepository<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                if (applicationUserRepository == null)
                {
                    applicationUserRepository = new GenericRepository<ApplicationUser>(_context);
                }
                return applicationUserRepository;
            }
        }
        // add more repositories below
        // ...
        // ..

        #endregion REPOSITORIES


        // save and commit to the DB
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
