using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult("Sepet Eklendi");
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Delete(cart);
            return new SuccessResult("Sepet silindi");
        }

        public IDataResult<List<Cart>> GetAll()
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll(), "Sepetler listelendi");
        }

        public IResult Update(Cart cart)
        {
            try
            {
                _cartDal.Update(cart);
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
