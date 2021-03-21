using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //[SecuredOperation("Admin,Moderator")]
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("Customer.add")]
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("Customer.delete")]
        [CacheRemoveAspect("get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.EntityDeleted);
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id));
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [SecuredOperation("Customer.update")]
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetAllCustomerDetail());
        }
    }
}
