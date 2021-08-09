using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult("Hizmet Eklendi");
        }

        public IResult Delete(Service service)
        {
            _serviceDal.Delete(service);
            return new SuccessResult("Hizmet silindi");
        }

        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(), "Hizmetler listelendi");
        }

        public IDataResult<Service> GetById(int serviceId)
        {
            return new SuccessDataResult<Service>(_serviceDal.Get(u => u.ServiceId == serviceId), "Hizmet numarasına göre data getirildi.");
        }

        public IResult Update(Service service)
        {
            try
            {
                _serviceDal.Update(service);
                return new SuccessResult("Güncelleme başarılı.");
            }
            catch (Exception)
            {
                return new ErrorResult("Tüm bilgileri eksiksiz giriniz.");
                throw;
            }
        }
    }
}
