using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUserDal _userDal;

        public CustomerManager(ICustomerDal customerDal, IUserDal userDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
        }
        public IResult Add(Customer customer)
        {
            var user = _userDal.Get(u => u.UserId == customer.UserId);
            if(user == null)
            {
                return new ErrorResult(Messages.AddedCustomerNotFoundUser);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour != 23)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.UserId == customerId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
