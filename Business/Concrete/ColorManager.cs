using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("get")]
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.EntityAdded);
        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin,color.delete")]
        [CacheRemoveAspect("get")]
        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.EntityDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.EntityListed);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id),Messages.EntityListed);
        }
        [SecuredOperation("Color.update")]
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
